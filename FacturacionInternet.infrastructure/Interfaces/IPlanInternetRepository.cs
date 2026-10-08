using FacturacionInternet.Domain.Entities;

namespace FacturacionInternet.Infrastructure.Interfaces
{
    public interface IPlanInternetRepository
    {
        Task<List<PlanInternet>> GetAllAsync();
        Task<PlanInternet?> GetByIdAsync(int id);
        Task<PlanInternet> AddAsync(PlanInternet plan);
        Task UpdateAsync(PlanInternet plan);
        Task DeleteAsync(PlanInternet plan);

        Task<bool> HasClientesAsync(int planId);
    }
}



