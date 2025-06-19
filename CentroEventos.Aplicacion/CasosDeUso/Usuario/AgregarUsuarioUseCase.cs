using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class AgregarUsuarioUseCase(IRepositorioUsuario repositorio, IServicioHash servicioHash, ValidadorUsuario validador) : UsuarioUseCase(repositorio)
{
    public int Ejecutar(Usuario usuario)
    {
        Validador resultados;
        resultados = validador.ValidarFormato(usuario);
        if (!resultados.EsValido)
        {
            throw new ValidacionException(resultados.Mensaje);
        }
        Console.WriteLine("Validando si el usuario ya existe");
        if (Repositorio.ExisteEmail(usuario.Email))
        {
            throw new DuplicadoException("El email ya está en uso. \n");
        }
        usuario.Contraseña = servicioHash.Hash(usuario.Contraseña);
        int usuarioId = Repositorio.AgregarUsuario(usuario);
        if (usuarioId == 1)
        {
            Console.WriteLine("El usuario es el administrador del sistema.");
            OtorgarPermisos(usuarioId);
        }
        return usuarioId;
    }

    private void OtorgarPermisos(int usuarioId)
    {
        foreach (Permiso permiso in Enum.GetValues(typeof(Permiso)))
        {
            Repositorio.OtorgarPermiso(usuarioId, permiso);
        }
    }
}
