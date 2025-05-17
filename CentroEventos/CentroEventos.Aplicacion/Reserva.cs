public class Reserva{
    public int ID{get;  set;}
    public int Persona{get;  set;}
    public int ActividadDeportiva{get; set;}
    public Reserva(){}
    public Reserva(int per, int act){
        Persona=per;
        ActividadDeportiva=act;
    }
    public override string ToString()
    {
        return "ID : "+ID+", Persona : "+Persona+", Actividad Depotiva : "+ActividadDeportiva;
    }
}