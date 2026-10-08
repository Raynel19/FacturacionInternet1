namespace FacturacionInternet.Infrastructure.Models;

public class PlanInternetDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int VelocidadMbps { get; set; }
    public decimal PrecioMensual { get; set; }
    public bool Activo { get; set; } = true;
}