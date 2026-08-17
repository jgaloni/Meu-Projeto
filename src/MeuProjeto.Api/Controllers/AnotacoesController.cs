using MeuProjeto.Aplicacao.Anotacoes;
using Microsoft.AspNetCore.Mvc;

namespace MeuProjeto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnotacoesController : ControllerBase
{
    private readonly IAnotacaoServico _anotacaoServico;

    public AnotacoesController(IAnotacaoServico anotacaoServico)
    {
        _anotacaoServico = anotacaoServico;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AnotacaoDto>>> ObterTodas()
    {
        var anotacoes = await _anotacaoServico.ObterTodasAsync();
        return Ok(anotacoes);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AnotacaoDto>> ObterPorId(int id)
    {
        var anotacao = await _anotacaoServico.ObterPorIdAsync(id);

        if (anotacao is null)
        {
            return NotFound();
        }

        return Ok(anotacao);
    }

    [HttpPost]
    public async Task<ActionResult<AnotacaoDto>> Criar(CriarAnotacaoDto dto)
    {
        var anotacao = await _anotacaoServico.CriarAsync(dto);
        return CreatedAtAction(nameof(ObterPorId), new { id = anotacao.Id }, anotacao);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<AnotacaoDto>> Atualizar(int id, AtualizarAnotacaoDto dto)
    {
        var anotacao = await _anotacaoServico.AtualizarAsync(id, dto);

        if (anotacao is null)
        {
            return NotFound();
        }

        return Ok(anotacao);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        var removido = await _anotacaoServico.RemoverAsync(id);

        if (!removido)
        {
            return NotFound();
        }

        return NoContent();
    }
}
