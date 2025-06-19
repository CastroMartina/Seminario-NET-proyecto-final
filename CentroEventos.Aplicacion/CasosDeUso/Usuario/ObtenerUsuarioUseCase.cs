using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ObtenerUsuarioUseCase (IRepositorioUsuario repositorio) : UsuarioUseCase(repositorio)
{
    public Usuario? Ejecutar(int id)
    {
        return Repositorio.ObtenerUsuario(id);
    }
}
