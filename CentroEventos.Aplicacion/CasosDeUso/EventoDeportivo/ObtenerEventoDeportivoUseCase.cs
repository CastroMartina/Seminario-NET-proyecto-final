using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ObtenerEventoDeportivoUseCase(IRepositorioEventoDeportivo repositorio) : EventoDeportivoUseCase(repositorio)
{
    public EventoDeportivo? Ejecutar(int eventoId)
    {
        return Repositorio.ObtenerEventoDeportivo(eventoId);
    }
}
