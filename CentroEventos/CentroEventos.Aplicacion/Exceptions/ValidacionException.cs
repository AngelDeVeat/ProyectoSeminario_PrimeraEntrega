using System;

namespace CentroEventos.Aplicacion;

public class ValidacionException : Exception
{
    public ValidacionException()
        :base("La validacion de una entidad a fallado. Puede deberse a: \n"
              + "Dato obligatorio ausente \n"
              + "Dato con formato incorrecto \n"
              + "Regla de validacion simple a fallado"){}

    public ValidacionException(string message):base(message){}
    public ValidacionException(string message, Exception inner): base(message, inner) { }
}
