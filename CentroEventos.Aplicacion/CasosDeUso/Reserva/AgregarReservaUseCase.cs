using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class AgregarReservaUseCase(IRepositorioReserva repoR, IRepositorioEventoDeportivo repoE, IRepositorioPersona repoP, IServicioAutorizacion servicio, ValidadorReserva validador) : ReservaUseCase(repoR)
{
    public void Ejecutar(int usuarioId, Reserva reserva)
    {
        if (servicio.PoseeElpermiso(usuarioId, Permiso.ReservaAlta))
        {
            Validador resultado = validador.ValidarExistenciaEntidades(repoP, repoE, reserva);
            if (!resultado.EsValido)
            {
                throw new EntidadNotFoundException(resultado.Mensaje);
            }
            resultado = validador.ValidarDuplicacion(Repositorio, reserva);
            if (!resultado.EsValido)
            {
                throw new DuplicadoException(resultado.Mensaje);
            }
            resultado = validador.ValidarCupo(reserva, repoE, Repositorio);
            if (!resultado.EsValido)
            {
                throw new CupoExcedidoException(resultado.Mensaje);
            }
            Repositorio.AgregarReserva(reserva);
        }
        else
        {
            throw new FalloAutorizacionException("No tiene permiso para agregar reservas.");
        }
    }
}
