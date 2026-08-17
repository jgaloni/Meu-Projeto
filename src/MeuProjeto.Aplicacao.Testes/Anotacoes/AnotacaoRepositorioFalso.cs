using MeuProjeto.Dominio.Anotacoes;

namespace MeuProjeto.Aplicacao.Testes.Anotacoes;

public class AnotacaoRepositorioFalso : IAnotacaoRepositorio
{
    private readonly List<Anotacao> _anotacoes = new List<Anotacao>();

    public Task<Anotacao?> ObterPorIdAsync(int id) =>
        Task.FromResult(_anotacoes.FirstOrDefault(a => a.Id == id));

    public Task<IEnumerable<Anotacao>> ObterTodasAsync() =>
        Task.FromResult<IEnumerable<Anotacao>>(_anotacoes);

    public Task AdicionarAsync(Anotacao anotacao)
    {
        _anotacoes.Add(anotacao);
        return Task.CompletedTask;
    }

    public void Remover(Anotacao anotacao) =>
        _anotacoes.Remove(anotacao);

    public Task SalvarAlteracoesAsync() =>
        Task.CompletedTask;
}
