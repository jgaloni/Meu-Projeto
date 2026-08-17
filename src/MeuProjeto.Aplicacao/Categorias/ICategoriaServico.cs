namespace MeuProjeto.Aplicacao.Categorias;

public interface ICategoriaServico
{
    Task<IEnumerable<CategoriaDto>> ObterTodasAsync();
    Task<CategoriaDto> CriarAsync(CriarCategoriaDto dto);
    Task<bool> RemoverAsync(int id);
}
