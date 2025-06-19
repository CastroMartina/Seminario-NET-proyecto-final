using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarPersonaUseCase(IRepositorioPersona repoP, IRepositorioReserva repoR, IRepositorioEventoDeportivo repoE, IServicioAutorizacion servicio, ValidadorPersona validador) : PersonaUseCase(repoP)
{
    public void Ejecutar(int usuarioId, int personaId)
    {
        if (servicio.PoseeElpermiso(usuarioId, Permiso.PersonaBaja))
        {
            Validador resultado = validador.ValidarOperacion(repoE, repoR, personaId);
            if (!resultado.EsValido)
            {
                throw new OperacionInvalidaException(resultado.Mensaje);
            }
            Repositorio.EliminarPersona(personaId);
        }
        else
        {
            throw new FalloAutorizacionException("No tiene permiso para eliminar personas.");
        }
    }

}
