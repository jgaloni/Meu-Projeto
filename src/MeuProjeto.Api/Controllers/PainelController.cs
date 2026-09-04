using MeuProjeto.Aplicacao.Paineis;
using Microsoft.AspNetCore.Mvc;

namespace MeuProjeto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PainelController : ControllerBase
{
    private readonly IPainelServico _painelServico;

    public PainelController(IPainelServico painelServico)
    {
        _painelServico = painelServico;
    }

    [HttpGet]
    public async Task<ActionResult<PainelDto>> Obter()
    {
        var painel = await _painelServico.ObterAsync();
        return Ok(painel);
    }
}
