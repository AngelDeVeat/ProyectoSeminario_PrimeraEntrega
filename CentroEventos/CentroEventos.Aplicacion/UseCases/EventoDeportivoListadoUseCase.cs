using System;

namespace CentroEventos.Aplicacion.UseCases;

public class EventoDeportivoListadoUseCase
{
    private IRepositorioEventoDeportivo _ievento;
    public EventoDeportivoListadoUseCase(IRepositorioEventoDeportivo ievento)
    {
        _ievento = ievento;
    }

    public List<EventoDeportivo> Listado()
    {
        return _ievento.ListarEventosDeportivos();
    }
}
