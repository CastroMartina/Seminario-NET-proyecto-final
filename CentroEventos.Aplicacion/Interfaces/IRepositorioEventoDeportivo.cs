using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioEventoDeportivo
{
    List<EventoDeportivo> ListarEventosDeportivos();
    EventoDeportivo? ObtenerEventoDeportivo(int id);
    void ModificarEventoDeportivo(EventoDeportivo eventoDeportivo);
    void AgregarEventoDeportivo(EventoDeportivo eventoDeportivo);
    void EliminarEventoDeportivo(int id);
}
