using System.ComponentModel.DataAnnotations;

namespace MeuProjeto.Aplicacao.Anotacoes;

public record CriarAnotacaoDto(
    [Required, MaxLength(150)] string Titulo,
    [Required, MaxLength(4000)] string Conteudo,
    int? CategoriaId = null);
