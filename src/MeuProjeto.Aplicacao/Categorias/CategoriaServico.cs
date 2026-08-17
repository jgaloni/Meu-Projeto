using MeuProjeto.Dominio.Categorias;

namespace MeuProjeto.Aplicacao.Categorias;

public class CategoriaServico : ICategoriaServico
{
    private readonly ICategoriaRepositorio _categoriaRepositorio;

    public CategoriaServico(ICategoriaRepositorio categoriaRepositorio)
    {
        _categoriaRepositorio = categoriaRepositorio;
    }

    public async Task<IEnumerable<CategoriaDto>> ObterTodasAsync()
    {
        var categorias = await _categoriaRepositorio.ObterTodasAsync();
        return categorias.Select(ParaDto);
    }

    public async Task<CategoriaDto> CriarAsync(CriarCategoriaDto dto)
    {
        var categoria = new Categoria(dto.Nome);

        await _categoriaRepositorio.AdicionarAsync(categoria);
        await _categoriaRepositorio.SalvarAlteracoesAsync();

        return ParaDto(categoria);
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var categoria = await _categoriaRepositorio.ObterPorIdAsync(id);

        if (categoria is null)
        {
            return false;
        }

        _categoriaRepositorio.Remover(categoria);
        await _categoriaRepositorio.SalvarAlteracoesAsync();

        return true;
    }

    private static CategoriaDto ParaDto(Categoria categoria) =>
        new(categoria.Id, categoria.Nome);
}
