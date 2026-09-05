using MeuProjeto.Web.Servicos.Anotacoes;
using MeuProjeto.Web.Servicos.Categorias;
using MeuProjeto.Web.Servicos.Paineis;
using Microsoft.Extensions.DependencyInjection;

namespace MeuProjeto.Web;

public static class InjecaoDependenciaWeb
{
    public static IServiceCollection AdicionarClientesApi(this IServiceCollection servicos, string apiBaseUrl)
    {
        servicos.AddHttpClient<IAnotacaoApiCliente, AnotacaoApiCliente>(cliente =>
        {
            cliente.BaseAddress = new Uri(apiBaseUrl);
        });

        servicos.AddHttpClient<ICategoriaApiCliente, CategoriaApiCliente>(cliente =>
        {
            cliente.BaseAddress = new Uri(apiBaseUrl);
        });

        servicos.AddHttpClient<IPainelApiCliente, PainelApiCliente>(cliente =>
        {
            cliente.BaseAddress = new Uri(apiBaseUrl);
        });

        return servicos;
    }
}
