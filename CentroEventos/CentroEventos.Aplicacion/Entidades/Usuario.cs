using System;

namespace CentroEventos.Aplicacion;

public class Usuario
{
    public String Nombre { get; set; } = "";
    public String Apellido { get; set; } = "";
    public String CorreoElectronico { get; set; } = "";
    public String Contraseña { get; set; } = "";
    public int ID { get; set; }
    public List<Permiso> Permisos { get; set; } = new List<Permiso>();
    public Usuario(string nombre, string apellido, string correo, string cotraseña)
    {
        Nombre = nombre;
        Apellido = apellido;
        CorreoElectronico = correo;
        Contraseña = cotraseña;
    }
    protected Usuario() { }
    public override string ToString()
    {
        String devolver = "Id del usuario : " + ID + " Nombre de Usuario : " + Nombre + " Apellido : " + Apellido + " Correo Electronico : " + CorreoElectronico + " Contraseña : " + Contraseña + " Permisos : ";
        foreach (Permiso p in Permisos)
        {
            devolver += p + ", ";

        }
        return devolver;
    }
    public Usuario(int id, string nombre, string apellido, string correo, string cotraseña) : this(nombre, apellido, correo, cotraseña)
    {
        ID = id;
    }

}