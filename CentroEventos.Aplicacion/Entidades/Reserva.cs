using System;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Entidades;

public class Reserva
{
    public int Id { get; set; }
    public int PersonaId { get; set; }
    public int EventoId { get; set; }
    public DateTime FechaAltaReserva { get; set; }
    public Asistencia EstadoAsistencia { get; set; }

    public Reserva(int personaId, int eventoId, DateTime fechaReserva, Asistencia estadoAsistencia)
    {
        PersonaId = personaId;
        EventoId = eventoId;
        FechaAltaReserva = fechaReserva;
        EstadoAsistencia = estadoAsistencia;
    }

    public Reserva()
    {
    }

    public override string ToString()
    {
        return $"{Id},{PersonaId},{EventoId},{FechaAltaReserva},{EstadoAsistencia}";
    }

}
