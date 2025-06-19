using System;

namespace CentroEventos.Aplicacion.Validadores;

public class Validador
{
    public bool EsValido { get; set; } = true;
    public string Mensaje { get; set; } = string.Empty;

    public Validador(bool esValido, string mensaje)
    {
        EsValido = esValido;
        Mensaje = mensaje;
    }

}
