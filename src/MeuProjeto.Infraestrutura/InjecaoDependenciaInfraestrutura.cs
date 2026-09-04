using MeuProjeto.Aplicacao.Paineis;
using MeuProjeto.Dominio.Anotacoes;
using MeuProjeto.Dominio.Categorias;
using MeuProjeto.Infraestrutura.Persistencia;
using MeuProjeto.Infraestrutura.Anotacoes;
using MeuProjeto.Infraestrutura.Categorias;
using MeuProjeto.Infraestrutura.Paineis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeuProjeto.Infraestrutura;

public static class InjecaoDependenciaInfraestrutura
{
    public static IServiceCollection AdicionarInfraestrutura(this IServiceCollection servicos, IConfiguration configuracao)
    {
        var connectionString = configuracao.GetConnectionString("MeuProjetoDb");

        servicos.AddDbContext<MeuProjetoDbContext>(options =>
            options.UseNpgsql(connectionString));

        servicos.AddScoped<IAnotacaoRepositorio, AnotacaoRepositorio>();
        servicos.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
        servicos.AddScoped<IPainelServico, PainelServico>();

        return servicos;
    }
}
