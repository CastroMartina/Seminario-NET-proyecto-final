using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CambiarContraseñaUseCase(IRepositorioUsuario repositorio, IServicioAutorizacion servicio, IServicioHash servicioHash) : UsuarioUseCase(repositorio)
{
    public void Ejecutar(int usuarioActualId, int usuarioModificarId, string email,string nuevaContraseña)
    {
        if (servicio.PoseeElpermiso(usuarioActualId, Enums.Permiso.UsuarioModificacion) || usuarioActualId == usuarioModificarId)
        {
            var usuarioModificar = Repositorio.ObtenerUsuario(usuarioModificarId);
            if (usuarioModificar != null)
            {
               string contraseñaHash = servicioHash.Hash(nuevaContraseña);
               Repositorio.ModificarUsuario(usuarioModificarId, new Usuario
                {
                    Id = usuarioModificar.Id,
                    Nombre = usuarioModificar.Nombre,
                    Apellido = usuarioModificar.Apellido,
                    Email = email,
                    Contraseña = contraseñaHash
                });
            }
        }
    }
}
