using System;

namespace CentroEventos.Aplicacion.UseCases;

public class PersonaBajaUseCase
{
    private IRepositorioReserva _ireserva;
    private IRepositorioPersona _ipersona;
    private IServicioAutorizacion _autorizacion;
    public PersonaBajaUseCase(IRepositorioReserva ireserva,
                            IRepositorioPersona ipersona, IServicioAutorizacion autorizacion)
    {
        _ipersona = ipersona;
        _ireserva = ireserva;
        _autorizacion = autorizacion;
    }

    public void Baja(int id, int IdUsuario)
    {
        Permiso permiso = new Permiso();
        if (!_autorizacion.PoseeElPermiso(IdUsuario, permiso))
            throw new FalloAutorizacionException(IdUsuario, "Baja");

        if (!Validador_Persona.exist_ID(id, _ipersona))
            throw new EntidadNotFoundException("El id al que se esta intentando dar de baja no existe");

        if (Validador_Persona.hasReservas(id, _ireserva))
            throw new OperacionInvalidaException("Se ha intentado eliminar una persona que posee reservas");

        _ipersona.EliminarPersona(id);
    }
}
