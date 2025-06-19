using System;
using System.Security.Cryptography.X509Certificates;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ModificarPersonaUseCase(IRepositorioPersona repositorio, IServicioAutorizacion servicioAutorizacion) : PersonaUseCase(repositorio)
{
    public void Ejecutar(int usuarioId, Persona persona)
    { 
        if (servicioAutorizacion.PoseeElpermiso(usuarioId, Permiso.PersonaModificacion))
        {
            Repositorio.ModificarPersona(persona);
        }
    }
}
