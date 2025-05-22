using System;

namespace CentroEventos.Aplicacion.UseCases;

public class ReservaModificacionUseCase
{
    private IRepositorioEventoDeportivo _ievento;
    private IRepositorioReserva _ireserva;
    private IRepositorioPersona _ipersona;
    private IServicioAutorizacion _autorizacion;
    public ReservaModificacionUseCase(IRepositorioEventoDeportivo ievento, IRepositorioReserva ireserva,
                            IRepositorioPersona ipersona, IServicioAutorizacion autorizacion)
    {
        _ievento = ievento;
        _ipersona = ipersona;
        _ireserva = ireserva;
        _autorizacion = autorizacion;
    }

    public void Ejecutar(Reserva reserva, int IdUsuario)
    {
        Permiso permiso = new Permiso();
        if (!_autorizacion.PoseeElPermiso(IdUsuario, permiso))
            throw new FalloAutorizacionException(IdUsuario, "Modificacion");

        if (!Validador_Reserva.exist_ID(reserva.ID, _ireserva))
            throw new EntidadNotFoundException("El id de la reserva a la que se esta intentando modificar no existe");

        if (!Validador_Reserva.exist_PersonaId(reserva.PersonaID, _ipersona))
            throw new EntidadNotFoundException("El id de la persona que reserva no existe");

        if (!Validador_Reserva.exist_EventoDeportivoId(reserva.EventoDeportivoID, _ievento))
            throw new EntidadNotFoundException("El id del evento deportivo a reservar no existe");

        if (!Validador_Reserva.CuposDisponibles(reserva.EventoDeportivoID, _ireserva, _ievento))
            throw new CupoExcedidoException("No quedan cupos en el evento deportivo al que se intenta cambiar la reserva");

        Reserva? re = _ireserva.GetReserva(reserva.ID);
        if (re != null && !(reserva.PersonaID == re.PersonaID && reserva.EventoDeportivoID == re.EventoDeportivoID))
        {
            if (!Validador_Reserva.isUnique_EventoDeportivoId(reserva.PersonaID, reserva.EventoDeportivoID, _ireserva))
                throw new DuplicadoException("La persona que intenta reservar este evento deportivo ya tiene reservado dicho evento");
        }
          
        reserva.FechaAltaReserva = DateTime.Now;
        _ireserva.ModificarReserva(reserva);
    }
}
