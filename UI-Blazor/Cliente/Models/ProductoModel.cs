using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Cliente.Models
{
    public class ProductoModel
    {
        private readonly Application.Interfaces.IProductoService _productoService;
        private readonly IJSRuntime _js;

        public ProductoDto? ProductoSeleccionado { get; set; }
        public List<ProductoDto> Productos { get; set; } = new();

        public ProductoModel(Application.Interfaces.IProductoService productoService, IJSRuntime js)
        {
            _productoService = productoService;
            _js = js;
        }

        public async Task CargarProductos()
        {
            try
            {
                Productos = (await _productoService.GetAllAsync()).ToList();
            }
            catch (Exception ex)
            {
                await _js.InvokeVoidAsync("alert", $"Error al cargar productos: {ex.Message}");
            }
        }

        public async Task SeleccionarProducto(ProductoDto producto)
        {
            if (producto.Can_Pro <= 0)
            {
                await _js.InvokeVoidAsync("alert", "Este producto no tiene stock disponible");
                return;
            }

            ProductoSeleccionado = producto;
        }

        public void LimpiarSeleccion()
        {
            ProductoSeleccionado = null;
        }
    }
}