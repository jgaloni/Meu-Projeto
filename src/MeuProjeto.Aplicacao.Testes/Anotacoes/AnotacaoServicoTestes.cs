using MeuProjeto.Aplicacao.Anotacoes;

namespace MeuProjeto.Aplicacao.Testes.Anotacoes;

public class AnotacaoServicoTestes
{
    [Fact]
    public async Task CriarAsync_DeveAdicionarAnotacaoNoRepositorio()
    {
        var servico = new AnotacaoServico(new AnotacaoRepositorioFalso());

        var resultado = await servico.CriarAsync(new CriarAnotacaoDto("Receita de bolo", "Farinha e ovos"));

        Assert.Equal("Receita de bolo", resultado.Titulo);

        var todas = await servico.ObterTodasAsync();
        Assert.Single(todas);
    }

    [Fact]
    public async Task RemoverAsync_DeveRemoverAnotacaoDoRepositorio()
    {
        var servico = new AnotacaoServico(new AnotacaoRepositorioFalso());
        var criada = await servico.CriarAsync(new CriarAnotacaoDto("Título", "Conteúdo"));

        var removido = await servico.RemoverAsync(criada.Id);

        Assert.True(removido);
        Assert.Empty(await servico.ObterTodasAsync());
    }
}
