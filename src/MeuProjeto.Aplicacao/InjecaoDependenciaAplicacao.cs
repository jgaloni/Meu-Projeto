using MeuProjeto.Aplicacao.Anotacoes;
using MeuProjeto.Aplicacao.Categorias;
using Microsoft.Extensions.DependencyInjection;

namespace MeuProjeto.Aplicacao;

public static class InjecaoDependenciaAplicacao
{
    public static IServiceCollection AdicionarAplicacao(this IServiceCollection servicos)
    {
        servicos.AddScoped<IAnotacaoServico, AnotacaoServico>();
        servicos.AddScoped<ICategoriaServico, CategoriaServico>();

        return servicos;
    }
}
