using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarEventoDeportivoUseCase (IRepositorioEventoDeportivo repositorio, IRepositorioReserva repoR, IServicioAutorizacion servicio, ValidadorEventoDeportivo validador)
    : EventoDeportivoUseCase(repositorio)
{
    public void Ejecutar(int usuarioId, int eventoId)
    {
        if (servicio.PoseeElpermiso(usuarioId, Permiso.EventoBaja))
        {
            Validador resultado = validador.ValidarReservasAsociadas(repoR, eventoId);
            if (!resultado.EsValido)
            {
                throw new OperacionInvalidaException(resultado.Mensaje);
            }
            Repositorio.EliminarEventoDeportivo(eventoId);
        }
        else
        {
            throw new FalloAutorizacionException("No tiene permiso para eliminar eventos deportivos.");
        }
    }
}
