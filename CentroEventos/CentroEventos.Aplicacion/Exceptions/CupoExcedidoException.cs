using System;

namespace CentroEventos.Aplicacion;

public class CupoExcedidoException : Exception
{
    public CupoExcedidoException()
        :base("Se ha intentado realizar una reserva a un evento deportivo sin cupo"){}
    
    public CupoExcedidoException(string message):base(message){}
    public CupoExcedidoException(string reserva, string evento)
        :base($"Se intento registras la reserva '{reserva}' en el evento '{evento}' el cual no tiene cupos"){}

    public CupoExcedidoException(string message, Exception inner): base(message, inner) { }
}
