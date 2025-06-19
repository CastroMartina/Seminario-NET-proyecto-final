using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioPersona
{
    List<Persona> ListarPersonas();
    Persona? ObtenerPersona(int id);
    void ModificarPersona(Persona persona);
    void AgregarPersona(Persona persona);
    void EliminarPersona(int id);

}
