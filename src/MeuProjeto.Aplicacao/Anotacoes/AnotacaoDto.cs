namespace MeuProjeto.Aplicacao.Anotacoes;

public record AnotacaoDto(
    int Id,
    string Titulo,
    string Conteudo,
    DateTime DataCriacao,
    DateTime? DataAtualizacao,
    int? CategoriaId,
    string? CategoriaNome);
