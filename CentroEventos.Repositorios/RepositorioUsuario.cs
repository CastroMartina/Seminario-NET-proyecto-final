using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
    public List<Usuario> ListarUsuarios()
    {
        using (var context = new CentroEventosContext())
        {
            return context.Usuarios.ToList();
        }
    }

    public Usuario? ObtenerUsuario(int id)
    {
        using (var context = new CentroEventosContext())
        {
            return context.Usuarios.Find(id);
        }
    }

    public void ModificarUsuario(int usuarioId, Usuario nuevosDatos)
    {
        using (var context = new CentroEventosContext())
        {
            var usuarioExistente = context.Usuarios.SingleOrDefault(u => u.Id == usuarioId);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nombre = nuevosDatos.Nombre;
                usuarioExistente.Apellido = nuevosDatos.Apellido;
                usuarioExistente.Email = nuevosDatos.Email;
                usuarioExistente.Contraseña = nuevosDatos.Contraseña;
            }
            context.SaveChanges();
        }
    }

    public int AgregarUsuario(Usuario usuario)
    {
        Console.WriteLine("Agregando usuario: " + usuario.Nombre);
        using (var context = new CentroEventosContext())
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();
            return usuario.Id;
        }

    }

    public void EliminarUsuario(string email)
    {
        using (var context = new CentroEventosContext())
        {
            var usuarioAEliminar = context.Usuarios.SingleOrDefault(u => u.Email == email);
            if (usuarioAEliminar != null)
            {
                context.Usuarios.Remove(usuarioAEliminar);
                context.SaveChanges();
            }
        }
    }

    public void OtorgarPermiso(int id, Permiso permiso)
    {
        using (var context = new CentroEventosContext())
        {
            var usuario = context.Usuarios.Find(id);
            if (usuario != null)
            {
                if (usuario.PermisosAsignados.Contains(permiso.ToString()))
                {
                    Console.WriteLine($"El usuario {usuario.Nombre} ya tiene el permiso {permiso}.");
                }
                else
                {
                    usuario.Permisos.Add(permiso);
                }
            }
            context.SaveChanges();
        }
    }

    public Usuario? IniciarSesionUsuario(string email, string contraseña)
    {
        using (var context = new CentroEventosContext())
        {
            var usuario = context.Usuarios.SingleOrDefault(u => u.Email == email && u.Contraseña == contraseña);
            return usuario;
        }
    }

    //esta bien ponerlo aca?
    public bool ExisteEmail(string email)
    {
        using (var context = new CentroEventosContext())
        {
            return context.Usuarios.Any(u => u.Email == email);
        }
    }

}
