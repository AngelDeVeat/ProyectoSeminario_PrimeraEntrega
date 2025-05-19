using System;

namespace CentroEventos.Aplicacion;

public class OperacionInvalidaException : Exception
{
    public OperacionInvalidaException()
        :base("Se ha intentado realizar una operacion no permitida por las reglas de negocio"){}
    
    public OperacionInvalidaException(string message):base(message){}

    public OperacionInvalidaException(string message, Exception inner): base(message, inner) { }
}
