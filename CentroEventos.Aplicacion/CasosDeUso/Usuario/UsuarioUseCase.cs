using System;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public abstract class UsuarioUseCase (IRepositorioUsuario repositorio)
{
    protected IRepositorioUsuario Repositorio { get; } = repositorio;

}
