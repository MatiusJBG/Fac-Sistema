using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Domain;
using Core.Interfaces;

namespace Application.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _repository;
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public FacturaService(IFacturaRepository repository, IProductoRepository productoRepository, IMapper mapper)
        {
            _repository = repository;
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FacturaDto>> GetAllAsync()
        {
            var facturas = await _repository.GetAllAsync(); // ← Cambiar aquí
            return _mapper.Map<IEnumerable<FacturaDto>>(facturas);
        }

        public async Task<FacturaDto?> GetByIdAsync(int id)
        {
            var factura = await _repository.GetByIdAsync(id); // ← Cambiar aquí
            return _mapper.Map<FacturaDto>(factura);
        }

        public async Task<FacturaDto> CreateAsync(CreateFacturaDto dto)
        {
            // Crear la factura
            var factura = new Factura
            {
                Fec_Fac = DateTime.Now,
                Ced_Cli_Per = dto.Ced_Cli_Per,
                Tot_Fac = 0,
                Detalles = new List<DetalleFactura>()
            };

            // Agregar los detalles y calcular el total
            decimal subtotal = 0;

            foreach (var detalleDto in dto.Detalles)
            {
                // Obtener el producto para conocer su precio
                var producto = await _productoRepository.GetByIdAsync(detalleDto.Id_Pro_Per);
                if (producto == null)
                    throw new Exception($"Producto con ID {detalleDto.Id_Pro_Per} no encontrado");

                var detalle = new DetalleFactura
                {
                    Id_Pro_Per = detalleDto.Id_Pro_Per,
                    Can_Com = detalleDto.Can_Com
                };

                // Calcular el subtotal de este detalle
                decimal subtotalDetalle = producto.Pre_Uni * detalleDto.Can_Com;
                subtotal += subtotalDetalle;

                factura.Detalles.Add(detalle);

                // Actualizar el stock del producto
                producto.Can_Pro -= detalleDto.Can_Com;
                await _productoRepository.UpdateAsync(producto);
            }

            // Calcular IVA y total final
            decimal iva = subtotal * 0.15m; // 15% de IVA
            factura.Tot_Fac = subtotal + iva;

            Console.WriteLine($"📊 Subtotal: {subtotal}");
            Console.WriteLine($"📊 IVA (15%): {iva}");
            Console.WriteLine($"📊 Total Final: {factura.Tot_Fac}");

            // Guardar en base de datos
            await _repository.AddAsync(factura);

            // Mapear a DTO y retornar
            return _mapper.Map<FacturaDto>(factura);
        }

        public async Task<IEnumerable<FacturaDto>> GetByClienteAsync(string cedula)
        {
            var facturas = await _repository.GetByClienteAsync(cedula);
            return _mapper.Map<IEnumerable<FacturaDto>>(facturas);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}