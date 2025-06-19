using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarPersonasUseCase(IRepositorioPersona repositorio) : PersonaUseCase(repositorio)
{
    public List<Persona> Ejecutar()
    {
        // Aquí podrías agregar lógica adicional si es necesario
        return Repositorio.ListarPersonas();
    }
}
