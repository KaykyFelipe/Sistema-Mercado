using SystemMarket.Models;
using Microsoft.EntityFrameworkCore;



namespace SystemMarket.Configuration
{


 public class BancoContext : DbContext     
    {

        // private static readonly ILoggerFactory _logger = LoggerFactory.Create(p=>p.AddConsole()); //log das querys

       public BancoContext(DbContextOptions<BancoContext> options)
        : base(options)
    {
    }

        public DbSet<ProdutoModel> Produtos { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BancoContext).Assembly);

        }
    }
}