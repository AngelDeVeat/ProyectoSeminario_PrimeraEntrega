using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
    // LO DE INICIALIZAR TENDRIAS QUE DEJAR DE HACERLO A CADA RATO Y METERLO EN OTRO LADO creo
    public RepositorioEventoDeportivo() { }

    public void AgregarEventoDeportivo(EventoDeportivo evento)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        context.Add(evento);
        context.SaveChanges();
    }
    public List<EventoDeportivo> ListarEventosDeportivos()
    {
        CentroEventosSqlite.Inicializar();

        var listado = new List<EventoDeportivo>();

        using var context = new CentroEventosContext();
        foreach (EventoDeportivo ed in context.EventosDeportivos)
        {
            listado.Add(ed);
        }

        return listado;
    }
    public EventoDeportivo? GetEventoDeportivo(int ID)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();

        var EventoDeportivo = context.EventosDeportivos.Where(a => a.ID == ID).SingleOrDefault();

        return EventoDeportivo;
    }

    public void ModificarEventoDeportivo(EventoDeportivo evento)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        var aModificar = context.EventosDeportivos.Where(a => a.ID == evento.ID).SingleOrDefault();
        if (aModificar != null)
        {
            aModificar.CupoMaximo = evento.CupoMaximo;
            aModificar.Descripcion = evento.Descripcion;
            aModificar.DuracionHoras = evento.DuracionHoras;
            aModificar.FechaHoraInicio = evento.FechaHoraInicio;
            aModificar.ID = evento.ID;
            aModificar.Nombre = evento.Nombre;
            aModificar.ResponsableID = evento.ResponsableID;

            context.SaveChanges();   
        }
    }

    public void EliminarEventoDeportivo(int ID)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        var aBorrar = context.EventosDeportivos.Where(a => a.ID == ID).SingleOrDefault();
        if (aBorrar != null)
        {
            context.Remove(aBorrar);
            context.SaveChanges();
        }
    }
}
