using AutoMapper;
using Application.DTOs;
using Core.Domain;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Cliente
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<UpdateClienteDto, Cliente>();

            // Producto
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<CreateProductoDto, Producto>();
            CreateMap<UpdateProductoDto, Producto>();

            // Factura
            CreateMap<Factura, FacturaDto>();
            CreateMap<CreateFacturaDto, Factura>();

            // DetalleFactura
            CreateMap<DetalleFactura, DetalleFacturaDto>();
            CreateMap<CreateDetalleFacturaDto, DetalleFactura>();
        }
    }
}