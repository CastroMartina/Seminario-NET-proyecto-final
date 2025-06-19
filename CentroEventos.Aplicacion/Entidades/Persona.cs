using System;

namespace CentroEventos.Aplicacion.Entidades;

public class Persona
{
    public int Id { get; set; }
    public string DNI { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;

    public Persona(string dni, string nombre, string apellido, string email, string telefono)
    {
        DNI = dni;
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Telefono = telefono;
    }

    public Persona()
    {
    }

    public static Persona Parsear(string linea)
    {
        string[] datos = linea.Split(',');
        return new Persona
        {
            Id = Convert.ToInt32(datos[0]),
            DNI = datos[1],
            Nombre = datos[2],
            Apellido = datos[3],
            Email = datos[4],
            Telefono = datos[5]
        };
    }
    
    public override string ToString()
    {
        return $"{Id},{DNI},{Nombre},{Apellido},{Email},{Telefono}";
    }

}
