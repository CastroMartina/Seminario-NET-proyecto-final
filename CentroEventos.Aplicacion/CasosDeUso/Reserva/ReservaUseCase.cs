using System;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public abstract class ReservaUseCase (IRepositorioReserva repositorio)
{
    protected IRepositorioReserva Repositorio { get; } = repositorio;
}
