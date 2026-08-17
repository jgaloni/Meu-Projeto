using System.Net.Http.Json;
using MeuProjeto.Aplicacao.Anotacoes;

namespace MeuProjeto.Web.Servicos.Anotacoes;

public class AnotacaoApiCliente : IAnotacaoApiCliente
{
    private const string CaminhoBase = "api/anotacoes";
    private readonly HttpClient _httpClient;

    public AnotacaoApiCliente(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<AnotacaoDto>> ObterTodasAsync()
    {
        var anotacoes = await _httpClient.GetFromJsonAsync<List<AnotacaoDto>>(CaminhoBase);

        if (anotacoes is null)
        {
            return new List<AnotacaoDto>();
        }

        return anotacoes;
    }

    public async Task<AnotacaoDto?> CriarAsync(CriarAnotacaoDto dto)
    {
        var resposta = await _httpClient.PostAsJsonAsync(CaminhoBase, dto);

        if (!resposta.IsSuccessStatusCode)
        {
            return null;
        }

        return await resposta.Content.ReadFromJsonAsync<AnotacaoDto>();
    }

    public async Task<AnotacaoDto?> AtualizarAsync(int id, AtualizarAnotacaoDto dto)
    {
        var resposta = await _httpClient.PutAsJsonAsync($"{CaminhoBase}/{id}", dto);

        if (!resposta.IsSuccessStatusCode)
        {
            return null;
        }

        return await resposta.Content.ReadFromJsonAsync<AnotacaoDto>();
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var resposta = await _httpClient.DeleteAsync($"{CaminhoBase}/{id}");
        return resposta.IsSuccessStatusCode;
    }
}
