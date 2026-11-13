using FacturacionInternet.Domain.Entities;
using FacturacionInternet.Infrastructure.Context;
using FacturacionInternet.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FacturacionInternet.Infrastructure.Repositories;

public class PagoRepository : IPagoRepository
{
    private readonly FacturacionContext _context;

    public PagoRepository(FacturacionContext context)
    {
        _context = context;
    }

    public async Task<List<Pago>> GetAllAsync()
    {
        return await _context.Pagos
            .Include(p => p.Factura)
            .ToListAsync();
    }

    public async Task<Pago?> GetByIdAsync(int id)
    {
        return await _context.Pagos
            .Include(p => p.Factura)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Pago>> GetByFacturaAsync(int facturaId)
    {
        return await _context.Pagos
            .Where(p => p.FacturaId == facturaId)
            .ToListAsync();
    }

    public async Task<Pago> AddAsync(Pago pago)
    {
        _context.Pagos.Add(pago);
        await _context.SaveChangesAsync();
        return pago;
    }

    public async Task UpdateAsync(Pago pago)
    {
        _context.Pagos.Update(pago);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Pago pago)
    {
        _context.Pagos.Remove(pago);
        await _context.SaveChangesAsync();
    }
}