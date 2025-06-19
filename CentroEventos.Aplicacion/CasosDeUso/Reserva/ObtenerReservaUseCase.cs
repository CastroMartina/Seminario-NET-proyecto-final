using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ObtenerReservaUseCase(IRepositorioReserva repositorio) : ReservaUseCase(repositorio)
{
    public Reserva? Ejecutar(int reservaId)
    {
        return Repositorio.ObtenerReserva(reservaId);
    }
}
