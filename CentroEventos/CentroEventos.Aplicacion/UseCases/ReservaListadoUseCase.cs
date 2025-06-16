using System;

namespace CentroEventos.Aplicacion;

public class ReservaListadoUseCase
{
    private IRepositorioReserva _ireserva;
    public ReservaListadoUseCase(IRepositorioReserva ireserva)
    {
        _ireserva = ireserva;
    }

    public List<Reserva> Ejecutar()
    {
        return _ireserva.ListarReservas();
    }
}
