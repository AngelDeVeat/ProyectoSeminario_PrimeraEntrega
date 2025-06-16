namespace CentroEventos.Aplicacion.UseCases;

public class RegistrarseUseCase
{
    private IRepositorioUsuario _iusuario;
    public RegistrarseUseCase(IRepositorioUsuario iusuario)
    {
        _iusuario = iusuario;
    }
    public void Ejecutar(Usuario usuario)
    {
         if (!Validador_Usuario.isEmpty_Nombre(usuario.Nombre))
            throw new ValidacionException("la validacion fallo debido a que el campo Nombre de la clase Usuario esta vacio");
        if (!Validador_Usuario.isEmpty_Apellido(usuario.Apellido))
            throw new ValidacionException("la validacion fallo debido a que el campo Apellido de la clase Usuario esta vacio");
        if (!Validador_Usuario.isEmpty_Email(usuario.CorreoElectronico))
            throw new ValidacionException("la validacion fallo debido a que el campo CorreoElectronico de la clase Usuario esta vacio");
        if (!Validador_Usuario.isUnique_Email(usuario.CorreoElectronico, _iusuario))
            throw new DuplicadoException("la validacion fallo debido a que el Correo Electonico utilizado ya esta registado");
        if (!Validador_Usuario.isEmpty_Contraseña(usuario.Contraseña))
            throw new ValidacionException("la validacion fallo debido a que el campo Contraseña de la clase Usuario esta vacio");
        if (!Validador_Usuario.ContraseñaValida(usuario.Contraseña))
            throw new ValidacionException("la validacion fallo debiado a que la contraseña ingresada no es valida");
        if (!Validador_Usuario.CorreoElectronicoValido(usuario.CorreoElectronico))
            throw new ValidacionException("la validacion fallo debido a el campo CorreoElectronico no es valido");
        _iusuario.AgregarUsuario(usuario);
    }
}