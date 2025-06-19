using System;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioAutorizacion
{
    bool PoseeElpermiso(int usuarioId, Permiso permiso);
}
