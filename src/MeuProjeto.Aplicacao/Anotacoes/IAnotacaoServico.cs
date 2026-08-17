namespace MeuProjeto.Aplicacao.Anotacoes;

public interface IAnotacaoServico
{
    Task<IEnumerable<AnotacaoDto>> ObterTodasAsync();
    Task<AnotacaoDto?> ObterPorIdAsync(int id);
    Task<AnotacaoDto> CriarAsync(CriarAnotacaoDto dto);
    Task<AnotacaoDto?> AtualizarAsync(int id, AtualizarAnotacaoDto dto);
    Task<bool> RemoverAsync(int id);
}
