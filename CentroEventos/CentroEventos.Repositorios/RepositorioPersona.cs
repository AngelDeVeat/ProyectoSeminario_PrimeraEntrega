using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    // LO DE INICIALIZAR TENDRIAS QUE DEJAR DE HACERLO A CADA RATO Y METERLO EN OTRO LADO creo
    public RepositorioPersona() { }

    public void AgregarPersona(Persona persona)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        context.Add(persona);
        context.SaveChanges();
    }
    public List<Persona> ListarPersonas()
    {
        CentroEventosSqlite.Inicializar();

        var listado = new List<Persona>();

        using var context = new CentroEventosContext();
        foreach (Persona p in context.Personas)
        {
            listado.Add(p);
        }

        return listado;
    }
    public Persona? GetPersona(int ID)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();

        var Persona = context.Personas.Where(a => a.ID == ID).SingleOrDefault();

        return Persona;
    }

    public void ModificarPersona(Persona persona)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        var aModificar = context.Personas.Where(a => a.ID == persona.ID).SingleOrDefault();
        if (aModificar != null)
        {
            aModificar.Apellido = persona.Apellido;
            aModificar.DNI = persona.DNI;
            aModificar.Email = persona.Email;
            aModificar.ID = persona.ID;
            aModificar.Nombre = persona.Nombre;
            aModificar.Telefono = persona.Telefono;

            context.SaveChanges();
        }
    }

    public void EliminarPersona(int ID)
    {
        CentroEventosSqlite.Inicializar();

        using var context = new CentroEventosContext();
        var aBorrar = context.Personas.Where(a => a.ID == ID).SingleOrDefault();
        if (aBorrar != null)
        {
            context.Remove(aBorrar);
            context.SaveChanges();
        }
    }
}
