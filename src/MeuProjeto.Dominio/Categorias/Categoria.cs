namespace MeuProjeto.Dominio.Categorias;

public class Categoria
{
    public int Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;

    protected Categoria()
    {
    }

    public Categoria(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome da categoria não pode ser vazio.", nameof(nome));
        }

        Nome = nome.Trim();
    }
}
