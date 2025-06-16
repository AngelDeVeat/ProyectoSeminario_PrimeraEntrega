
using CentroEventos.Aplicacion;

public interface IServicioAutorizacion{
    public bool PoseeElPermiso(List<Permiso> permisos, Permiso permiso);

}