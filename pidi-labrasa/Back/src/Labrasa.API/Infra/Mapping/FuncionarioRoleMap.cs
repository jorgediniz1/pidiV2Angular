using Labrasa.API.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labrasa.API.Infra.Mapping
{
    public class FuncionarioRoleMap : IEntityTypeConfiguration<FuncionarioRole>
    {
        public void Configure(EntityTypeBuilder<FuncionarioRole> builder)
        {

            builder.HasKey(fr => new { fr.UserId, fr.RoleId });

            builder.HasOne(fr => fr.Role)
                    .WithMany(r => r.FuncionarioRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

            builder.HasOne(fr => fr.Funcionario)
                   .WithMany(r => r.FuncionarioRoles)
                   .HasForeignKey(ur => ur.UserId)
                   .IsRequired();

        }
    }
}
