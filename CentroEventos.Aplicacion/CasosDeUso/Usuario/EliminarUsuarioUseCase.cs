using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarUsuarioUseCase (IRepositorioUsuario repositorio, IServicioAutorizacion servicio) : UsuarioUseCase(repositorio)
{
    public void Ejecutar(int usuarioId,string usuarioAEliminarEmail)
    {
        if (servicio.PoseeElpermiso(usuarioId, Permiso.UsuarioBaja))
        {
            Repositorio.EliminarUsuario(usuarioAEliminarEmail);
        }
        else
        {
            throw new FalloAutorizacionException("El usuario no tiene permiso para eliminar usuarios.");
        }
    }
}
