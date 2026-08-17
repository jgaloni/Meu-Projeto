using MeuProjeto.Dominio.Anotacoes;

namespace MeuProjeto.Aplicacao.Anotacoes;

public class AnotacaoServico : IAnotacaoServico
{
    private readonly IAnotacaoRepositorio _anotacaoRepositorio;

    public AnotacaoServico(IAnotacaoRepositorio anotacaoRepositorio)
    {
        _anotacaoRepositorio = anotacaoRepositorio;
    }

    public async Task<IEnumerable<AnotacaoDto>> ObterTodasAsync()
    {
        var anotacoes = await _anotacaoRepositorio.ObterTodasAsync();
        return anotacoes.Select(ParaDto);
    }

    public async Task<AnotacaoDto?> ObterPorIdAsync(int id)
    {
        var anotacao = await _anotacaoRepositorio.ObterPorIdAsync(id);

        if (anotacao is null)
        {
            return null;
        }

        return ParaDto(anotacao);
    }

    public async Task<AnotacaoDto> CriarAsync(CriarAnotacaoDto dto)
    {
        var anotacao = new Anotacao(dto.Titulo, dto.Conteudo);
        anotacao.AtribuirCategoria(dto.CategoriaId);

        await _anotacaoRepositorio.AdicionarAsync(anotacao);
        await _anotacaoRepositorio.SalvarAlteracoesAsync();

        var anotacaoSalva = await _anotacaoRepositorio.ObterPorIdAsync(anotacao.Id);

        if (anotacaoSalva is null)
        {
            return ParaDto(anotacao);
        }

        return ParaDto(anotacaoSalva);
    }

    public async Task<AnotacaoDto?> AtualizarAsync(int id, AtualizarAnotacaoDto dto)
    {
        var anotacao = await _anotacaoRepositorio.ObterPorIdAsync(id);

        if (anotacao is null)
        {
            return null;
        }

        anotacao.Editar(dto.Titulo, dto.Conteudo);
        anotacao.AtribuirCategoria(dto.CategoriaId);
        await _anotacaoRepositorio.SalvarAlteracoesAsync();

        var anotacaoAtualizada = await _anotacaoRepositorio.ObterPorIdAsync(id);

        if (anotacaoAtualizada is null)
        {
            return ParaDto(anotacao);
        }

        return ParaDto(anotacaoAtualizada);
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var anotacao = await _anotacaoRepositorio.ObterPorIdAsync(id);

        if (anotacao is null)
        {
            return false;
        }

        _anotacaoRepositorio.Remover(anotacao);
        await _anotacaoRepositorio.SalvarAlteracoesAsync();

        return true;
    }

    private static AnotacaoDto ParaDto(Anotacao anotacao) => new(
        anotacao.Id,
        anotacao.Titulo,
        anotacao.Conteudo,
        anotacao.DataCriacao,
        anotacao.DataAtualizacao,
        anotacao.CategoriaId,
        anotacao.Categoria?.Nome);
}
