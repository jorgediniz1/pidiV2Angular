using Labrasa.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labrasa.API.Infra.Mapping
{
    public class ComandaMap : IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            builder.ToTable("tb_comandas");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.ValorTotal).HasColumnType("numeric(38,2)");
            builder.Property(x => x.DataHoraAbertura).HasColumnType("datetime");
            builder.Property(x => x.DataHoraFechamento).HasColumnType("datetime");
            builder.Property(x => x.StatusComanda).HasColumnType("nvarchar(20)");
            

            builder.HasOne(x => x.Mesa).WithMany(x => x.Comandas).HasForeignKey(x => x.MesaId);

        }
    }
}
