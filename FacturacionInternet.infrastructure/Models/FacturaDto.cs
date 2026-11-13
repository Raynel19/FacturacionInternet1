namespace FacturacionInternet.Infrastructure.Models;

public class FacturaDto
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public decimal Monto { get; set; }
    public DateTime FechaEmision { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public string Estado { get; set; } = string.Empty;
    public string? ClienteNombre { get; set; }
}