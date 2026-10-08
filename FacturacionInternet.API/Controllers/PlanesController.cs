using FacturacionInternet.Domain.Entities;
using FacturacionInternet.Infrastructure.Interfaces;
using FacturacionInternet.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionInternet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlanesController : ControllerBase
{
    private readonly IPlanInternetRepository _repository;

    public PlanesController(IPlanInternetRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<PlanInternetDto>>> GetAll()
    {
        var planes = await _repository.GetAllAsync();

        return planes.Select(p => new PlanInternetDto
        {
            Id = p.Id,
            Nombre = p.Nombre,
            VelocidadMbps = p.VelocidadMbps,
            PrecioMensual = p.PrecioMensual,
            Activo = p.Activo
        }).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlanInternetDto>> GetById(int id)
    {
        var plan = await _repository.GetByIdAsync(id);
        if (plan == null)
            return NotFound("Plan no encontrado");

        return new PlanInternetDto
        {
            Id = plan.Id,
            Nombre = plan.Nombre,
            VelocidadMbps = plan.VelocidadMbps,
            PrecioMensual = plan.PrecioMensual,
            Activo = plan.Activo
        };
    }

    [HttpPost]
    public async Task<ActionResult<PlanInternetDto>> Create(PlanInternetDto dto)
    {
        if (dto.PrecioMensual <= 0)
            return BadRequest("El precio debe ser mayor que 0");

        var plan = new PlanInternet
        {
            Nombre = dto.Nombre,
            VelocidadMbps = dto.VelocidadMbps,
            PrecioMensual = dto.PrecioMensual,
            Activo = dto.Activo
        };

        await _repository.AddAsync(plan);
        dto.Id = plan.Id;

        return CreatedAtAction(nameof(GetById), new { id = plan.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, PlanInternetDto dto)
    {
        var plan = await _repository.GetByIdAsync(id);
        if (plan == null)
            return NotFound("Plan no encontrado");

        if (dto.PrecioMensual <= 0)
            return BadRequest("El precio debe ser mayor que 0");

        plan.Nombre = dto.Nombre;
        plan.VelocidadMbps = dto.VelocidadMbps;
        plan.PrecioMensual = dto.PrecioMensual;
        plan.Activo = dto.Activo;

        await _repository.UpdateAsync(plan);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var plan = await _repository.GetByIdAsync(id);
        if (plan == null)
            return NotFound("Plan no encontrado");

        if (await _repository.HasClientesAsync(id))
            return BadRequest("No se puede eliminar un plan que tiene clientes");

        await _repository.DeleteAsync(plan);
        return NoContent();
    }
}