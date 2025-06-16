using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
    // LO DE INICIALIZAR TENDRIAS QUE DEJAR DE HACERLO A CADA RATO Y METERLO EN OTRO LADO creo
    public RepositorioUsuario() { }

    public void AgregarUsuario(Usuario usuario)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        context.Add(usuario);
        context.SaveChanges();
    }
    public List<Usuario> ListarUsuarios()
    {
        CentroEventosSqlite.Inicializar();

        var listado = new List<Usuario>();

        using var context = new CentroEventosContext();
       
        foreach (Usuario u in context.Usuarios)
        {
            listado.Add(u);
        }

        return listado;
    }
    public Usuario? GetUsuario(int ID)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();

        var Usuario = context.Usuarios.Where(a => a.ID == ID).SingleOrDefault();

        return Usuario;
    }

    public void ModificarUsuario(Usuario usuario)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        var aModificar = context.Usuarios.Where(a => a.ID == usuario.ID).SingleOrDefault();
        if (aModificar != null)
        {
            // VERIFICA QUE ESTO ESTE BIEN CAPO
            aModificar.Apellido = usuario.Apellido;
            aModificar.Nombre = usuario.Nombre;
            aModificar.Contraseña = usuario.Contraseña;
            aModificar.CorreoElectronico = usuario.CorreoElectronico;

            context.SaveChanges();   
        }
    }
    public void ModificarPermisosUsuario(int id, List<Permiso> permisos)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        var aModificar = context.Usuarios.Where(a => a.ID == id).SingleOrDefault();
        if (aModificar != null)
        {
            // VERIFICA QUE ESTO ESTE BIEN CAPO
            aModificar.Permisos = permisos;

            context.SaveChanges();   
        }
    }

    public void EliminarUsuario(int ID)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        var aBorrar = context.Usuarios.Where(a => a.ID == ID).SingleOrDefault();
        if (aBorrar != null)
        {
            context.Remove(aBorrar);
            context.SaveChanges();
        }
    }
}
