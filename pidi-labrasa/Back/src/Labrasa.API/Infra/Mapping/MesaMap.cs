using Labrasa.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labrasa.API.Infra.Mapping
{
    public class MesaMap : IEntityTypeConfiguration<Mesa>
    {
        public void Configure(EntityTypeBuilder<Mesa> builder)
        {
            builder.ToTable("tb_mesas");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.NumeroMesa).HasColumnType("nvarchar").HasColumnName("numero_mesa").HasMaxLength(2);
            builder.Property(x => x.ComandasAbertas).HasColumnType("nvarchar").HasColumnName("comandas_abertas").HasMaxLength(2);
            builder.Property(x => x.ComandasFechadas).HasColumnType("nvarchar").HasColumnName("comandas_fechadas").HasMaxLength(2);


            builder.HasMany(x => x.Comandas).WithOne(x => x.Mesa).HasForeignKey(x => x.MesaId);

        }
    }
}
