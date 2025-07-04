using System.Security.Cryptography;
using System.Text;

namespace CentroEventos.Aplicacion;

public class UsuarioModificacionUseCase
{
    private IRepositorioUsuario _iusuario;
    private IServicioAutorizacion _autorizacion;
    public UsuarioModificacionUseCase(IRepositorioUsuario iusuario, IServicioAutorizacion autorizacion)
    {
        _iusuario = iusuario;
        _autorizacion = autorizacion;
    }
    public void Ejecutar(Usuario usuarioadmin, Usuario usuario, string contraseña, bool esAutoModificacion)
    {
        Permiso permiso = Permiso.UsuarioModificacion;
        if (!esAutoModificacion)
        {
            if (!_autorizacion.PoseeElPermiso(usuarioadmin.Permisos, permiso))
                throw new FalloAutorizacionException(usuarioadmin.Nombre, "Modificacion");
        }
        if (!Validador_Usuario.Exist_Usuario(usuario.ID, _iusuario))
            throw new EntidadNotFoundException("el usuario que se quiere modificar no existe");
        if (Validador_Usuario.isEmpty_Nombre(usuario.Nombre))
            throw new ValidacionException("la validacion fallo debido a que el campo Nombre de la clase Usuario esta vacio");
        if (Validador_Usuario.isEmpty_Apellido(usuario.Apellido))
            throw new ValidacionException("la validacion fallo debido a que el campo Apellido de la clase Usuario esta vacio");
        if (Validador_Usuario.isEmpty_Email(usuario.CorreoElectronico))
            throw new ValidacionException("la validacion fallo debido a que el campo CorreoElectronico de la clase Usuario esta vacio");

        Usuario? usuario_or = _iusuario.GetUsuario(usuario.ID);  
        
        if (usuario_or != null && usuario_or.CorreoElectronico != usuario.CorreoElectronico)
            if (!Validador_Usuario.isUnique_Email(usuario.CorreoElectronico, _iusuario))
                throw new DuplicadoException("la validacion fallo debido a que el Correo Electonico utilizado ya esta registado");

        //string contraseña = Encoding.UTF8.GetString(usuario.Contraseña);
        if (Validador_Usuario.isEmpty_Contraseña(contraseña))
            throw new ValidacionException("la validacion fallo debido a que el campo Contraseña de la clase Usuario esta vacio");
        if (!Validador_Usuario.ContraseñaValida(contraseña))
            throw new ValidacionException("la validacion fallo debiado a que la contraseña ingresada no es valida");
        if (!Validador_Usuario.CorreoElectronicoValido(usuario.CorreoElectronico))
            throw new ValidacionException("la validacion fallo debido a el campo CorreoElectronico no es valido");

        // aplicar hash a la contraseña 
        SHA256 sha256 = SHA256.Create();
        byte[] hashValue;
        hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

        _iusuario.ModificarUsuario(usuario, hashValue);
    }
}