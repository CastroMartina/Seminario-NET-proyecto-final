using System;
using System.Reflection.Metadata;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Servicios;

public class ServicioSesion : IServicioSesion
{
    public Usuario? User { get; set; } = new Usuario();
    public void IniciarSesion(Usuario usuario)
    {
        User = usuario;
    }

    public Usuario GetUser()
    {
        return User ?? new Usuario();
    }

    public int GetUserId()
    {
        return User?.Id ?? 0;
    }
    public void CerrarSesion()
    {
        User = null;
    }


}
