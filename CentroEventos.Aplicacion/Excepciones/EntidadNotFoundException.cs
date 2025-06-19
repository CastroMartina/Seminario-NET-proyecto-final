using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class EntidadNotFoundException : Exception
{
    public EntidadNotFoundException()
    { }

    public EntidadNotFoundException(string message) : base(message)
    { }

    public EntidadNotFoundException(string message, Exception innerException) : base(message, innerException)
    { }
}
