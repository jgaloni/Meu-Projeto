namespace MeuProjeto.Aplicacao.Paineis;

public interface IPainelServico
{
    Task<PainelDto> ObterAsync();
}
