using DriveX.Components;
using DriveX.Configs;
using DriveX.DAO;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddScoped<Conexao>();
builder.Services.AddScoped<VeiculoDAO>();
builder.Services.AddScoped<ClienteDAO>();
builder.Services.AddScoped<PrecoDAO>();
builder.Services.AddScoped<DocumentoCarDAO>();
builder.Services.AddScoped<DocumentacaoCliDAO>();
builder.Services.AddScoped<ChamadoSuporteDAO>();
builder.Services.AddScoped<VendaDAO>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();