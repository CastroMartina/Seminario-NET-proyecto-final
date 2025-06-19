using System;

namespace CentroEventos.Aplicacion.Entidades;

public class EventoDeportivo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public DateTime FechaHoraInicio { get; set; }
    public double DuracionHoras { get; set; }
    public int CupoMaximo { get; set; }
    public int ResponsableId { get; set; }

    public EventoDeportivo(string nombre, string descripcion, DateTime fecha, double duracionHoras, int cupoMaximo, int responsableId)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        FechaHoraInicio = fecha;
        DuracionHoras = duracionHoras;
        CupoMaximo = cupoMaximo;
        ResponsableId = responsableId;
    }

    public EventoDeportivo()
    {
    }
    
    public override string ToString()
    {
        return $"{Id},{Nombre},{Descripcion},{FechaHoraInicio},{DuracionHoras},{CupoMaximo},{ResponsableId}";
    }
}
