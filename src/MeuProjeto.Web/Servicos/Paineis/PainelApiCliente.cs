using System.Net.Http.Json;
using MeuProjeto.Aplicacao.Paineis;

namespace MeuProjeto.Web.Servicos.Paineis;

public class PainelApiCliente : IPainelApiCliente
{
    private const string CaminhoBase = "api/painel";
    private readonly HttpClient _httpClient;

    public PainelApiCliente(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PainelDto?> ObterAsync() =>
        await _httpClient.GetFromJsonAsync<PainelDto>(CaminhoBase);
}
