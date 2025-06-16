namespace CentroEventos.Aplicacion;

public class DarPermisosUseCase
{
    private IRepositorioUsuario _iusuario;
    private IServicioAutorizacion _autorizacion;
    public DarPermisosUseCase(IRepositorioUsuario iusuario, IServicioAutorizacion autorizacion)
    {
        _iusuario = iusuario;
        _autorizacion = autorizacion;
    }
    public void Ejecutar(Usuario usuarioadmin, Usuario usuario, List<Permiso> permisos)
    {
        Permiso permiso;
        permiso = Permiso.DarPermisos;
        if (!_autorizacion.PoseeElPermiso(usuarioadmin.Permisos, permiso))
            throw new FalloAutorizacionException(usuarioadmin.Nombre, "Dar Permisos");
        if (!Validador_Usuario.Exist_Usuario(usuario.ID, _iusuario))
            throw new EntidadNotFoundException("el usuario que se quiere dar de baja o existe");
        _iusuario.ModificarPermisos(usuario.CorreoElectronico,permisos);
    }
}