using System;

namespace CentroEventos.Aplicacion;

public static class Validador_Persona
{
    public static bool isEmpty_Nombre(string nombre) => nombre == "";
    public static bool isEmpty_Apellido(string apellido) => apellido == "";
    public static bool isEmpty_Email(string email) => email == "";
    public static bool isEmpty_DNI(int dni) => dni == 0;

    // Recibe un DNI y revisa si ya existe una persona en el repositorio de personas con ese dni 
    public static bool isUnique_DNI(int dni, IRepositorioPersona persona)
    {
        bool r = false;

        List<Persona> personas = persona.ListarPersonas();

        int i = 0;
        while (!r && i < personas.Count)
        {
            if (personas[i].DNI == dni) r = true;
            else i++;
        }

        return r;
    }
    // Recibe un email y revisa si ya existe una persona en el repositorio de personas con ese email
    public static bool isUnique_Email(string email, IRepositorioPersona persona)
    {
        bool r = false;

        List<Persona> personas = persona.ListarPersonas();

        int i = 0;
        while (!r && i < personas.Count)
        {
            if (personas[i].Email == email) r = true;
            else i++;
        }

        return r;
    }

    // revisa si la persona cuya id se pasa por parametros tiene alguna reserva
    public static bool hasReservas(int id, IRepositorioReserva ireserva)
    {
        bool r = false;

        List<Reserva> reservas = ireserva.ListarReservas();
        foreach (Reserva idx in reservas)
        {
            if (idx.PersonaID == id)
            {
                r = true;
                break;
            }
        }
        return r;
    }
    public static bool exist_ID(int id, IRepositorioPersona persona)
    {
        bool r = false;

        if (persona.GetPersona(id) != null) r = true;
        
        return r;
    }
}
