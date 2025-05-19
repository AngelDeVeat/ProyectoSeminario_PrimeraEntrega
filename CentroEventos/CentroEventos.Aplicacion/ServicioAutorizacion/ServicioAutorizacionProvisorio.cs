using System;

namespace CentroEventos.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IDUsuario, Permisos permiso)
    {
        if (IDUsuario == 1) return true;
        else return false;
    }
}
