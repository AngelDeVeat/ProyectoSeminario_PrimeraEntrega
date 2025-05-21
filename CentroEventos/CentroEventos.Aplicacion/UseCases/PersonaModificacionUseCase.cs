using System;

namespace CentroEventos.Aplicacion.UseCases;

public class PersonaModificacionUseCase
{
    private IRepositorioPersona _ipersona;
    private IServicioAutorizacion _autorizacion;
    public PersonaModificacionUseCase(IRepositorioPersona ipersona, IServicioAutorizacion autorizacion)
    {
        _ipersona = ipersona;
        _autorizacion = autorizacion;
    }

    public void Modificacion(Persona persona, int IdUsuario)
    {
        Permiso permiso = new Permiso();
        if (!_autorizacion.PoseeElPermiso(IdUsuario, permiso))
            throw new FalloAutorizacionException(IdUsuario, "Modificacion");

        if (!Validador_Persona.exist_ID(persona.ID, _ipersona))
            throw new EntidadNotFoundException("El id al que se esta intentando modificar no existe");
        else
        {
            Persona? per = _ipersona.GetPersona(persona.ID);
            if (per != null && persona.DNI == per.DNI && persona.Email == per.Email)
            {
                if (Validador_Persona.isEmpty_Apellido(persona.Apellido))
                    throw new ValidacionException("Validacion fallada debido a que el campo Apellido de la clase Persona esta vacio");
                if (Validador_Persona.isEmpty_DNI(persona.DNI))
                    throw new ValidacionException("Validacion fallada debido a que el campo DNI de la clase Persona esta vacio");
                if (Validador_Persona.isEmpty_Email(persona.Email))
                    throw new ValidacionException("Validacion fallada debido a que el campo Email de la clase Persona esta vacio");
                if (Validador_Persona.isEmpty_Nombre(persona.Nombre))
                    throw new ValidacionException("Validacion fallada debido a que el campo Nombre de la clase Persona esta vacio");

                _ipersona.ModificarPersona(persona);
            }
            else
            {
                if (Validador_Persona.isEmpty_Apellido(persona.Apellido))
                    throw new ValidacionException("Validacion fallada debido a que el campo Apellido de la clase Persona esta vacio");
                if (Validador_Persona.isEmpty_DNI(persona.DNI))
                    throw new ValidacionException("Validacion fallada debido a que el campo DNI de la clase Persona esta vacio");
                if (Validador_Persona.isEmpty_Email(persona.Email))
                    throw new ValidacionException("Validacion fallada debido a que el campo Email de la clase Persona esta vacio");
                if (Validador_Persona.isEmpty_Nombre(persona.Nombre))
                    throw new ValidacionException("Validacion fallada debido a que el campo Nombre de la clase Persona esta vacio");

                if (Validador_Persona.isUnique_DNI(persona.DNI, _ipersona))
                    throw new DuplicadoException("Validacion fallada debido a que se intento modificar una instancia de la clase Persona con un DNI ya existente");
                if (Validador_Persona.isUnique_Email(persona.Email, _ipersona))
                    throw new DuplicadoException("Validacion fallada debido a que se intento modificar una instancia de la clase Persona con un Email ya existente");

                _ipersona.ModificarPersona(persona);
            }
        }

    }
}
