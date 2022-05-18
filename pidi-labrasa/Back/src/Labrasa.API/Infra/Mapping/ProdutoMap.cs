using Labrasa.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labrasa.API.Infra.Mapping
{

    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.ToTable("tb_produtos");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnType("nvarchar").HasColumnName("produtos").HasMaxLength(50);
            builder.Property(x => x.Categoria).HasColumnType("nvarchar").HasColumnName("categoria").HasMaxLength(10);
            builder.Property(x => x.QuantidadeEstoque).HasColumnType("numeric").HasColumnName("quantidade_estoque");
            builder.Property(x => x.QuantidadeMinima).HasColumnType("numeric").HasColumnName("quantidade_minima");
            builder.Property(x => x.PrecoCusto).HasColumnType("numeric(38,2)").HasColumnName("preco_custo");
            builder.Property(x => x.PrecoVenda).HasColumnType("numeric(38,2)").HasColumnName("preco_venda");
        }
    }
}