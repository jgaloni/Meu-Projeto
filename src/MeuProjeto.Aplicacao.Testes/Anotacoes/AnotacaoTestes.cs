using MeuProjeto.Dominio.Anotacoes;

namespace MeuProjeto.Aplicacao.Testes.Anotacoes;

public class AnotacaoTestes
{
    [Fact]
    public void Construtor_ComDadosValidos_DeveCriarAnotacao()
    {
        var anotacao = new Anotacao("Meu título", "Meu conteúdo");

        Assert.Equal("Meu título", anotacao.Titulo);
        Assert.Equal("Meu conteúdo", anotacao.Conteudo);
    }

    [Fact]
    public void Construtor_ComTituloVazio_DeveLancarExcecao()
    {
        Assert.Throws<ArgumentException>(() => new Anotacao("", "Algum conteúdo"));
    }
}
