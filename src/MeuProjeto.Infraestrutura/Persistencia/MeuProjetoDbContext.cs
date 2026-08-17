using MeuProjeto.Dominio.Anotacoes;
using MeuProjeto.Dominio.Categorias;
using MeuProjeto.Infraestrutura.Anotacoes;
using MeuProjeto.Infraestrutura.Categorias;
using Microsoft.EntityFrameworkCore;

namespace MeuProjeto.Infraestrutura.Persistencia;

public class MeuProjetoDbContext : DbContext
{
    public MeuProjetoDbContext(DbContextOptions<MeuProjetoDbContext> options) : base(options)
    {
    }

    public DbSet<Anotacao> Anotacoes => Set<Anotacao>();
    public DbSet<Categoria> Categorias => Set<Categoria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AnotacaoConfiguracao());
        modelBuilder.ApplyConfiguration(new CategoriaConfiguracao());
    }
}
