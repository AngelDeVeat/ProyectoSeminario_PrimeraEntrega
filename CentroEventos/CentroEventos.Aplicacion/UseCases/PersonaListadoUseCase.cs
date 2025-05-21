using System;

namespace CentroEventos.Aplicacion.UseCases;

public class PersonaListadoUseCase
{
    private IRepositorioPersona _ipersona;
    public PersonaListadoUseCase(IRepositorioPersona ipersona)
    {
        _ipersona = ipersona;
    }

    public List<Persona> Listado()
    {
        return _ipersona.ListarPersonas();
    }
}
