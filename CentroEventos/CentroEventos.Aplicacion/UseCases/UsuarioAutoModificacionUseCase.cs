using System.Text;

namespace CentroEventos.Aplicacion;

public class UsuarioAutoModificacionUseCase
{
    private IRepositorioUsuario _iusuario;
    public UsuarioAutoModificacionUseCase(IRepositorioUsuario iusuario)
    {
        _iusuario = iusuario;
    }
    public void Ejecutar(Usuario usuarioadmin,Usuario usuario, string contraseña)
    {
        // no hace falta esto
        if (usuario.CorreoElectronico != usuarioadmin.CorreoElectronico)
          if (!Validador_Usuario.isUnique_Email(usuarioadmin.CorreoElectronico, _iusuario))
           throw new EntidadNotFoundException("el usuario que se quiere modificar no existe");
        if (Validador_Usuario.isEmpty_Nombre(usuario.Nombre))
            throw new ValidacionException("la validacion fallo debido a que el campo Nombre de la clase Usuario esta vacio");
        if (Validador_Usuario.isEmpty_Apellido(usuario.Apellido))
            throw new ValidacionException("la validacion fallo debido a que el campo Apellido de la clase Usuario esta vacio");
        if (Validador_Usuario.isEmpty_Email(usuario.CorreoElectronico))
            throw new ValidacionException("la validacion fallo debido a que el campo CorreoElectronico de la clase Usuario esta vacio");
        //string contraseña = Encoding.UTF8.GetString(usuario.Contraseña);
            if (Validador_Usuario.isEmpty_Contraseña(contraseña))
                throw new ValidacionException("la validacion fallo debido a que el campo Contraseña de la clase Usuario esta vacio");
        if (!Validador_Usuario.ContraseñaValida(contraseña))
            throw new ValidacionException("la validacion fallo debiado a que la contraseña ingresada no es valida");
        if (!Validador_Usuario.CorreoElectronicoValido(usuario.CorreoElectronico))
            throw new ValidacionException("la validacion fallo debido a el campo CorreoElectronico no es valido");

        usuario.ID = usuarioadmin.ID;
        _iusuario.ModificarUsuario(usuario, contraseña);
    }
}