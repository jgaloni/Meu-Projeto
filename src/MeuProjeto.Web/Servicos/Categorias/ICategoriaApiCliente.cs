using MeuProjeto.Aplicacao.Categorias;

namespace MeuProjeto.Web.Servicos.Categorias;

public interface ICategoriaApiCliente
{
    Task<IReadOnlyList<CategoriaDto>> ObterTodasAsync();
    Task<CategoriaDto?> CriarAsync(CriarCategoriaDto dto);
    Task<bool> RemoverAsync(int id);
}
