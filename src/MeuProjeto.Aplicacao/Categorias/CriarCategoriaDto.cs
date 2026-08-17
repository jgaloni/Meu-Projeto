using System.ComponentModel.DataAnnotations;

namespace MeuProjeto.Aplicacao.Categorias;

public record CriarCategoriaDto([Required, MaxLength(80)] string Nome);
