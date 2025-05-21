using System;

namespace CentroEventos.Aplicacion;

public class ListarAsistenciaAEventoUseCase
{
    private IRepositorioReserva _ireserva;
    private IRepositorioPersona _ipersona;
    private IRepositorioEventoDeportivo _ievento;
    public ListarAsistenciaAEventoUseCase(IRepositorioReserva ireserva, IRepositorioPersona ipersona, IRepositorioEventoDeportivo ievento)
    {
        _ipersona = ipersona;
        _ireserva = ireserva;
        _ievento = ievento;
    }

    public List<Persona> Ejecutar(int evento_id)
    {
        List<Reserva> reservas = _ireserva.ListarReservas();
        List<Persona> asistentes = new List<Persona>();
        EventoDeportivo? evento = _ievento.GetEventoDeportivo(evento_id);
        if (evento != null && evento.FechaHoraInicio < DateTime.Now)
        {
            foreach (Reserva idx in reservas)
            {
                if (idx.EventoDeportivoID == evento_id)
                {
                    Persona? persona = _ipersona.GetPersona(idx.PersonaID);
                    if (persona != null && idx.EstadoAsistencia == Estado.Presente)
                        asistentes.Add(persona);
                }
            }
        }
        return asistentes;
        
    }
}
