using System.Data;

namespace CentroEventos.Aplicacion;

public class EventoDeportivo
{
    public int ID { get; set; }
    public string Nombre { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public DateTime FechaHoraInicio { get; set; }
    public double DuracionHoras { get; set; }
    public int CupoMaximo { get; set; }
    public int ResponsableID { get; set; }
    public EventoDeportivo() { }
    public EventoDeportivo(string? nombre, int cupoMaximo, DateTime f, double duracion, string? descripcion, int responsable)
    {
        if (nombre != null)
            Nombre = nombre;
        else
            Nombre = "";
        CupoMaximo = cupoMaximo;
        FechaHoraInicio = f;
        DuracionHoras = duracion;
        if (descripcion != null)
            Descripcion = descripcion;
        else
            Descripcion = "";
        ResponsableID = responsable;
    }
    public EventoDeportivo(int id, string? nombre, int cupoMaximo, DateTime f, double duracion, string? descripcion, int responsable) : this(nombre, cupoMaximo, f, duracion, descripcion, responsable)
    {
        ID = id;
    }
    public override string ToString()
    {
        return $"[ID : {ID}]\n" +
               $"[Nombre: {Nombre}] \n" +
               $"[Descripcion : {Descripcion}] \n" +
               $"[Fecha de Inicio : {FechaHoraInicio}] \n" +
               $"[Duracion : {DuracionHoras}]\n" +
               $"[Cupo Maximo : {CupoMaximo}] \n" +
               $"[Responsable ID : {ResponsableID}] \n";
    }

}