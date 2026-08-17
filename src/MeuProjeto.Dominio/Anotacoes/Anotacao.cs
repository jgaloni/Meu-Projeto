using MeuProjeto.Dominio.Categorias;

namespace MeuProjeto.Dominio.Anotacoes;

public class Anotacao
{
    public int Id { get; private set; }
    public string Titulo { get; private set; } = string.Empty;
    public string Conteudo { get; private set; } = string.Empty;
    public DateTime DataCriacao { get; private set; }
    public DateTime? DataAtualizacao { get; private set; }
    public int? CategoriaId { get; private set; }
    public Categoria? Categoria { get; private set; }

    protected Anotacao()
    {
    }

    public Anotacao(string titulo, string conteudo)
    {
        DefinirTitulo(titulo);
        DefinirConteudo(conteudo);
        DataCriacao = DateTime.UtcNow;
    }

    public void Editar(string titulo, string conteudo)
    {
        DefinirTitulo(titulo);
        DefinirConteudo(conteudo);
        DataAtualizacao = DateTime.UtcNow;
    }

    public void AtribuirCategoria(int? categoriaId)
    {
        CategoriaId = categoriaId;
    }

    private void DefinirTitulo(string titulo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
        {
            throw new ArgumentException("O título da anotação não pode ser vazio.", nameof(titulo));
        }

        Titulo = titulo.Trim();
    }

    private void DefinirConteudo(string conteudo)
    {
        if (string.IsNullOrWhiteSpace(conteudo))
        {
            throw new ArgumentException("O conteúdo da anotação não pode ser vazio.", nameof(conteudo));
        }

        Conteudo = conteudo.Trim();
    }
}
