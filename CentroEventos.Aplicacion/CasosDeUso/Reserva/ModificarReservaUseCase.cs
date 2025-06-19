using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ModificarReservaUseCase (IRepositorioReserva repoR, IServicioAutorizacion servicio, ValidadorReserva validador)
    : ReservaUseCase(repoR)
{
    public void Ejecutar(int usuarioId, Reserva reserva)
    {
        //me faltan hacer mas validaciones
        if (servicio.PoseeElpermiso(usuarioId, Permiso.ReservaModificacion))
        {
            Validador resultado = validador.ValidarExistencia(Repositorio, reserva.Id);
            if (!resultado.EsValido)
            {
                throw new EntidadNotFoundException(resultado.Mensaje);
            }
            Repositorio.ModificarReserva(reserva);
        }
        else
        {
            throw new FalloAutorizacionException("No tiene permiso para modificar reservas.");
        }
    }
}
