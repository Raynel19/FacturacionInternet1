
using FacturacionInternet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacturacionInternet.Infrastructure.Context;

public class FacturacionContext : DbContext
{
    public FacturacionContext(DbContextOptions<FacturacionContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<PlanInternet> Planes { get; set; }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<Pago> Pagos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PlanInternet>()
            .Property(p => p.PrecioMensual)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Cliente>()
            .HasIndex(c => c.Cedula)
            .IsUnique();

        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.PlanInternet)
            .WithMany()
            .HasForeignKey(c => c.PlanInternetId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Factura>()
            .Property(f => f.Monto)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Factura>()
            .HasOne(f => f.Cliente)
            .WithMany()
            .HasForeignKey(f => f.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Pago>()
            .Property(p => p.Monto)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Pago>()
            .HasOne(p => p.Factura)
            .WithMany(f => f.Pagos)
            .HasForeignKey(p => p.FacturaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
