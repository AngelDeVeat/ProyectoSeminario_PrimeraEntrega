using System;

namespace CentroEventos.Aplicacion.Repositorios;

public interface IRepositorioUsuario
{
    void AgregarUsuario(Usuario usuario);
    List<Usuario> ListarUsuarios();
    Usuario? GetUsuario(int ID);
    void ModificarUsuario(Usuario usuario);
    void ModificarPermisosUsuario(int id, Permiso permisos);
    void EliminarUsuario(int ID);
}
