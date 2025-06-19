using System;

namespace CentroEventos.Aplicacion;

public class ReservaBajaUseCase
{
    private IRepositorioReserva _ireserva;
    private IServicioAutorizacion _autorizacion;
    public ReservaBajaUseCase(IRepositorioReserva ireserva, IServicioAutorizacion autorizacion)
    {
        _ireserva = ireserva;
        _autorizacion = autorizacion;
    }


    public void Ejecutar(int id, Usuario usuario)
    {
        Permiso permiso =Permiso.ReservaBaja;
        if (!_autorizacion.PoseeElPermiso(usuario.Permisos, permiso))
            throw new FalloAutorizacionException(usuario.Nombre, "Baja");

        if (!Validador_Reserva.exist_ID(id, _ireserva))
            throw new EntidadNotFoundException("El id de la reserva a la que se esta intentando dar de baja no existe no existe");

        _ireserva.EliminarReserva(id);
    }
}
