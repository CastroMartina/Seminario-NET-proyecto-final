using System;
using System.Text;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorPersona
{
    private string ValidarNombre(string nombre)
    {
        string mensaje = string.Empty;
        if (string.IsNullOrWhiteSpace(nombre))
        {
            mensaje += "El nombre no puede estar vacío.\n";
        }
        return mensaje;
    }

    private string ValidarApellido(string apellido)
    {
        string mensaje = string.Empty;
        if (string.IsNullOrWhiteSpace(apellido))
        {
            mensaje += "El apellido no puede estar vacío.\n";
        }
        return mensaje;
    }

    private string ValidarDNI(string dni)
    {
        string mensaje = string.Empty;
        if (string.IsNullOrWhiteSpace(dni))
        {
            mensaje += "El DNI debe ser un número válido.\n";
        }
        return mensaje;
    }

    private string ValidarEmail(string email)
    {
        string mensaje = string.Empty;
        if (string.IsNullOrWhiteSpace(email))
        {
            mensaje += "El email debe ser un formato válido.\n";
        }
        return mensaje;
    }

    private string ValidarDuplicacionDNI(Persona persona, IRepositorioPersona repoP)
    {
        string mensaje = string.Empty;
        List<Persona> personasExistentes = repoP.ListarPersonas();
        Persona? entidad = personasExistentes.Find(p => p.DNI == persona.DNI);
        if (entidad != null && entidad.Id == persona.Id)
        {
            mensaje += "Ya existe una persona con este DNI.\n";
        }
        return mensaje;
    }

    private string ValidarDuplicacionEmail(Persona persona, IRepositorioPersona repoP)
    {
        string mensaje = string.Empty;
        List<Persona> personasExistentes = repoP.ListarPersonas();
        Persona? entidad = personasExistentes.Find(p => p.Email == persona.Email);
        if (entidad != null && entidad.Id == persona.Id)
        {
            mensaje += "Ya existe una persona con este email.\n";
        }
        return mensaje;
    }
    private string ValidarResponsabilidad(IRepositorioEventoDeportivo repoR, int personaId)
    {
        string mensaje = string.Empty;
        bool esResponsable = repoR.ListarEventosDeportivos().Any(e => e.ResponsableId == personaId);
        if (esResponsable)
        {
            mensaje = "La persona es responsable de un evento deportivo.";
        }
        return mensaje;
    }

    private string ValidarReservas(IRepositorioReserva repoR, int personaId)
    {
        string mensaje = string.Empty;
        bool tieneReservas = repoR.ListarReservas().Any(r => r.PersonaId == personaId);
        if (tieneReservas)
        {
            mensaje = "La persona tiene reservas asociadas.";
        }
        return mensaje;
    }
    public Validador ValidarFormato(Persona persona)
    {
        StringBuilder msg = new StringBuilder();
        msg.Append(this.ValidarApellido(persona.Apellido));
        msg.Append(this.ValidarNombre(persona.Nombre));
        msg.Append(this.ValidarDNI(persona.DNI));
        msg.Append(this.ValidarEmail(persona.Email));
        return new Validador(esValido: msg.Length == 0, mensaje: msg.ToString());
    }

    public Validador ValidarDuplicado(IRepositorioPersona repoP, Persona persona)
    {
        StringBuilder msg = new StringBuilder();
        msg.Append(this.ValidarDuplicacionDNI(persona, repoP));
        msg.Append(this.ValidarDuplicacionEmail(persona, repoP));
        return new Validador(esValido: msg.Length == 0, mensaje: msg.ToString());
    }

    public Validador ValidarOperacion(IRepositorioEventoDeportivo repoE, IRepositorioReserva repoR, int personaId)
    {
        StringBuilder msg = new StringBuilder();
        msg.Append(this.ValidarResponsabilidad(repoE, personaId));
        msg.Append(this.ValidarReservas(repoR, personaId));
        return new Validador(esValido: msg.Length == 0, mensaje: msg.ToString());
    }
}
