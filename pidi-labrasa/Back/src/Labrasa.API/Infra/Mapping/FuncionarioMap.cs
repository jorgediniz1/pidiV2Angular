using Labrasa.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labrasa.API.Infra.Mapping
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("tb_funcionarios");
                         
            builder.Property(x => x.Departamento).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            builder.Property(x => x.Cpf).HasColumnType("nvarchar").IsRequired().HasMaxLength(15);
            builder.Property(x => x.Sexo).HasColumnType("nvarchar").IsRequired().HasMaxLength(15);      
            builder.Property(x => x.Endereco).HasColumnType("nvarchar").IsRequired().HasMaxLength(200);         
           
        }
    }
}