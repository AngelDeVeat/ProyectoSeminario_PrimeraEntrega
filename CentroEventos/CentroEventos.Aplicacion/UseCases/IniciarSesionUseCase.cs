using System;
using System.Security.Cryptography;
using System.Text;

namespace CentroEventos.Aplicacion;

public class IniciarSesionUseCase
{
    private IRepositorioUsuario _iusuario;
    public IniciarSesionUseCase(IRepositorioUsuario iusuario)
    {
        _iusuario = iusuario;
    }
    public Usuario Ejecutar(string email, string contraseña)
    {
        Usuario? act = null;
        List<Usuario> usuarios = _iusuario.ListarUsuarios();
        foreach (Usuario u in usuarios)
        {
            if (u.CorreoElectronico == email)
            {
                act = u;
                break;
            }
        }

        if (act == null)
            throw new ValidacionException("El email ingresado no esta registrado en el sistema");

        // aplicar hash a la contraseña 
        SHA256 sha256 = SHA256.Create();
        byte[] hashValue;
        hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
        if (!act.Contraseña.SequenceEqual(hashValue))
            throw new ValidacionException("La contraseña ingresada es incorrecta");

        return act!;
    }
}
