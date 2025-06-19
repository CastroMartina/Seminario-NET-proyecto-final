using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
    public List<EventoDeportivo> ListarEventosDeportivos()
    {
        using (var context = new CentroEventosContext())
        {
            return context.EventosDeportivos.ToList();
        }
    }

    public EventoDeportivo? ObtenerEventoDeportivo(int id)
    {
        using (var context = new CentroEventosContext())
        {
            return context.EventosDeportivos.Where(e => e.Id == id).SingleOrDefault();
        }
    }

    public void ModificarEventoDeportivo(EventoDeportivo e)
    {
        using (var context = new CentroEventosContext())
        {
            var eventoAModificar = context.EventosDeportivos.Where(ev => ev.Id == e.Id).SingleOrDefault();
            if (eventoAModificar != null)
            {
                eventoAModificar.Nombre = e.Nombre;
                eventoAModificar.Descripcion = e.Descripcion;
                eventoAModificar.FechaHoraInicio = e.FechaHoraInicio;
                eventoAModificar.DuracionHoras = e.DuracionHoras;
                eventoAModificar.CupoMaximo = e.CupoMaximo;
                eventoAModificar.ResponsableId = e.ResponsableId;
            }
            context.SaveChanges();
        }

    }

    public void AgregarEventoDeportivo(EventoDeportivo eventoDeportivo)
    {
        using (var context = new CentroEventosContext())
        {
            context.EventosDeportivos.Add(eventoDeportivo);
            context.SaveChanges();
        }
    }

    public void EliminarEventoDeportivo(int id)
    {
        using (var context = new CentroEventosContext())
        {
            var eventoAEliminar = context.EventosDeportivos.Where(e => e.Id == id).SingleOrDefault();
            if (eventoAEliminar != null)
            {
                context.EventosDeportivos.Remove(eventoAEliminar);
            }
            context.SaveChanges();
        }
    }
    
}
