using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Domain;
using Core.Interfaces;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var clientes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClienteDto>>(clientes);
        }

        public async Task<ClienteDto?> GetByIdAsync(string cedula)
        {
            var cliente = await _repository.GetByCedulaAsync(cedula);
            return _mapper.Map<ClienteDto>(cliente);
        }

        public async Task<ClienteDto> CreateAsync(CreateClienteDto dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);
            var created = await _repository.AddAsync(cliente);
            return _mapper.Map<ClienteDto>(created);
        }

        public async Task UpdateAsync(string cedula, UpdateClienteDto dto)
        {
            var cliente = await _repository.GetByCedulaAsync(cedula);
            if (cliente == null)
                throw new KeyNotFoundException($"Cliente con cédula {cedula} no encontrado");

            _mapper.Map(dto, cliente);
            await _repository.UpdateAsync(cliente);
        }

        public async Task DeleteAsync(string cedula)
        {
            await _repository.DeleteAsync(cedula);
        }

        public async Task<IEnumerable<ClienteDto>> SearchByNameAsync(string nombre)
        {
            var clientes = await _repository.SearchByNameAsync(nombre);
            return _mapper.Map<IEnumerable<ClienteDto>>(clientes);
        }
    }
}   