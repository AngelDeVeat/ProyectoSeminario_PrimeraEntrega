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
        Permiso permiso= Permiso.DarPermisos;
        if (!_autorizacion.PoseeElPermiso(usuarioadmin.Permisos, permiso))
            throw new FalloAutorizacionException(usuarioadmin.Nombre, "Dar Permisos");
        if (!Validador_Usuario.Exist_Usuario(usuario.ID, _iusuario))
            throw new EntidadNotFoundException("el usuario al cual se quiere modificar los permisos no existe");
        _iusuario.ModificarPermisosUsuario(usuario.ID, permisos);
    }
}