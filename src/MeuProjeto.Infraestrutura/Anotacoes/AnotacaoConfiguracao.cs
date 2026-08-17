using MeuProjeto.Dominio.Anotacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuProjeto.Infraestrutura.Anotacoes;

public class AnotacaoConfiguracao : IEntityTypeConfiguration<Anotacao>
{
    public void Configure(EntityTypeBuilder<Anotacao> builder)
    {
        builder.ToTable("Anotacoes");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Titulo)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(a => a.Conteudo)
            .IsRequired()
            .HasMaxLength(4000);

        builder.Property(a => a.DataCriacao)
            .IsRequired();

        builder.HasOne(a => a.Categoria)
            .WithMany()
            .HasForeignKey(a => a.CategoriaId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
