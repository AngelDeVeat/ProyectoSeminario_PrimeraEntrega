namespace CentroEventos.Aplicacion;

public class UsuarioBajaUseCase
{
    private IRepositorioUsuario _iusuario;
    private IServicioAutorizacion _autorizacion;
    public UsuarioBajaUseCase(IRepositorioUsuario iusuario, IServicioAutorizacion autorizacion)
    {
        _iusuario = iusuario;
        _autorizacion = autorizacion;
    }
    public void Ejecutar(Usuario usuarioadmin, Usuario usuario)
    {
        Permiso permiso= Permiso.UsuarioBaja;
        if (!_autorizacion.PoseeElPermiso(usuarioadmin.Permisos, permiso))
            throw new FalloAutorizacionException(usuarioadmin.Nombre, "Baja");
        if (!Validador_Usuario.Exist_Usuario(usuario.ID, _iusuario))
            throw new EntidadNotFoundException("el usuario que se quiere dar de baja no existe");
        _iusuario.EliminarUsuario(usuario.ID);

    }
}