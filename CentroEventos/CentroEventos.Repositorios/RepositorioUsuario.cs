using System;
using System.Security.Cryptography;
using System.Text;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
    // LO DE INICIALIZAR TENDRIAS QUE DEJAR DE HACERLO A CADA RATO Y METERLO EN OTRO LADO creo
    public RepositorioUsuario() { }

    // el user paso como param no tiene ni la contraseña ni los permisos
    public void AgregarUsuario(Usuario usuario, string contraseña)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        // si es el primer user del sistema, le damos todos los permisos
        List<Permiso> permisos = new List<Permiso>();
        if (context.Usuarios.Count() == 0)
        {
            permisos.Add(Permiso.Todos);
        }
        usuario.Permisos.AddRange(permisos);

        // aplicar hash a la contraseña 
        SHA256 sha256 = SHA256.Create();
        byte[] hashValue;
        hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
        // damos al user la version hasheada de la contraseña
        usuario.Contraseña = hashValue;

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

        Usuario? Usuario = context.Usuarios.Where(a => a.ID == ID).SingleOrDefault();

        return Usuario;
    }

    public void ModificarUsuario(Usuario usuario, string contraseña)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        var aModificar = context.Usuarios.Where(a => a.ID == usuario.ID).SingleOrDefault();
        if (aModificar != null)
        {
            // VERIFICA QUE ESTO ESTE BIEN CAPO
            aModificar.Apellido = usuario.Apellido;
            aModificar.Nombre = usuario.Nombre;

            // aplicar hash a la contraseña 
            SHA256 sha256 = SHA256.Create();
            byte[] hashValue;
            hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
            // le damos al user la version hasheada de la nueva contraseña
            aModificar.Contraseña = hashValue;

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
            aModificar.Permisos.AddRange(permisos);

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
