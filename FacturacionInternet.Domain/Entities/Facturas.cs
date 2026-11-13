using FacturacionInternet.Domain.Core;

namespace FacturacionInternet.Domain.Entities;

public class Factura : BaseEntity
{
    public int ClienteId { get; set; }
    public decimal Monto { get; set; }
    public DateTime FechaEmision { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public string Estado { get; set; } = "Pendiente";

    public Cliente? Cliente { get; set; }
    public List<Pago> Pagos { get; set; } = new();
}