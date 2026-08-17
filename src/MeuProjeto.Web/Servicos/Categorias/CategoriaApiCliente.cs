using System.Net.Http.Json;
using MeuProjeto.Aplicacao.Categorias;

namespace MeuProjeto.Web.Servicos.Categorias;

public class CategoriaApiCliente : ICategoriaApiCliente
{
    private const string CaminhoBase = "api/categorias";
    private readonly HttpClient _httpClient;

    public CategoriaApiCliente(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<CategoriaDto>> ObterTodasAsync()
    {
        var categorias = await _httpClient.GetFromJsonAsync<List<CategoriaDto>>(CaminhoBase);

        if (categorias is null)
        {
            return new List<CategoriaDto>();
        }

        return categorias;
    }

    public async Task<CategoriaDto?> CriarAsync(CriarCategoriaDto dto)
    {
        var resposta = await _httpClient.PostAsJsonAsync(CaminhoBase, dto);

        if (!resposta.IsSuccessStatusCode)
        {
            return null;
        }

        return await resposta.Content.ReadFromJsonAsync<CategoriaDto>();
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var resposta = await _httpClient.DeleteAsync($"{CaminhoBase}/{id}");
        return resposta.IsSuccessStatusCode;
    }
}
