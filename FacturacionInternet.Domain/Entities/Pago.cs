using FacturacionInternet.Domain.Core;

namespace FacturacionInternet.Domain.Entities;

public class Pago : BaseEntity
{
    public int FacturaId { get; set; }
    public decimal Monto { get; set; }
    public DateTime FechaPago { get; set; }
    public string Metodo { get; set; } = "";

    public Factura? Factura { get; set; }
}