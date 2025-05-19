using System;

namespace CentroEventos.Aplicacion;

public class FalloAutorizacionException : Exception
{
    
    public FalloAutorizacionException()
        :base("Un usuario a intentado realizar una operacion para la cual no tiene permiso"){}

    public FalloAutorizacionException(int user_id, string op_failed) 
        : base($"El usuario de id {user_id} no tiene permiso para realizar la siguiente operacion: {op_failed}")
    {}
    public FalloAutorizacionException(string message) : base(message){}

    public FalloAutorizacionException(string message, Exception inner): base(message, inner) { }
}
