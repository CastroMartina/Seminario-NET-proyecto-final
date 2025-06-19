using System;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public abstract class EventoDeportivoUseCase (IRepositorioEventoDeportivo repositorio)
{
    protected IRepositorioEventoDeportivo Repositorio { get; } = repositorio;

}
