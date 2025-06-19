using System;
using CentroEventos.Aplicacion.Entidades;
using System.Text;
using System.Text.RegularExpressions;
using CentroEventos.Aplicacion.Interfaces;


namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorUsuario
{
    private string ValidarNombre(string nombre)
    {
        StringBuilder sb = new StringBuilder();
        if (string.IsNullOrWhiteSpace(nombre))
        {
            sb.AppendLine("El nombre no puede estar vacío.");
        }
        /*if (!Regex.IsMatch(nombre, @"^[a-zA-Z]+$"))
        {
            sb.AppendLine("El nombre solo puede contener letras.");
        }*/
        if (nombre.Length < 2)
        {
            sb.AppendLine("El nombre debe tener al menos 2 caracteres.");
        }
        return sb.ToString();
    }

    private string ValidarApellido(string apellido)
    {
        StringBuilder sb = new StringBuilder();
        if (string.IsNullOrWhiteSpace(apellido))
        {
            sb.AppendLine("El apellido no puede estar vacío.");
        }
        /*if (!Regex.IsMatch(apellido, @"^[a-zA-Z]+$"))
        {
            sb.AppendLine("El apellido solo puede contener letras.");
        }*/
        if (apellido.Length < 2)
        {
            sb.AppendLine("El apellido debe tener al menos 2 caracteres.");
        }
        return sb.ToString();
    }

    private string ValidarEmail(string email)
    {
        StringBuilder sb = new StringBuilder();
        if (string.IsNullOrWhiteSpace(email))
        {
            sb.AppendLine("El email no puede estar vacío.");
        }
        /*if (!Regex.IsMatch(email, @"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,}$"))
        {
            sb.AppendLine("El email debe tener un formato válido (ejemplo@persona.com).");
        }*/
        return sb.ToString();
    }

    private string ValidarContraseña(string contraseña)
    {
        StringBuilder sb = new StringBuilder();
        if (string.IsNullOrWhiteSpace(contraseña))
        {
            sb.AppendLine("La contraseña no puede estar vacía.");
        }
        if (contraseña.Length < 6)
        {
            sb.AppendLine("La contraseña debe tener al menos 6 caracteres.");
        }
        return sb.ToString();
    }

    public Validador ValidarFormato(Usuario usuario)
    {
        Console.WriteLine("Validando formato del usuario");
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(ValidarNombre(usuario.Nombre));
        sb.AppendLine(ValidarApellido(usuario.Apellido));
        sb.AppendLine(ValidarEmail(usuario.Email));
        sb.AppendLine(ValidarContraseña(usuario.Contraseña));
        Console.WriteLine("Validación de formato exitosa");
        return new Validador(string.IsNullOrWhiteSpace(sb.ToString()), sb.ToString());
    }

    public Validador ValidarDuplicacion(IRepositorioUsuario repoU, string email)
    {
        string msj = string.Empty;
        if (repoU.ExisteEmail(email))
        {
            msj = "Ya existe un usuario con ese email.";
        }
        return new Validador(esValido: string.IsNullOrEmpty(msj), mensaje: msj);
        /*
        usuarios = repoU.ListarUsuarios();
        var existe = usuarios.Where(u => u.Email == email).SingleOrDefault();
        if (existe != null)
        {
            return new Validador(esValido: false, mensaje: "Ya existe un usuario con ese email.");
        }*/

    }


}
