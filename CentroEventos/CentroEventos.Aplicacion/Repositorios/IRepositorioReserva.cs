public interface IRepositorioReserva{
    void AgregarReserva(Reserva reserva);
    List<Reserva> ListarReservas();
    Reserva? GetReserva(int ID);
    void ModificarReserva(Reserva reserva);
    void EliminarReserva(int ID);
}