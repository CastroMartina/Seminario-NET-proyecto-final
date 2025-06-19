using System;
using CentroEventos.Aplicacion.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace CentroEventos.Aplicacion.Servicios;

public class ServicioHash : IServicioHash
{
    public string Hash(string contraseña)
    {
        var sb = new StringBuilder();
        using (var sha256 = SHA256.Create())
        {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
            foreach (var b in bytes)
            {
                sb.AppendFormat("{0:x2}", b);
            }
        }
        return sb.ToString();
    }

}