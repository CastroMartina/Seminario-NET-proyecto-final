using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioSesion
{
    public void IniciarSesion(Usuario usuario);
    public void CerrarSesion();
    public Usuario GetUser();
    public int GetUserId();

    
}
