using System;
using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;


namespace CentroEventos.Aplicacion.CasosDeUso;

public class AgregarEventoDeportivoUseCase(IRepositorioEventoDeportivo repositorio, IRepositorioPersona repoP, IServicioAutorizacion servicio, ValidadorEventoDeportivo validador): EventoDeportivoUseCase(repositorio)
{
    public void Ejecutar(int usuarioId, EventoDeportivo evento)
    {

        if (servicio.PoseeElpermiso(usuarioId, Permiso.EventoAlta))
        {
            Validador resultado = validador.ValidarFormato(evento);
            if (!resultado.EsValido)
            {
                throw new ValidacionException(resultado.Mensaje);
            }
            resultado = validador.ValidarResponsable(repoP, evento.ResponsableId);
            if (!resultado.EsValido)
            {
                throw new ValidacionException(resultado.Mensaje);
            }
            Repositorio.AgregarEventoDeportivo(evento);
        }
        else
        {
            throw new FalloAutorizacionException("No tiene permiso para agregar eventos deportivos.");
        }
    }
}
