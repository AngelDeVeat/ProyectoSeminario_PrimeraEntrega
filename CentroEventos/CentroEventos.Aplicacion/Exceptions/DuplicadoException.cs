using System;

namespace CentroEventos.Aplicacion;

public class DuplicadoException : Exception
{
    public DuplicadoException()
        :base("Se ha intentado registrar una entidad con un campo unico duplicado"){}
    
    public DuplicadoException(string message):base(message){}

    public DuplicadoException(string message, Exception inner): base(message, inner) { }
}
