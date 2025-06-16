using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioReserva : IRepositorioReserva
{
    // LO DE INICIALIZAR TENDRIAS QUE DEJAR DE HACERLO A CADA RATO Y METERLO EN OTRO LADO creo
    public RepositorioReserva() { }

    public void AgregarReserva(Reserva reserva)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        context.Add(reserva);
        context.SaveChanges();
    }
    public List<Reserva> ListarReservas()
    {
        CentroEventosSqlite.Inicializar();

        var listado = new List<Reserva>();

        using var context = new CentroEventosContext();
        foreach (Reserva r in context.Reservas)
        {
            listado.Add(r);
        }

        return listado;
    }
    public Reserva? GetReserva(int ID)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();

        var Reserva = context.Reservas.Where(a => a.ID == ID).SingleOrDefault();

        return Reserva;
    }

    public void ModificarReserva(Reserva reserva)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        var aModificar = context.Reservas.Where(a => a.ID == reserva.ID).SingleOrDefault();
        if (aModificar != null)
        {
            aModificar.EstadoAsistencia = reserva.EstadoAsistencia;
            aModificar.EventoDeportivoID = reserva.EventoDeportivoID;
            aModificar.FechaAltaReserva = reserva.FechaAltaReserva;
            aModificar.ID = reserva.ID;
            aModificar.PersonaID = reserva.PersonaID;

            context.SaveChanges();   
        }
    }

    public void EliminarReserva(int ID)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        var aBorrar = context.Reservas.Where(a => a.ID == ID).SingleOrDefault();
        if (aBorrar != null)
        {
            context.Remove(aBorrar);
            context.SaveChanges();
        }
    }
}
