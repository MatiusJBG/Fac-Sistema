using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Domain;
using Core.Interfaces;

namespace Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductoDto>> GetAllAsync()
        {
            var productos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductoDto>>(productos);
        }

        public async Task<ProductoDto?> GetByIdAsync(int id)
        {
            var producto = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductoDto>(producto);
        }

        public async Task<ProductoDto> CreateAsync(CreateProductoDto dto)
        {
            var producto = _mapper.Map<Producto>(dto);
            var created = await _repository.AddAsync(producto);
            return _mapper.Map<ProductoDto>(created);
        }

        public async Task UpdateAsync(int id, UpdateProductoDto dto)
        {
            var producto = await _repository.GetByIdAsync(id);
            if (producto == null)
                throw new KeyNotFoundException($"Producto con ID {id} no encontrado");

            _mapper.Map(dto, producto);
            await _repository.UpdateAsync(producto);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductoDto>> GetDisponiblesAsync()
        {
            var productos = await _repository.GetProductosDisponiblesAsync();
            return _mapper.Map<IEnumerable<ProductoDto>>(productos);
        }
    }
}