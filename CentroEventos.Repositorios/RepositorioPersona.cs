using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;

public class RepositorioPersona() : IRepositorioPersona
{

    public List<Persona> ListarPersonas()
    {
        using (var context = new CentroEventosContext())
        {
            return context.Personas.ToList();
        }
    }

    public Persona? ObtenerPersona(int id)
    {
        using (var context = new CentroEventosContext())
        {
            return context.Personas.Find(id);
        }
    }
    public void ModificarPersona(Persona p)
    {
        using (var context = new CentroEventosContext())
        {
            var personaAModificar = context.Personas.Where(per => per.Id == p.Id).SingleOrDefault();
            if (personaAModificar != null)
            {
                //¿Debo modificar todos los campos?, ¿Se debe modificar el ID?
                personaAModificar.DNI = p.DNI;
                personaAModificar.Nombre = p.Nombre;
                personaAModificar.Apellido = p.Apellido;
                personaAModificar.Email = p.Email;
                personaAModificar.Telefono = p.Telefono;
            }
            context.SaveChanges();
        }
    }
    public void AgregarPersona(Persona persona)
    {
        using (var context = new CentroEventosContext())
        {
            context.Personas.Add(persona);
            context.SaveChanges();
        }
    }

    public void EliminarPersona(int id)
    {
        using (var context = new CentroEventosContext())
        {
            var personaAEliminar = context.Personas.Where(persona => persona.Id == id).SingleOrDefault();
            if (personaAEliminar != null)
            {
                context.Personas.Remove(personaAEliminar);
            }
            context.SaveChanges();
        }
    }

}

