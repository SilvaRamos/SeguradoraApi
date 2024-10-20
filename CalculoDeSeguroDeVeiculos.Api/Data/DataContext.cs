using CalculoDeSeguroDeVeiculos.Api.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CalculoDeSeguroDeVeiculos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {            
        }

        public DbSet<SeguroModel> Seguros { get; set; }
    }
}
