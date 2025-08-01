using System;

namespace CentroEventos.Aplicacion;

public class ReservaAltaUseCase
{
    private IRepositorioEventoDeportivo _ievento;
    private IRepositorioReserva _ireserva;
    private IRepositorioPersona _ipersona;
    private IServicioAutorizacion _autorizacion;
    public ReservaAltaUseCase(IRepositorioEventoDeportivo ievento, IRepositorioReserva ireserva,
                            IRepositorioPersona ipersona, IServicioAutorizacion autorizacion)
    {
        _ievento = ievento;
        _ipersona = ipersona;
        _ireserva = ireserva;
        _autorizacion = autorizacion;
    }

    public void Ejecutar(Reserva reserva, Usuario usuario)
    {
        Permiso permiso = Permiso.ReservaAlta;
        if (!_autorizacion.PoseeElPermiso(usuario.Permisos, permiso))
            throw new FalloAutorizacionException(usuario.Nombre, "Alta");

        if (!Validador_Reserva.exist_PersonaId(reserva.PersonaID, _ipersona))
            throw new EntidadNotFoundException("El id de la persona que reserva no existe");

        if (!Validador_Reserva.exist_EventoDeportivoId(reserva.EventoDeportivoID, _ievento))
            throw new EntidadNotFoundException("El id del evento deportivo a reservar no existe");

        if (!Validador_Reserva.CuposDisponibles(reserva.EventoDeportivoID, _ireserva, _ievento))
            throw new CupoExcedidoException("No quedan cupos en el evento deportivo que se intenta reservar");

        if (!Validador_Reserva.isUnique_EventoDeportivoId(reserva.PersonaID, reserva.EventoDeportivoID, _ireserva))
            throw new DuplicadoException("La persona que intenta reservar este evento deportivo ya tiene reservado dicho evento");

        reserva.FechaAltaReserva = DateTime.Now;
        reserva.EstadoAsistencia = Estado.Pendiente;

        _ireserva.AgregarReserva(reserva);
    }
}
