using System;
using CentroEventos.Aplicacion.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Contraseña { get; set; } = string.Empty;
    public string PermisosAsignados
    {
        get => string.Join(", ", Permisos.Select(p => p.ToString()));
        set => Permisos = string.IsNullOrEmpty(value)
            ? new List<Permiso>()
            : value.Split(',', StringSplitOptions.RemoveEmptyEntries)
             .Select(p => Enum.Parse<Permiso>(p.Trim())).ToList();
    }

    [NotMapped]
    public List<Permiso> Permisos { get; set; } = new List<Permiso>();

    public Usuario(string nombre, string apellido, string email, string contraseña)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Contraseña = contraseña;
    }

    public Usuario()
    {
    }

    public override string ToString()
    {
        return $"{Nombre} {Apellido} {Email}";
    }

    // Método para crear una nueva instancia de Usuario con los mismos valores
    public Usuario copy()
    {
        return new Usuario
        {
            Id = this.Id,
            Nombre = this.Nombre,
            Apellido = this.Apellido,
            Email = this.Email,
            Contraseña = this.Contraseña,
            Permisos = new List<Permiso>(this.Permisos)
        };
    }
}
