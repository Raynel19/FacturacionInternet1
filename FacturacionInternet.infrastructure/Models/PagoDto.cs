namespace FacturacionInternet.Infrastructure.Models;

public class PagoDto
{
    public int Id { get; set; }
    public int FacturaId { get; set; }
    public decimal Monto { get; set; }
    public DateTime FechaPago { get; set; }
    public string Metodo { get; set; } = string.Empty;
}