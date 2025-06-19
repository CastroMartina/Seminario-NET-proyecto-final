using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioReserva
{
    List<Reserva> ListarReservas();
    Reserva? ObtenerReserva(int id);
    void ModificarReserva(Reserva reserva);
    void AgregarReserva(Reserva reserva);
    void EliminarReserva(int id);

    //
    public int ContarReservas(int eventoId);
}
