using System;

namespace CentroEventos.Aplicacion.UseCases;

public class ReservaBajaUseCase
{
    private IRepositorioReserva _ireserva;
    private IServicioAutorizacion _autorizacion;
    public ReservaBajaUseCase(IRepositorioReserva ireserva, IServicioAutorizacion autorizacion)
    {
        _ireserva = ireserva;
        _autorizacion = autorizacion;
    }

    // DECILE A EMI QUE EN LOS REPOSITORIOS NO DEBERIA REVIZAR SI EXISTE EL ID ENVIADO A LA HORA DE BORRAR
    public void Ejecutar(int id, int IdUsuario)
    {
        Permiso permiso = new Permiso();
        if (!_autorizacion.PoseeElPermiso(IdUsuario, permiso))
            throw new FalloAutorizacionException(IdUsuario, "Baja");

        if (!Validador_Reserva.exist_ID(id, _ireserva))
            throw new EntidadNotFoundException("El id al que se esta intentando modificar no existe");

        _ireserva.EliminarReserva(id);
    }
}
