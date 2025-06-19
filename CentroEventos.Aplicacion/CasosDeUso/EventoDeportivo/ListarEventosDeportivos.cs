using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarEventosDeportivosUseCase (IRepositorioEventoDeportivo repositorio) : EventoDeportivoUseCase(repositorio)
{
    public List<EventoDeportivo> Ejecutar()
    {
        return Repositorio.ListarEventosDeportivos();
    }
}
