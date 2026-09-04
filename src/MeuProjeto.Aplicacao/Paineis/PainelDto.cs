namespace MeuProjeto.Aplicacao.Paineis;

public record PainelDto(
    int TotalAnotacoes,
    int TotalCategorias,
    int AnotacoesSemCategoria,
    List<ContagemPorCategoriaDto> AnotacoesPorCategoria);
