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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlanInternet>()
            .Property(p => p.PrecioMensual)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Cliente>()
            .HasIndex(c => c.Cedula)
            .IsUnique();

        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.PlanInternet)
            .WithMany() // sin p => p.Clientes
            .HasForeignKey(c => c.PlanInternetId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}