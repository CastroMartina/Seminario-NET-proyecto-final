using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioUsuario
{
    public List<Usuario> ListarUsuarios();
    public Usuario? ObtenerUsuario(int id);
    public void ModificarUsuario(int usuarioId, Usuario nuevosDatos);
    public int AgregarUsuario(Usuario usuario);
    public void EliminarUsuario(string email);
    public void OtorgarPermiso(int id, Permiso permiso);
    public bool ExisteEmail(string email);
    public Usuario? IniciarSesionUsuario(string email, string contraseña);
}
