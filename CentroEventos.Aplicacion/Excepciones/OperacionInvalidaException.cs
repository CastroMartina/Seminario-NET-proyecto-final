using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class OperacionInvalidaException : Exception
{
    public OperacionInvalidaException()
    { }

    public OperacionInvalidaException(string message) : base(message)
    { }

    public OperacionInvalidaException(string message, Exception innerException) : base(message, innerException)
    { }
}
