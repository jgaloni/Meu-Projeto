using MeuProjeto.Dominio.Categorias;
using MeuProjeto.Infraestrutura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace MeuProjeto.Infraestrutura.Categorias;

public class CategoriaRepositorio : ICategoriaRepositorio
{
    private readonly MeuProjetoDbContext _contexto;

    public CategoriaRepositorio(MeuProjetoDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<IEnumerable<Categoria>> ObterTodasAsync() =>
        await _contexto.Categorias
            .OrderBy(c => c.Nome)
            .ToListAsync();

    public async Task<Categoria?> ObterPorIdAsync(int id) =>
        await _contexto.Categorias.FindAsync(id);

    public async Task AdicionarAsync(Categoria categoria) =>
        await _contexto.Categorias.AddAsync(categoria);

    public void Remover(Categoria categoria) =>
        _contexto.Categorias.Remove(categoria);

    public async Task SalvarAlteracoesAsync() =>
        await _contexto.SaveChangesAsync();
}
