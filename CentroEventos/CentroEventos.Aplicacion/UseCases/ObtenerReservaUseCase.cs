namespace CentroEventos.Aplicacion;

public class ObtenerReservaUseCase
{
    private IRepositorioReserva _ireserva;
    public ObtenerReservaUseCase(IRepositorioReserva ireserva)
    {
        _ireserva = ireserva;
    }
    public Reserva? Ejecutar(int ID)
    {
        return _ireserva.GetReserva(ID);
    }
    
}