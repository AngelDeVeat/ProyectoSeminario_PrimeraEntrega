using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;
using CentroEventos.UI.Components;

// CREA LA DATABASE SI NO EXISTE
CentroEventosSqlite.Inicializar();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// AGREGAMOS SERVICIOS NECESARIOS AL CONTENEDOR DI
builder.Services.AddTransient<RegistrarseUseCase>();
builder.Services.AddTransient<IniciarSesionUseCase>();
builder.Services.AddTransient<ServicioAutoizacion>();
builder.Services.AddTransient<UsuarioAutoModificacionUseCase>();
builder.Services.AddTransient<UsuarioBajaUseCase>();
builder.Services.AddTransient<UsuarioModificacionUseCase>();
builder.Services.AddTransient<DarPermisosUseCase>();
builder.Services.AddTransient<ListarUsuariosUseCase>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutoizacion>();
// La clase user state contendra el usuario que haya iniciado sesion/ registrado actualmente
builder.Services.AddScoped<UserState>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
