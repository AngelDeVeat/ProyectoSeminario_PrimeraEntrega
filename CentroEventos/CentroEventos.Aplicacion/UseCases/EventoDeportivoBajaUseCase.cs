using System;

namespace CentroEventos.Aplicacion.UseCases;

public class EventoDeportivoBajaUseCase
{
    private IRepositorioEventoDeportivo _ievento;
    private IRepositorioReserva _ireserva;
    private IServicioAutorizacion _autorizacion;
    public EventoDeportivoBajaUseCase(IRepositorioEventoDeportivo ievento, IRepositorioReserva ireserva, IServicioAutorizacion autorizacion)
    {
        _ievento = ievento;
        _ireserva = ireserva;
        _autorizacion = autorizacion;
    }

    public void Baja(int id, Usuario usuario)
    {
        Permiso permiso = new Permiso();
        if (!_autorizacion.PoseeElPermiso(usuario.Permisos, permiso))
            throw new FalloAutorizacionException(usuario.Nombre, "Baja");

        if (!Validador_EventoDeportivo.exist_ID(id, _ievento))
            throw new EntidadNotFoundException("El id del evento deportivo al que se esta intentando dar de baja no existe");

        if (Validador_EventoDeportivo.hasReservas(id, _ireserva))
            throw new OperacionInvalidaException("Se ha intentado eliminar un evento deportivo que posee reservas");

        _ievento.EliminarEventoDeportivo(id);
    }
}
