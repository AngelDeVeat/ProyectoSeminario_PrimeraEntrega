using System;

namespace CentroEventos.Aplicacion.UseCases;

public class PersonaAltaUseCase
{
    private IRepositorioPersona _ipersona;
    private IServicioAutorizacion _autorizacion;
    public PersonaAltaUseCase(IRepositorioPersona ipersona, IServicioAutorizacion autorizacion)
    {
        _ipersona = ipersona;
        _autorizacion = autorizacion;
    }

    public void Alta(Persona persona, Usuario usuario)
    {
        Permiso permiso = new Permiso();
        if (!_autorizacion.PoseeElPermiso(usuario.Permisos, permiso))
            throw new FalloAutorizacionException(usuario.Nombre, "Alta");

        if (Validador_Persona.isEmpty_Apellido(persona.Apellido))
            throw new ValidacionException("Validacion fallida debido a que el campo Apellido de la clase Persona esta vacio");
        if (Validador_Persona.isEmpty_DNI(persona.DNI))
            throw new ValidacionException("Validacion fallida debido a que el campo DNI de la clase Persona esta vacio");
        if (Validador_Persona.isEmpty_Email(persona.Email))
            throw new ValidacionException("Validacion fallida debido a que el campo Email de la clase Persona esta vacio");
        if (Validador_Persona.isEmpty_Nombre(persona.Nombre))
            throw new ValidacionException("Validacion fallida debido a que el campo Nombre de la clase Persona esta vacio");

        if (Validador_Persona.isUnique_DNI(persona.DNI, _ipersona))
            throw new DuplicadoException("Validacion fallida debido a que se intento crear una instancia de la clase Persona con un DNI ya existente");
        if (Validador_Persona.isUnique_Email(persona.Email, _ipersona))
            throw new DuplicadoException("Validacion fallida debido a que se intento crear una instancia de la clase Persona con un Email ya existente");

        _ipersona.AgregarPersona(persona);
    }
}
