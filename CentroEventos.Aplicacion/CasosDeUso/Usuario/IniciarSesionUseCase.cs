using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class IniciarSesionUseCase(IRepositorioUsuario repositorio, IServicioHash servicioHash) : UsuarioUseCase(repositorio)
{
    public Usuario Ejecutar(string email, string contraseña)
    {
        string hashContraseña = servicioHash.Hash(contraseña);
        Usuario? usuario = Repositorio.IniciarSesionUsuario(email, hashContraseña);
        if (usuario == null)
        {
            Console.WriteLine($"Intento de inicio de sesión fallido para el usuario: {email}");
            throw new EntidadNotFoundException("Usuario no encontrado o contraseña incorrecta.");
        }
        return usuario;
    }
}
