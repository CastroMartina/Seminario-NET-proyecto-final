using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repositorio, IRepositorioPersona repoP, IServicioAutorizacion servicio, ValidadorEventoDeportivo validador) : EventoDeportivoUseCase(repositorio)
{
    public void Ejecutar(int usuarioId, EventoDeportivo nuevoEvento)
    {
        //falta verificar que el evento a modificar exista
        //falta verificar que no tenga mas reservas que su cupo maximo
        if (servicio.PoseeElpermiso(usuarioId, Permiso.EventoModificacion))
        {
            Validador resultado = validador.ValidarFormato(nuevoEvento);
            if (!resultado.EsValido)
            {
                throw new ValidacionException(resultado.Mensaje);
            }
            resultado = validador.ValidarResponsable(repoP, nuevoEvento.ResponsableId);
            if (!resultado.EsValido)
            {
                throw new EntidadNotFoundException(resultado.Mensaje);
            }
            Repositorio.ModificarEventoDeportivo(nuevoEvento);
        }
        else
        {
            throw new FalloAutorizacionException("No tiene permiso para modificar eventos deportivos.");
        }
    }
}
