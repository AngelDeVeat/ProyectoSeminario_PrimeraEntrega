using System.Data.Common;

namespace CentroEventos.Aplicacion;

public class Persona
{
    public int ID { get; set; }
    public int DNI { get; set; }
    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Email { get; set; } = "";
    public Persona() { }
    public Persona(int numeroDeCarnet, string nombre, string apellido, string telefono, string correoElectronico)
    {
        DNI = numeroDeCarnet;
        Nombre = nombre;
        Apellido = apellido;
        Telefono = telefono;
        Email = correoElectronico;
    }
    public Persona(int id, int numeroDeCarnet, string nombre, string apellido, string direccion, string correoElectronico) : this(numeroDeCarnet, nombre, apellido, direccion, correoElectronico)
    {
        ID = id;
    }
    public override string ToString()
    {
        return $"[ID : {ID}] \n" +
               $"[DNI : {DNI}] \n" +
               $"[Nombre : {Nombre}]\n" +
               $"[Apellido : {Apellido}]\n" +
               $"[Telefono : {Telefono}]\n" +
               $"[Email : {Email}]\n";
    }

}