namespace MeuProjeto.Dominio.Categorias;

public interface ICategoriaRepositorio
{
    Task<IEnumerable<Categoria>> ObterTodasAsync();
    Task<Categoria?> ObterPorIdAsync(int id);
    Task AdicionarAsync(Categoria categoria);
    void Remover(Categoria categoria);
    Task SalvarAlteracoesAsync();
}
