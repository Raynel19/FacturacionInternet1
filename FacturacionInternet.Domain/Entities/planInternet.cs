namespace FacturacionInternet.Domain.Entities;

public class PlanInternet
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int VelocidadMbps { get; set; }
    public decimal PrecioMensual { get; set; }
    public bool Activo { get; set; } = true;

    // Esto lo comento porque parece que el Cliente ahora está en otro lado
    // public List<Cliente> Clientes { get; set; } = new();
}