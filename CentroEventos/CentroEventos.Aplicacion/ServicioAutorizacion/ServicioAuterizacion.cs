namespace CentroEventos.Aplicacion;
public class ServicioAutorizacion : IServicioAutorizacion {
    public bool PoseeElPermiso(List<Permiso> permisos, Permiso permiso)
    {
        if (permisos.Contains(permiso) || permisos.Contains(Permiso.Todos))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}