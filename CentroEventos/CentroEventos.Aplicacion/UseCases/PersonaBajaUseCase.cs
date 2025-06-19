using System;

namespace CentroEventos.Aplicacion;

public class PersonaBajaUseCase
{
    private IRepositorioReserva _ireserva;
    private IRepositorioPersona _ipersona;
    private IServicioAutorizacion _autorizacion;
    private IRepositorioEventoDeportivo _ievento;
    public PersonaBajaUseCase(IRepositorioReserva ireserva,
                            IRepositorioPersona ipersona, IServicioAutorizacion autorizacion, IRepositorioEventoDeportivo ievento)
    {
        _ipersona = ipersona;
        _ireserva = ireserva;
        _autorizacion = autorizacion;
        _ievento = ievento;
    }

    public void Baja(int id, Usuario usuario)
    {
        if (!_autorizacion.PoseeElPermiso(usuario.Permisos, Permiso.PersonaBaja))
            throw new FalloAutorizacionException(usuario.Nombre, "Baja");

        if (!Validador_Persona.exist_ID(id, _ipersona))
            throw new EntidadNotFoundException("El id al que se esta intentando dar de baja no existe");

        if (Validador_Persona.hasReservas(id, _ireserva))
            throw new OperacionInvalidaException("Se ha intentado eliminar una persona que posee reservas");
            
        if (Validador_Persona.hasEvento(id, _ievento))
            throw new OperacionInvalidaException("Se ha intentado eliminar una persona responsable de un evento");

        _ipersona.EliminarPersona(id);
    }
}
