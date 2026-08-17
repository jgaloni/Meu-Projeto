namespace MeuProjeto.Dominio.Anotacoes;

public interface IAnotacaoRepositorio
{
    Task<Anotacao?> ObterPorIdAsync(int id);
    Task<IEnumerable<Anotacao>> ObterTodasAsync();
    Task AdicionarAsync(Anotacao anotacao);
    void Remover(Anotacao anotacao);
    Task SalvarAlteracoesAsync();
}
