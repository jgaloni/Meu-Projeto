using MeuProjeto.Aplicacao.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace MeuProjeto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaServico _categoriaServico;

    public CategoriasController(ICategoriaServico categoriaServico)
    {
        _categoriaServico = categoriaServico;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDto>>> ObterTodas()
    {
        var categorias = await _categoriaServico.ObterTodasAsync();
        return Ok(categorias);
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaDto>> Criar(CriarCategoriaDto dto)
    {
        var categoria = await _categoriaServico.CriarAsync(dto);
        return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        var removido = await _categoriaServico.RemoverAsync(id);

        if (!removido)
        {
            return NotFound();
        }

        return NoContent();
    }
}
