using System;
using System.Security.Cryptography.X509Certificates;

namespace CentroEventos.Aplicacion;

public class ListarEventosConCupoDisponibleUseCase
{
    private class CampoLista
    {
        public int cantidad;
        public EventoDeportivo evento;

        public CampoLista(EventoDeportivo evento)
        {
            cantidad = 1;
            this.evento = evento;
        }
    }

    private IRepositorioEventoDeportivo _ievento;
    private IRepositorioReserva _ireserva;
    public ListarEventosConCupoDisponibleUseCase (IRepositorioEventoDeportivo ievento, IRepositorioReserva ireserva)
    {
        _ievento = ievento;
        _ireserva = ireserva;
    }
    // si el evento pasado esta en la lista, devuelve su pos, sino devuelve -1
    private int IsInLista(int id, List<CampoLista> lista)
    {
        int pos = -1;
        for (int i = 0; i < lista.Count; i++)
        {
            if (id == lista[i].evento.ID)
            {
                pos = i;
                break;
            }
        }
        return pos;
    }

    public List<EventoDeportivo> Ejecutar()
    {
        List<Reserva> reservas = _ireserva.ListarReservas();
        List<CampoLista> eventos_temp = new List<CampoLista>();
        List<EventoDeportivo> eventos_fin = new List<EventoDeportivo>();
        if (reservas.Count == 0) //si no hay reservas y la fecha del evento es futura si o si tiene cupos disponibles 
        {
            List<EventoDeportivo> eventos = _ievento.ListarEventosDeportivos();
            foreach (EventoDeportivo even in eventos)
            {
                if (even.FechaHoraInicio > DateTime.Now )
                {
                    eventos_fin.Add(even);
                }
            }
        }

        foreach (Reserva idx in reservas)
        {
            EventoDeportivo? ev = _ievento.GetEventoDeportivo(idx.EventoDeportivoID);
            // revisa si el evento tiene fecha futura
            if (ev != null && ev.FechaHoraInicio > DateTime.Now)
            {
                int pos = IsInLista(ev.ID, eventos_temp);

                if (pos == -1)
                {
                    CampoLista nuevo = new CampoLista(ev);
                    eventos_temp.Add(nuevo);
                }
                else
                {
                    eventos_temp[pos].cantidad++;
                }
            }
        }

        foreach (CampoLista idx in eventos_temp)
        {
            if (idx.evento.CupoMaximo > idx.cantidad) eventos_fin.Add(idx.evento);
        }

        return eventos_fin;
    }
}
