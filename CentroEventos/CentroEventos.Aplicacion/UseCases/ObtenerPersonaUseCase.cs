namespace CentroEventos.Aplicacion;

public class ObtenerPersonaUseCase
{
    private IRepositorioPersona _ipersona;
    public ObtenerPersonaUseCase(IRepositorioPersona ipersona)
    {
        _ipersona = ipersona;
    }
    public Persona? Ejecutar(int ID)
    {
        return _ipersona.GetPersona(ID);
    }
}