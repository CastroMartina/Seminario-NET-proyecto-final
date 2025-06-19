using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Servicios;

public class ServicioAutorizacion : IServicioAutorizacion
{
    private readonly IRepositorioUsuario _repositorioUsuario;
    public ServicioAutorizacion(IRepositorioUsuario repositorioUsuario)
    {
        _repositorioUsuario = repositorioUsuario;
    }
    public bool PoseeElpermiso(int usuarioId, Permiso permiso)
    {
        Usuario? usuario = _repositorioUsuario.ObtenerUsuario(usuarioId);
        if (usuario != null && usuario.Permisos != null)
        {
            return usuario.Permisos.Contains(permiso);
        }
        return false;
    }
}
