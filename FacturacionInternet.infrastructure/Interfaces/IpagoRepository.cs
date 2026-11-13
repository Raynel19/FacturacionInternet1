
using FacturacionInternet.Domain.Entities;

namespace FacturacionInternet.Infrastructure.Interfaces;

public interface IPagoRepository
{
    Task<List<Pago>> GetAllAsync();
    Task<Pago?> GetByIdAsync(int id);
    Task<List<Pago>> GetByFacturaAsync(int facturaId);
    Task<Pago> AddAsync(Pago pago);
    Task UpdateAsync(Pago pago);
    Task DeleteAsync(Pago pago);
}
