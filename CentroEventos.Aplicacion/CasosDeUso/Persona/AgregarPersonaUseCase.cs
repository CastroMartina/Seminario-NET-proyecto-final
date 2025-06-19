using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using System.ComponentModel.DataAnnotations;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class AgregarPersonaUseCase(IRepositorioPersona repositorio, IServicioAutorizacion servicioAutorizacion) : PersonaUseCase(repositorio)
{
    public void Ejecutar(int usuarioId, Persona persona)
    {
        if (servicioAutorizacion.PoseeElpermiso(usuarioId, Permiso.PersonaAlta))
        {
            ValidadorPersona validador = new ValidadorPersona();
            Validador resultadoValidacion;

            resultadoValidacion = validador.ValidarFormato(persona);
            if (!resultadoValidacion.EsValido)
            {
                throw new ValidationException(resultadoValidacion.Mensaje);
            }
            resultadoValidacion = validador.ValidarDuplicado(Repositorio, persona);
            if (!resultadoValidacion.EsValido)
            {
                throw new DuplicadoException(resultadoValidacion.Mensaje);
            }
            Repositorio.AgregarPersona(persona);
        }
        else
        {
            throw new FalloAutorizacionException("No tiene permiso para agregar personas.");
        }
    }
}
