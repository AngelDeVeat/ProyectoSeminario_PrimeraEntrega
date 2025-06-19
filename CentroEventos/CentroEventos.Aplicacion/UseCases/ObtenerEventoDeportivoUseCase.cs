namespace CentroEventos.Aplicacion;

public class ObtenerEventoDeportivoUseCase
{
    private IRepositorioEventoDeportivo _ievento;
    public ObtenerEventoDeportivoUseCase(IRepositorioEventoDeportivo ievento)
    {
        _ievento = ievento;
    }
    public EventoDeportivo? Ejecutar(int id)
    {
        return _ievento.GetEventoDeportivo(id);
    }
}