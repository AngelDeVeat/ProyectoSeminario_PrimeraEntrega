using System;

namespace CentroEventos.Aplicacion;

public class ListarAsistenciaAEventoUseCase
{
    private IRepositorioReserva _ireserva;
    private IRepositorioPersona _ipersona;
    public ListarAsistenciaAEventoUseCase(IRepositorioReserva ireserva, IRepositorioPersona ipersona)
    {
        _ipersona = ipersona;
        _ireserva = ireserva;
    }

    public List<Persona> Ejecutar(int evento_id)
    {
        List<Reserva> reservas = _ireserva.ListarReservas();
        List<Persona> asistentes = new List<Persona>();

        foreach (Reserva idx in reservas)
        {
            if (idx.EventoDeportivoID == evento_id)
            {
                Persona? persona = _ipersona.GetPersona(idx.PersonaID);
                if (persona != null && idx.EstadoAsistencia == Presente)
                    asistentes.Add(persona);
            }
        }
        return asistentes;
    }
}
