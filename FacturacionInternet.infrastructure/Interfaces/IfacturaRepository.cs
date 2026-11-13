
using FacturacionInternet.Domain.Entities;

namespace FacturacionInternet.Infrastructure.Interfaces;

public interface IFacturaRepository
{
    Task<List<Factura>> GetAllAsync();
    Task<Factura?> GetByIdAsync(int id);
    Task<List<Factura>> GetByClienteAsync(int clienteId);
    Task<Factura> AddAsync(Factura factura);
    Task UpdateAsync(Factura factura);
    Task DeleteAsync(Factura factura);
}
