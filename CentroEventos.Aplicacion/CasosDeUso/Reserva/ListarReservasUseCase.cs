using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Enums;


namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarReservasUseCase(IRepositorioReserva repositorio) : ReservaUseCase(repositorio)
{
    public List<Reserva> Ejecutar()
    {
        return Repositorio.ListarReservas();
    }
}
