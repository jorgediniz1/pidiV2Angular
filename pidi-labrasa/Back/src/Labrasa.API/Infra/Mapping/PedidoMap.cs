using Labrasa.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labrasa.API.Infra.Mapping
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {

            builder.ToTable("tb_pedidos");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.ValorPedido).HasColumnName("valor_pedido").HasColumnType("money");
            builder.Property(x => x.DataHoraPedido).HasColumnName("data_pedido").HasColumnType("date");

            builder.HasMany(x => x.Produtos)
                    .WithMany(x => x.Pedidos)
                    .UsingEntity<ProdutoPedido>(
                    x => x.HasOne(pp => pp.Produto).WithMany().HasForeignKey(x => x.ProdutoId),
                    x => x.HasOne(pp => pp.Pedido).WithMany().HasForeignKey(x => x.PedidoId),
                    x =>
                    {
                        x.ToTable("tb_produto_pedido");

                        x.HasKey(x => new { x.ProdutoId, x.PedidoId });

                        x.Property(x => x.ProdutoId).HasColumnName("produto_id").IsRequired();
                        x.Property(x => x.PedidoId).HasColumnName("pedido_id").IsRequired();
                    });
        }
    }
}
