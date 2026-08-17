using MeuProjeto.Dominio.Anotacoes;
using MeuProjeto.Infraestrutura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace MeuProjeto.Infraestrutura.Anotacoes;

public class AnotacaoRepositorio : IAnotacaoRepositorio
{
    private readonly MeuProjetoDbContext _contexto;

    public AnotacaoRepositorio(MeuProjetoDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<Anotacao?> ObterPorIdAsync(int id) =>
        await _contexto.Anotacoes
            .Include(a => a.Categoria)
            .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<IEnumerable<Anotacao>> ObterTodasAsync() =>
        await _contexto.Anotacoes
            .Include(a => a.Categoria)
            .OrderByDescending(a => a.DataCriacao)
            .ToListAsync();

    public async Task AdicionarAsync(Anotacao anotacao) =>
        await _contexto.Anotacoes.AddAsync(anotacao);

    public void Remover(Anotacao anotacao) =>
        _contexto.Anotacoes.Remove(anotacao);

    public async Task SalvarAlteracoesAsync() =>
        await _contexto.SaveChangesAsync();
}
