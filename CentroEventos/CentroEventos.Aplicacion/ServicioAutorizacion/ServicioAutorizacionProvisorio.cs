using System;

namespace CentroEventos.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IDUsuario, Permiso permiso)
    {
        if (IDUsuario == 1) return true;
        else return false;
    }
}
