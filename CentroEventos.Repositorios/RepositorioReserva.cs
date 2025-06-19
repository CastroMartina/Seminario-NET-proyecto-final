using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;

public class RepositorioReserva : IRepositorioReserva
{
    public List<Reserva> ListarReservas()
    {
        using (var context = new CentroEventosContext())
        {
            return context.Reservas.ToList();
        }
    }

    public Reserva? ObtenerReserva(int id)
    {
        using (var context = new CentroEventosContext())
        {
            return context.Reservas.Where(r => r.Id == id).SingleOrDefault();
        }
    }

    public void ModificarReserva(Reserva r)
    {
        using (var context = new CentroEventosContext())
        {
            var reservaAModificar = context.Reservas.Where(res => res.Id == r.Id).SingleOrDefault();
            if (reservaAModificar != null)
            {
                reservaAModificar.PersonaId = r.PersonaId;
                reservaAModificar.EventoId = r.EventoId;
                reservaAModificar.FechaAltaReserva = r.FechaAltaReserva;
                reservaAModificar.EstadoAsistencia = r.EstadoAsistencia;
            }
            context.SaveChanges();
        }
    }

    public void AgregarReserva(Reserva r)
    {
        using (var context = new CentroEventosContext())
        {
            context.Reservas.Add(r);
            context.SaveChanges();
        }
    }

    public void EliminarReserva(int id)
    {
        using (var context = new CentroEventosContext())
        {
            var reservaAEliminar = context.Reservas.Where(r => r.Id == id).SingleOrDefault();
            if (reservaAEliminar != null)
            {
                context.Reservas.Remove(reservaAEliminar);
                context.SaveChanges();
            }
        }
    }

    //
    
    public int ContarReservas(int eventoId)
    {
        using (var context = new CentroEventosContext())
        {
            return context.Reservas.Count(r => r.EventoId == eventoId);
        }
    }
}
