using System;
using System.Text;

namespace CentroEventos.Aplicacion;

public class Usuario
{
    public String Nombre { get; set; } = "";
    public String Apellido { get; set; } = "";
    public String CorreoElectronico { get; set; } = "";
    public byte[] Contraseña { get; set; } = Encoding.UTF8.GetBytes("");
    public int ID { get; set; }
    public List<Permiso> Permisos { get; set; } = new List<Permiso>();
    public Usuario(string nombre, string apellido, string correo)//, string cotraseña)
    {
        Nombre = nombre;
        Apellido = apellido;
        CorreoElectronico = correo;
        //byte[] contraseñaBytes = Encoding.UTF8.GetBytes(cotraseña);
        //Contraseña = contraseñaBytes;
    }
    protected Usuario() { }
    public override string ToString()
    {
        string devolver = "Id del usuario : " + ID + " Nombre de Usuario : " + Nombre + " Apellido : " + Apellido + " Correo Electronico : " + CorreoElectronico;

        //devolver += " Contraseña : " + Encoding.UTF8.GetString(Contraseña);

        devolver += " Permisos : ";
        foreach (Permiso p in Permisos)
        {
            devolver += p + ", ";

        }
        return devolver;
    }
    public Usuario(int id, string nombre, string apellido, string correo) : this(nombre, apellido, correo)//, cotraseña)
    {
        ID = id;
    }

}