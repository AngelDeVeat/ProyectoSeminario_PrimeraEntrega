namespace CentroEventos.Aplicacion;

public interface IRepositorioEventoDeportivo
{
    void AgregarEventoDeportivo(EventoDeportivo eventoDeportivo);
    List<EventoDeportivo> ListarEventosDeportivos();
    EventoDeportivo? GetEventoDeportivo(int ID);
    void ModificarEventoDeportivo(EventoDeportivo eventoDeportivo);
    void EliminarEventoDeportivo(int ID);

}