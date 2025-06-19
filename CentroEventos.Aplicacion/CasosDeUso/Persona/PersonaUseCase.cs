using System;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public abstract class PersonaUseCase(IRepositorioPersona repositorio)
{
    protected IRepositorioPersona Repositorio { get; } = repositorio;
}
