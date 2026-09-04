using MeuProjeto.Aplicacao.Paineis;

namespace MeuProjeto.Web.Servicos.Paineis;

public interface IPainelApiCliente
{
    Task<PainelDto?> ObterAsync();
}
