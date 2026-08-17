using MeuProjeto.Web.Servicos.Anotacoes;
using MeuProjeto.Web.Servicos.Categorias;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var apiBaseUrl = builder.Configuration["ApiBaseUrl"];

if (string.IsNullOrWhiteSpace(apiBaseUrl))
{
    throw new InvalidOperationException("A configuração ApiBaseUrl não foi definida.");
}

builder.Services.AddHttpClient<IAnotacaoApiCliente, AnotacaoApiCliente>(cliente =>
{
    cliente.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddHttpClient<ICategoriaApiCliente, CategoriaApiCliente>(cliente =>
{
    cliente.BaseAddress = new Uri(apiBaseUrl);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
