using FacturacionInternet.Domain.Entities;
using FacturacionInternet.Infrastructure.Context;
using FacturacionInternet.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FacturacionInternet.Infrastructure.Repositories;

public class FacturaRepository : IFacturaRepository
{
    private readonly FacturacionContext _context;

    public FacturaRepository(FacturacionContext context)
    {
        _context = context;
    }

    public async Task<List<Factura>> GetAllAsync()
    {
        return await _context.Facturas
            .Include(f => f.Cliente)
            .Include(f => f.Pagos)
            .ToListAsync();
    }

    public async Task<Factura?> GetByIdAsync(int id)
    {
        return await _context.Facturas
            .Include(f => f.Cliente)
            .Include(f => f.Pagos)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<List<Factura>> GetByClienteAsync(int clienteId)
    {
        return await _context.Facturas
            .Include(f => f.Pagos)
            .Where(f => f.ClienteId == clienteId)
            .ToListAsync();
    }

    public async Task<Factura> AddAsync(Factura factura)
    {
        _context.Facturas.Add(factura);
        await _context.SaveChangesAsync();
        return factura;
    }

    public async Task UpdateAsync(Factura factura)
    {
        _context.Facturas.Update(factura);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Factura factura)
    {
        _context.Facturas.Remove(factura);
        await _context.SaveChangesAsync();
    }
}