using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ModificarUsuarioUseCase(IRepositorioUsuario repositorio, IServicioAutorizacion servicio, IServicioHash servicioHash, ValidadorUsuario validador) : UsuarioUseCase(repositorio)
{    
        public void Ejecutar(int usuarioSesionID, Usuario datosOriginales, Usuario datosNuevos)
    {
        bool edicionPropia = datosOriginales.Id == usuarioSesionID;
        
        if (servicio.PoseeElpermiso(usuarioSesionID, Permiso.UsuarioModificacion) || edicionPropia)
        {
            Validador res = validador.ValidarFormato(datosNuevos);
            if (!res.EsValido)
            {
                throw new ValidacionException($"Error de validación: {res.Mensaje}");
            }
            if (datosNuevos.Email != datosOriginales.Email)
            {
                res = validador.ValidarDuplicacion(Repositorio, datosNuevos.Email);
                if (!res.EsValido)
                {
                    throw new ValidacionException($"Error de duplicación: {res.Mensaje}");
                }
            }
            CambiarContraseña(datosOriginales, datosNuevos);
            Repositorio.ModificarUsuario(datosOriginales.Id, datosNuevos);
        }
        else
        {
            throw new FalloAutorizacionException("El usuario no tiene permiso para modificar usuarios.");
        }
    }

    private void CambiarContraseña(Usuario datosOriginales, Usuario datosNuevos)
    {
        if (datosNuevos.Contraseña != datosOriginales.Contraseña)
        {
            datosNuevos.Contraseña = servicioHash.Hash(datosNuevos.Contraseña);
        }
    }
}
