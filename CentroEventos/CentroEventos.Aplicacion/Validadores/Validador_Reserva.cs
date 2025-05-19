using System;

namespace CentroEventos.Aplicacion;

public class Validador_Reserva
{
    // revisa que la persona que reserva exista
    public static bool exist_PersonaId(int PersonaId, IRepositorioPersona persona)
    {
        bool r = false;

        if (persona.GetPersona(PersonaId) != null) r = true;

        return r;
    }
    // revisa que el evento a reservar exista
    public static bool exist_EventoDeportivoId(int id, IRepositorioEventoDeportivo ed)
    {
        bool r = false;

        if (ed.GetEventoDeportivo(id) != null) r = true;

        return r;
    }
    // revisa que la persona que reserva no tenga reservado el mismo evento ya
    public static bool isUnique_EventoDeportivoId(int persona_id, int evento_id, IRepositorioReserva reserva)
    {
        bool r = true;
        List<Reserva> reservas = reserva.ListarReservas();

        foreach (Reserva re in reservas)
        {
            if (re.PersonaID == persona_id && re.EventoDeportivoID == evento_id)
            {
                r = false;
                break;
            }
        }
        return r;
    }

    // (decile a emi que no hace falta poner la variable cantidad de reservas)
    // revisa que el evento deportivo a reservar aun tenga cupos
    public static bool CuposDisponibles(int evento_id, IRepositorioReserva reserva, IRepositorioEventoDeportivo ed)
    {
        bool r = false;
        List<Reserva> reservas = reserva.ListarReservas();
        // obtiene la cantidad total (incluso de otras personas) de reservas del evento deportivo
        int ocupados = 0;
        foreach (Reserva re in reservas)
        {
            if (re.EventoDeportivoID == evento_id) ocupados++;
        }
        EventoDeportivo? e = ed.GetEventoDeportivo(evento_id);
        if (e != null && ocupados < e.CupoMaximo) r = true;

        return r;
    }
    
    public static bool exist_ID(int id, IRepositorioReserva reserva)
    {
        bool r = false;

        if (reserva.GetEventoDeportivo(id) != null) r = true;

        return r;
    }
}
