using Microsoft.EntityFrameworkCore;
using SistemaPadaria.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Configuration
{

    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
                        builder.ToTable("Produtos");
                        builder.HasKey(p => p.CodigoBarras);
                        builder.Property(p => p.Nome).HasColumnType("VARCHAR(25)").IsRequired();
                        builder.Property(p => p.Valor).IsRequired();
                        builder.Property(p => p.MedidaProduto).HasConversion<string>(); //O Tipo produto é informada como uma String
                        builder.Property(p => p.Descricao).HasColumnType("VARCHAR(150)");
        }
    }
}