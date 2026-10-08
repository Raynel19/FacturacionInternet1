using FacturacionInternet.Domain.Entities;
using FacturacionInternet.Infrastructure.Context;
using FacturacionInternet.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FacturacionInternet.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly FacturacionContext _context;

    public ClienteRepository(FacturacionContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
            .Include(c => c.PlanInternet)
            .ToListAsync();
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await _context.Clientes
            .Include(c => c.PlanInternet)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Cliente?> GetByCedulaAsync(string cedula)
    {
        return await _context.Clientes.FirstOrDefaultAsync(c => c.Cedula == cedula);
    }

    public async Task<Cliente> AddAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task UpdateAsync(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Cliente cliente)
    {
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
    }
}