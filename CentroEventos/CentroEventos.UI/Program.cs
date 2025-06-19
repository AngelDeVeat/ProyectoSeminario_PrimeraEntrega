using CentroEventos.UI.Components;
using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddTransient<PersonaAltaUseCase>();
builder.Services.AddTransient<PersonaBajaUseCase>();
builder.Services.AddTransient<PersonaModificacionUseCase>();
builder.Services.AddTransient<PersonaListadoUseCase>();
builder.Services.AddTransient<EventoDeportivoAltaUseCase>();
builder.Services.AddTransient<EventoDeportivoBajaUseCase>();
builder.Services.AddTransient<EventoDeportivoModificacionUseCase>();
builder.Services.AddTransient<EventoDeportivoListadoUseCase>();
builder.Services.AddTransient<ReservaAltaUseCase>();
builder.Services.AddTransient<ReservaBajaUseCase>();
builder.Services.AddTransient<ReservaModificacionUseCase>();
builder.Services.AddTransient<ReservaListadoUseCase>();
builder.Services.AddTransient<UsuarioAltaUseCase>();
builder.Services.AddTransient<UsuarioBajaUseCase>();
builder.Services.AddTransient<UsuarioModificacionUseCase>();
builder.Services.AddTransient<ListarUsuariosUseCase>();
builder.Services.AddTransient<RegistrarseUseCase>();
builder.Services.AddTransient<UsuarioAutoModificacionUseCase>();
builder.Services.AddTransient<ListarAsistenciaAEventoUseCase>();
builder.Services.AddTransient<ObtenerPersonaUseCase>();
builder.Services.AddTransient<ObtenerReservaUseCase>();
builder.Services.AddTransient<ListarEventosConCupoDisponibleUseCase>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersona>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();

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
