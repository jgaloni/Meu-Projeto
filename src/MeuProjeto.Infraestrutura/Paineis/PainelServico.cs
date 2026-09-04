using System.Data;
using Dapper;
using MeuProjeto.Aplicacao.Paineis;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MeuProjeto.Infraestrutura.Paineis;

public class PainelServico : IPainelServico
{
    private readonly string _connectionString;

    public PainelServico(IConfiguration configuracao)
    {
        var connectionString = configuracao.GetConnectionString("MeuProjetoDb");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("A configuração de conexão com o banco não foi definida.");
        }

        _connectionString = connectionString;
    }

    public async Task<PainelDto> ObterAsync()
    {
        using IDbConnection conexao = new NpgsqlConnection(_connectionString);

        var totalAnotacoes = await conexao.QuerySingleAsync<int>(
            "SELECT COUNT(*) FROM \"Anotacoes\"");

        var totalCategorias = await conexao.QuerySingleAsync<int>(
            "SELECT COUNT(*) FROM \"Categorias\"");

        var anotacoesSemCategoria = await conexao.QuerySingleAsync<int>(
            "SELECT COUNT(*) FROM \"Anotacoes\" WHERE \"CategoriaId\" IS NULL");

        var anotacoesPorCategoria = await conexao.QueryAsync<ContagemPorCategoriaDto>(
            @"SELECT c.""Nome"", COUNT(a.""Id"")::int AS ""Quantidade""
              FROM ""Categorias"" c
              LEFT JOIN ""Anotacoes"" a ON a.""CategoriaId"" = c.""Id""
              GROUP BY c.""Nome""
              ORDER BY ""Quantidade"" DESC");

        return new PainelDto(totalAnotacoes, totalCategorias, anotacoesSemCategoria, anotacoesPorCategoria.ToList());
    }
}
