using System;
using System.Text;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorEventoDeportivo
{

    private string ValidarNombre(string nombre)
    {
        string mensaje = string.Empty;
        if (string.IsNullOrWhiteSpace(nombre))
        {
            mensaje += "El nombre del evento deportivo no puede estar vacío.\n";
        }
        return mensaje;
    }
    private string ValidarDescripcion(string descripcion)
    {
        string mensaje = string.Empty;
        if (string.IsNullOrWhiteSpace(descripcion))
        {
            mensaje += "La descripción del evento deportivo no puede estar vacía.\n";
        }
        return mensaje;
    }

    private string ValidarCupo(int cupoMaximo)
    {
        string mensaje = string.Empty;
        if (cupoMaximo <= 0)
        {
            mensaje += "El cupo máximo debe ser un número positivo.\n";
        }
        return mensaje;
    }

    private string ValidarDuracion(double duracion)
    {
        string mensaje = string.Empty;
        if (duracion <= 0)
        {
            mensaje += "La duración del evento deportivo debe ser un número positivo.\n";
        }
        return mensaje;
    }
    private string ValidarFecha(DateTime fecha)
    {
        string mensaje = string.Empty;
        if (fecha < DateTime.Now)
        {
            mensaje += "La fecha del evento deportivo no puede ser anterior al actual.\n";
        }
        return mensaje;
    }

    public Validador ValidarReservasAsociadas(IRepositorioReserva repo, int eventoId)
    {
        string mensaje = string.Empty;
        if (repo.ContarReservas(eventoId) > 0)
        {
            mensaje += "No se puede eliminar el evento deportivo porque tiene reservas asociadas.\n";
        }
        return new Validador(string.IsNullOrEmpty(mensaje), mensaje);
    }

    public Validador ValidarResponsable(IRepositorioPersona repoP, int responsableId)
    {
        string mensaje = string.Empty;
        Persona? responsable = repoP.ObtenerPersona(responsableId);
        if (responsable == null)
        {
            mensaje += "El responsable del evento deportivo no existe.\n";
        }
        return new Validador(string.IsNullOrEmpty(mensaje), mensaje);
    }

    public Validador ValidarFormato(EventoDeportivo evento)
    {
        StringBuilder mensaje = new StringBuilder();
        mensaje.Append(ValidarNombre(evento.Nombre));
        mensaje.Append(ValidarDescripcion(evento.Descripcion));
        mensaje.Append(ValidarCupo(evento.CupoMaximo));
        mensaje.Append(ValidarDuracion(evento.DuracionHoras));
        mensaje.Append(ValidarFecha(evento.FechaHoraInicio));
        return new Validador(string.IsNullOrEmpty(mensaje.ToString()), mensaje.ToString());
    }

}
