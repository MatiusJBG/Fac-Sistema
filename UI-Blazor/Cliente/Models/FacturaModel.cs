using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Cliente.Models
{
    public class FacturaModel
    {
        private readonly Application.Interfaces.IFacturaService _facturaService;
        private readonly IJSRuntime _js;
        private readonly NavigationManager _navigationManager;

        public FacturaDto FacturaActual { get; set; } = new();
        public ClienteDto? ClienteSeleccionado { get; set; }
        public List<DetalleFacturaDto> Detalles { get; set; } = new();

        public FacturaModel(Application.Interfaces.IFacturaService facturaService, IJSRuntime js, NavigationManager navigationManager)
        {
            _facturaService = facturaService;
            _js = js;
            _navigationManager = navigationManager;
        }

        public void SeleccionarCliente(ClienteDto cliente)
        {
            ClienteSeleccionado = cliente;
            FacturaActual.Ced_Cli_Per = cliente.Ced_Cli;
        }

        public void LimpiarClienteSeleccionado()
        {
            ClienteSeleccionado = null;
            FacturaActual.Ced_Cli_Per = null!;
        }

        public async Task GuardarFactura()
        {
            try
            {
                var createFacturaDto = new CreateFacturaDto
                {
                    Ced_Cli_Per = FacturaActual.Ced_Cli_Per,
                    Detalles = Detalles.Select(d => new CreateDetalleFacturaDto
                    {
                        Id_Pro_Per = d.Id_Pro_Per,
                        Can_Com = d.Can_Com
                    }).ToList()
                };

                await _facturaService.CreateAsync(createFacturaDto);
                await _js.InvokeVoidAsync("alert", "Factura guardada correctamente");
                _navigationManager.NavigateTo("/facturas");
            }
            catch (Exception ex)
            {
                await _js.InvokeVoidAsync("alert", $"Error al guardar la factura: {ex.Message}");
            }
        }
    }
}