using System;

namespace CentroEventos.Aplicacion;

public class EntidadNotFoundException : Exception
{
    public EntidadNotFoundException()
        :base("El id ingresado no corresponde a ninguna entidad"){}
    
    public EntidadNotFoundException(string message):base(message){}
    public EntidadNotFoundException(int id, string entidad)
        :base($"El id {id} de la entidad {entidad} no existe"){}

    public EntidadNotFoundException(string message, Exception inner): base(message, inner) { }
}
