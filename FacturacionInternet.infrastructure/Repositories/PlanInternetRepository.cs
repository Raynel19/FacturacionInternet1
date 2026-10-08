using FacturacionInternet.Domain.Entities;
using FacturacionInternet.Infrastructure.Context;
using FacturacionInternet.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FacturacionInternet.Infrastructure.Repositories
{
    public class PlanInternetRepository : IPlanInternetRepository
    {
        private readonly FacturacionContext _context;

        public PlanInternetRepository(FacturacionContext context)
        {
            _context = context;
        }

        public async Task<List<PlanInternet>> GetAllAsync()
        {
            return await _context.Planes.ToListAsync();
        }

        public async Task<PlanInternet?> GetByIdAsync(int id)
        {
            return await _context.Planes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PlanInternet> AddAsync(PlanInternet plan)
        {
            _context.Planes.Add(plan);
            await _context.SaveChangesAsync();
            return plan;
        }

        public async Task UpdateAsync(PlanInternet plan)
        {
            _context.Planes.Update(plan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PlanInternet plan)
        {
            _context.Planes.Remove(plan);
            await _context.SaveChangesAsync();
        }

     
        public async Task<bool> HasClientesAsync(int planId)
        {
            return await _context.Clientes.AnyAsync(c => c.PlanInternetId == planId);
        }
    }
}
