using Capgemini.DTO;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Capgemini.Infra.Models.Mapping
{
    public class CadastroMap : EntityTypeConfiguration<CadastroDTO>
    {
        public CadastroMap()
        {
            // Primary Key
            this.HasKey(t => t.IdCadastro);

            // Properties
            this.Property(t => t.PrimeiroNome)
                .HasMaxLength(200);

            this.Property(t => t.UltimoNome)
                .HasMaxLength(200);

            this.Property(t => t.Cpf)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Senha)
                .HasMaxLength(100);

            this.Property(t => t.Sexo)
                .HasMaxLength(10);

            this.Property(t => t.Endereco)
                .HasMaxLength(200);

            this.Property(t => t.Rua)
                .HasMaxLength(200);

            this.Property(t => t.Numero)
                .HasMaxLength(100);

            this.Property(t => t.Complemento)
                .HasMaxLength(100);

            this.Property(t => t.Cep)
                .HasMaxLength(200);

            this.Property(t => t.Email)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Cadastro");
            this.Property(t => t.IdCadastro).HasColumnName("IdCadastro");
            this.Property(t => t.PrimeiroNome).HasColumnName("PrimeiroNome");
            this.Property(t => t.UltimoNome).HasColumnName("UltimoNome");
            this.Property(t => t.Cpf).HasColumnName("Cpf");
            this.Property(t => t.DataNascimento).HasColumnName("DataNascimento");
            this.Property(t => t.Senha).HasColumnName("Senha");
            this.Property(t => t.Sexo).HasColumnName("Sexo");
            this.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            this.Property(t => t.Endereco).HasColumnName("Endereco");
            this.Property(t => t.Rua).HasColumnName("Rua");
            this.Property(t => t.Numero).HasColumnName("Numero");
            this.Property(t => t.Complemento).HasColumnName("Complemento");
            this.Property(t => t.Cep).HasColumnName("Cep");
            this.Property(t => t.Email).HasColumnName("Email");
        }
    }
}
