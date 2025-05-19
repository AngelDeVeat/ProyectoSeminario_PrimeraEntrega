public class Reserva{
    public int ID{get;  set;}
    public int PersonaID{get;  set;}
    public int EventoDeportivoID{get; set;}
    public Reserva(){}
    public Reserva(int per, int act){
        PersonaID=per;
        EventoDeportivoID=act;
    }
    public override string ToString()
    {
        return "ID : "+ID+", Persona : "+PersonaID+", Actividad Depotiva : "+EventoDeportivoID;
    }
}