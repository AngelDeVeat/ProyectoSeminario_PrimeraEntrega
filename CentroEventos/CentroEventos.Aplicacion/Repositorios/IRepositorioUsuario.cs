using System;
namespace CentroEventos.Aplicacion;

public interface IRepositorioUsuario
{
    void AgregarUsuario(Usuario usuario, string contraseña);
    List<Usuario> ListarUsuarios();
    Usuario? GetUsuario(int ID);
    void ModificarUsuario(Usuario usuario, string contraseña);
    void ModificarPermisosUsuario(int id, List<Permiso> permisos);
    void EliminarUsuario(int ID);
}
