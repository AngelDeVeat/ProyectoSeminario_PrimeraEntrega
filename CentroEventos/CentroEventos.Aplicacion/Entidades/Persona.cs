using System.Data.Common;

public class Persona{
    public int ID{get;  set; }
    public int DNI{get;  set;}
    public string Nombre{get;  set;}="";
    public string Apellido{get;  set;}="";
    public string Direccion{get;  set;}="";
    public int Telefono{get;  set;}
    public string Facultad{get;  set;}="";
    public string Email{get;  set;}="";
    public Persona(){}
     public Persona( int numeroDeCarnet, string nombre, string apellido, string direccion, int telefono, string facultad, string correoElectronico)
    {
        DNI = numeroDeCarnet;
        Nombre = nombre;
        Apellido = apellido;
        Direccion = direccion;
        Telefono = telefono;
        Facultad = facultad;
        Email = correoElectronico;
    }
    public Persona( int id,int numeroDeCarnet, string nombre, string apellido, string direccion, int telefono, string facultad, string correoElectronico): this(numeroDeCarnet, nombre, apellido, direccion, telefono,  facultad,  correoElectronico) {
        ID=id;
    }
    public override string ToString()
    {
        return $"[ID : {ID}] \n" +
               $"[DNI : {DNI}] \n" +
               $"[Nombre : {Nombre}]\n" +
               $"[Apellido : {Apellido}]\n" +
               $"[Direccion : {Direccion}]\n" +
               $"[Telefono : {Telefono}]\n" +
               $"[Facultad: {Facultad}]\n" +
               $"[Email : {Email}]\n";
    }
    
}