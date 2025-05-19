
public class EventoDeportivo{
    public int ID{get; set;}
    public string Nombre {get; set;}="";
    public int DiasDisponibles{get; set;}
    public int CuposOcupados{get; set;}
    public int CupoMaximo{get;  set;}
    public EventoDeportivo(){}
     public EventoDeportivo( string nombre, int diasDisponibles, int cupoMaximo)
    {
        Nombre = nombre;
        DiasDisponibles = diasDisponibles;
        CupoMaximo = cupoMaximo;
        CuposOcupados=0;
    }
    public override string ToString()
    {
        return "ID : "+ ID + " Nombre : "+Nombre+" Dias Disponibles : "+ DiasDisponibles+ " Cupo Maximo : "+ CupoMaximo;
    }
    
}