using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.UI.Components;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;

CentroEventosSqlite.Inicializar();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<AgregarUsuarioUseCase>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddTransient<IServicioHash, ServicioHash>();
builder.Services.AddTransient<ValidadorUsuario>();
builder.Services.AddTransient<IniciarSesionUseCase>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();

//repositorios

builder.Services.AddScoped<IRepositorioPersona, RepositorioPersona>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();

//casos de uso

//persona

builder.Services.AddTransient<AgregarPersonaUseCase>();
builder.Services.AddTransient<EliminarPersonaUseCase>();
builder.Services.AddTransient<ModificarPersonaUseCase>();
builder.Services.AddTransient<ListarPersonasUseCase>();
builder.Services.AddTransient<ObtenerPersonaUseCase>();

//reserva

builder.Services.AddTransient<AgregarReservaUseCase>();
builder.Services.AddTransient<EliminarReservaUseCase>();
builder.Services.AddTransient<ModificarReservaUseCase>();
builder.Services.AddTransient<ListarReservasUseCase>();
builder.Services.AddTransient<ObtenerReservaUseCase>();

//evento deportivo
builder.Services.AddTransient<AgregarEventoDeportivoUseCase>();
builder.Services.AddTransient<EliminarEventoDeportivoUseCase>();
builder.Services.AddTransient<ModificarEventoDeportivoUseCase>();
builder.Services.AddTransient<ListarEventosDeportivosUseCase>();
builder.Services.AddTransient<ObtenerEventoDeportivoUseCase>();

//usuarios

builder.Services.AddTransient<ListarUsuariosUseCase>();
builder.Services.AddTransient<ModificarUsuarioUseCase>();
builder.Services.AddTransient<ModificarUsuarioUseCase>();
builder.Services.AddTransient<EliminarUsuarioUseCase>();
builder.Services.AddTransient<ObtenerUsuarioUseCase>();

//validadores

builder.Services.AddScoped<ValidadorReserva>();
builder.Services.AddScoped<ValidadorEventoDeportivo>();
builder.Services.AddScoped<ValidadorPersona>();

//servicios
builder.Services.AddScoped<IServicioSesion, ServicioSesion>();



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
