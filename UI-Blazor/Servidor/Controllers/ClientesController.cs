using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Servidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtener todos los clientes
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAll()
        {
            try
            {
                var clientes = await _service.GetAllAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtener cliente por cédula
        /// </summary>
        [HttpGet("{cedula}")]
        public async Task<ActionResult<ClienteDto>> GetById(string cedula)
        {
            try
            {
                var cliente = await _service.GetByIdAsync(cedula);

                if (cliente == null)
                    return NotFound($"Cliente con cédula {cedula} no encontrado");

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Crear un nuevo cliente
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ClienteDto>> Create([FromBody] CreateClienteDto dto)
        {
            try
            {
                var cliente = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { cedula = cliente.Ced_Cli }, cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualizar cliente
        /// </summary>
        [HttpPut("{cedula}")]
        public async Task<IActionResult> Update(string cedula, [FromBody] UpdateClienteDto dto)
        {
            try
            {
                await _service.UpdateAsync(cedula, dto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Eliminar cliente
        /// </summary>
        [HttpDelete("{cedula}")]
        public async Task<IActionResult> Delete(string cedula)
        {
            try
            {
                await _service.DeleteAsync(cedula);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Buscar clientes por nombre
        /// </summary>
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> Search([FromQuery] string nombre)
        {
            try
            {
                var clientes = await _service.SearchByNameAsync(nombre);
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}