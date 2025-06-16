namespace CentroEventos.Aplicacion;

public enum Estado
{
    Pendiente,
    Presente,
    Ausente
}
public class Reserva{
    public int ID{get;  set;}
    public int PersonaID{get;  set;}
    public int EventoDeportivoID{get; set;}
    public DateTime FechaAltaReserva{get; set;}
    public Estado EstadoAsistencia{get; set;}
    public Reserva(){}
    public Reserva(int per, int act){
        PersonaID=per;
        EventoDeportivoID=act;
    }
    public Reserva(int id,int per, int act, Estado asistencia) : this(per, act)
    {
        EstadoAsistencia = asistencia;
        ID = id;
    }
    public override string ToString()
    {
        return $"[ID : {ID}]\n" +
               $"[Persona ID : {PersonaID}]\n" +
               $"[Evento Deportivo ID : {EventoDeportivoID}]\n" +
               $"[Fecha de la Reserva : {FechaAltaReserva}]\n" +
               $"[Estado de Asistencia : {EstadoAsistencia}]\n";
    }
}