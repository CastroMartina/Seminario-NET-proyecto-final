using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ObtenerPersonaUseCase(IRepositorioPersona repositorio) : PersonaUseCase(repositorio)
{
    public Persona? Ejecutar(int id)
    {
        return Repositorio.ObtenerPersona(id);
    }
}
