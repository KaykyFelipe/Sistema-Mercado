using Microsoft.EntityFrameworkCore;
using SistemaPadaria.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaPadaria.Configuration
{

    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
                        builder.ToTable("Produtos");
                        builder.HasKey(p => p.CodigoBarras);
                        builder.Property(p => p.Nome).HasColumnType("VARCHAR(25)").IsRequired();
                        builder.Property(p => p.Valor).IsRequired();
                        builder.Property(p => p.MedidaProduto).HasConversion<string>(); //O Tipo produto é informada como uma String
                        builder.Property(p => p.Descricao).HasColumnType("VARCHAR(150)").IsRequired(false);
        }
    }
}