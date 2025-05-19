using System;
using System.Runtime.Serialization;

namespace CentroEventos.Aplicacion;

public static class Validador_EventoDeportivo
{
    public static bool Validar_NombreVacio(string nombre) => nombre == "";
    public static bool Validar_DescripcionVacio(string descripcion) => descripcion == "";
    public static bool Validar_FechaCorrecta(DateTime fecha) => fecha >= DateTime.Today;
    public static bool isCorrect_CupoMaximo(int cupo) => cupo > 0;
    public static bool isCorrect_DuracionHoras(int horas) => horas > 0;
    // Recibe el id del responsable del evento y revisa si esa id existe en el repositorio de personas 
    public static bool exist_ResponsableId(int id, IRepositorioPersona persona)
    {
        bool r = false;

        List<Persona> personas = persona.ListarPersonas();

        int i = 0;
        while (!r && i < personas.Count)
        {
            if (personas[i].id == id) r = true;
            else i++;
        }

        return r;
    }

    public static bool exist_ID(int id, IRepositorioEventoDeportivo ed)
    {
        bool r = false;

        if (ed.GetEventoDeportivo(id) != null) r = true;

        return r;
    }
    
    // revisa si el evento deportivo cuya id se pasa por parametros tiene alguna reserva
    public static bool hasReservas(int id, IRepositorioReserva ireserva)
    {
        bool r = false;

        List<Reserva> reservas = ireserva.ListarReservas();
        foreach (Reserva idx in reservas)
        {
            if (idx.EventoDeportivoID == id)
            {
                r = true;
                break;
            }
        }
        return r;
    }
}
