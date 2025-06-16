namespace CentroEventos.Aplicacion;

public class ListarUsuariosUseCase
{
    private IRepositorioUsuario _iusuario;
    private IServicioAutorizacion _autorizacion;
    public ListarUsuariosUseCase(IRepositorioUsuario iusuario, IServicioAutorizacion autorizacion)
    {
        _iusuario = iusuario;
        _autorizacion = autorizacion;
    }
    public List<Usuario> Ejecutar(Usuario usuario)
    {
        Permiso permiso = new Permiso();
        permiso = Permiso.ListarUsuarios;
        if (!_autorizacion.PoseeElPermiso(usuario.Permisos, permiso))
            throw new FalloAutorizacionException(usuario.Nombre, "Listar Usuarios");
        return _iusuario.ListarUsuarios();
    }
}