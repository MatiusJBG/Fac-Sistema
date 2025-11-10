using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Servidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturaService _service;

        public FacturasController(IFacturaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtener todas las facturas
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaDto>>> GetAll()
        {
            try
            {
                var facturas = await _service.GetAllAsync();
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtener factura por ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaDto>> GetById(int id)
        {
            try
            {
                var factura = await _service.GetByIdAsync(id);
                if (factura == null)
                    return NotFound($"Factura con ID {id} no encontrada");

                return Ok(factura);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Crear nueva factura
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<FacturaDto>> Create([FromBody] CreateFacturaDto dto)
        {
            try
            {
                if (dto.Detalles == null || dto.Detalles.Count == 0)
                    return BadRequest("La factura debe tener al menos un detalle");

                var factura = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = factura.Id_Fac }, factura);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtener facturas por cliente
        /// </summary>
        [HttpGet("cliente/{cedula}")]
        public async Task<ActionResult<IEnumerable<FacturaDto>>> GetByCliente(string cedula)
        {
            try
            {
                var facturas = await _service.GetByClienteAsync(cedula);
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}