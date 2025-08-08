using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Data.Repository.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            // Copie exatamente como está no Program.cs
            var connectionString = "Server=localhost\\SQLEXPRESS;Database=ApiRestFurb;User Id=sa;Password=12345678;TrustServerCertificate=True;Encrypt=False;";

            optionsBuilder.UseSqlServer(connectionString);

            return new DataContext(optionsBuilder.Options);
        }
    }
}