using System;
namespace CentroEventos.Aplicacion;

public interface IRepositorioUsuario
{
    void AgregarUsuario(Usuario usuario);
    List<Usuario> ListarUsuarios();
    Usuario? GetUsuario(int ID);
    void ModificarUsuario(Usuario usuario);
    void ModificarPermisosUsuario(int id, List<Permiso> permisos);
    void EliminarUsuario(int ID);
}
