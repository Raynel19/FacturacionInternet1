using FacturacionInternet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FacturacionInternet.Infrastructure;

public class FacturacionContextFactory : IDesignTimeDbContextFactory<FacturacionContext>
{
    public FacturacionContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FacturacionContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;Database=FacturacionInternetDB;Trusted_Connection=True;TrustServerCertificate=True;");

        return new FacturacionContext(optionsBuilder.Options);
    }
}