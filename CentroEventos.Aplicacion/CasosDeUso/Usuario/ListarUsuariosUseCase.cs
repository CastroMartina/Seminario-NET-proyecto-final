using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarUsuariosUseCase (IRepositorioUsuario repositorio) : UsuarioUseCase(repositorio)
{
    public List<Usuario> Ejecutar(Usuario usuario)
    {
        bool puedeVerTodos = usuario.Permisos.Contains(Permiso.UsuarioAlta);
        return puedeVerTodos ? Repositorio.ListarUsuarios() : Repositorio.ListarUsuarios().Where(u => u.Id == usuario.Id).ToList();
    }
}
