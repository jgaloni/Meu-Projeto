using MeuProjeto.Aplicacao.Anotacoes;

namespace MeuProjeto.Web.Servicos.Anotacoes;

public interface IAnotacaoApiCliente
{
    Task<IReadOnlyList<AnotacaoDto>> ObterTodasAsync();
    Task<AnotacaoDto?> CriarAsync(CriarAnotacaoDto dto);
    Task<AnotacaoDto?> AtualizarAsync(int id, AtualizarAnotacaoDto dto);
    Task<bool> RemoverAsync(int id);
}
