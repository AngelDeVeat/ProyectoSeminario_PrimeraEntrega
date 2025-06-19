using System.Text.Encodings.Web;

namespace CentroEventos.Aplicacion;

public static class Validador_Usuario
{
    public static bool isEmpty_Nombre(string nombre) => nombre == "";
    public static bool isEmpty_Apellido(string apellido) => apellido == "";
    public static bool isEmpty_Email(string email) => email == "";
    public static bool isEmpty_Contraseña(string contraseña) => contraseña == "";
    public static bool isUnique_Email(string email, IRepositorioUsuario Usuario)
    {
        bool r = true;

        List<Usuario> usuarios = Usuario.ListarUsuarios();

        int i = 0;
        while (!r && i < usuarios.Count)
        {
            if (usuarios[i].CorreoElectronico == email) r = false;
            else i++;
        }

        return r;
    }
    public static bool ContraseñaValida(string contraseña)
    {
        if (contraseña.Length > 6)
            return true;
        else
            return false;
    }
    public static bool CorreoElectronicoValido(string correo)
    {
        if (correo.Contains('@') && correo.Contains('.'))
            return true;
        else
            return false;
    }
    public static bool Exist_Usuario(int id, IRepositorioUsuario Iusuario)
    {
        Usuario? usuario = Iusuario.GetUsuario(id);
        if (usuario == null)
            return false;
       else
         return true; 
    }

    
}