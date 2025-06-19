using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorReserva
{
    public Validador ValidarExistenciaEntidades(IRepositorioPersona repoP, IRepositorioEventoDeportivo repoE, Reserva reserva)
    {
        Persona? persona = repoP.ObtenerPersona(reserva.PersonaId);
        EventoDeportivo? evento = repoE.ObtenerEventoDeportivo(reserva.EventoId);
        string mensaje = string.Empty;
        if (persona == null || evento == null)
        {
            mensaje += "La persona o el evento deportivo no existen.\n";
        }
        return new Validador (esValido: mensaje == string.Empty, mensaje: mensaje);
    }

    public Validador ValidarDuplicacion(IRepositorioReserva repoR, Reserva reserva)
    {
        List<Reserva> reservasExistentes = repoR.ListarReservas();
        Reserva? entidad = reservasExistentes.Find(p => p.PersonaId == reserva.PersonaId && p.EventoId == reserva.EventoId);
        string mensaje = string.Empty;
        if (entidad != null)
        {
            mensaje += "Ya existe una reserva para esta persona y evento.\n";
        }
        return new Validador (esValido: mensaje == string.Empty, mensaje: mensaje);
    }

    public Validador ValidarCupo(Reserva reserva, IRepositorioEventoDeportivo repoE, IRepositorioReserva repoR)
    {
        string mensaje = string.Empty;
        int cantReservas = repoR.ContarReservas(reserva.EventoId);
        EventoDeportivo? evento = repoE.ObtenerEventoDeportivo(reserva.EventoId);
        if (evento != null && cantReservas == evento.CupoMaximo)
        {
            mensaje += "No hay cupo disponible para este evento deportivo.\n";
        }
        return new Validador (esValido: mensaje == string.Empty, mensaje: mensaje);
    }

    public Validador ValidarExistencia(IRepositorioReserva repoR, int reservaId)
    {
        string mensaje = string.Empty;
        Reserva? reserva = repoR.ObtenerReserva(reservaId);
        if (reserva == null)
        {
            mensaje += "La reserva no existe.\n";
        }
        return new Validador (esValido: mensaje == string.Empty, mensaje: mensaje);
    }
}
