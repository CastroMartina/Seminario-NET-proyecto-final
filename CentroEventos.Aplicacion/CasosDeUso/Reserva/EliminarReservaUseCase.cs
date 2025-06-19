using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarReservaUseCase (IRepositorioReserva repoR, IServicioAutorizacion servicio, ValidadorReserva validador)
    : ReservaUseCase(repoR)
{
    public void Ejecutar(int usuarioId, int reservaId)
    {
        if (servicio.PoseeElpermiso(usuarioId, Permiso.ReservaBaja))
        {
            Validador resultado = validador.ValidarExistencia(Repositorio, reservaId);
            if (!resultado.EsValido)
            {
                throw new EntidadNotFoundException(resultado.Mensaje);
            }
            Repositorio.EliminarReserva(reservaId);
        }
        else
        {
            throw new FalloAutorizacionException("No tiene permiso para eliminar reservas.");
        }
    }
}
