using SistemaPadaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;


namespace SistemaPadaria.Configuration
{


 public class BancoContext : DbContext     
    {

          public DbSet<ProdutoModel> Produtos { get; set; } 

        // private static readonly ILoggerFactory _logger = LoggerFactory.Create(p=>p.AddConsole()); //log das querys

       public BancoContext(DbContextOptions<BancoContext> options)
        : base(options)
    {
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BancoContext).Assembly);

        }
    }
}