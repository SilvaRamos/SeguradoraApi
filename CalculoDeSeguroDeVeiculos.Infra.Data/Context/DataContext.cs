using CalculoDeSeguroDeVeiculos.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculoDeSeguroDeVeiculos.Infra.Data.Context

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {            
        }

        public DbSet<SeguroModel> Seguros { get; set; }
    }
}
