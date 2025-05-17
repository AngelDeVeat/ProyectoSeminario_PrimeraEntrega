public interface IRepositorioEventoDeportiva{
    void AgregarEventoDeportivo( EventoDeportiva  eventoDeportiva);
    List<EventoDeportiva> ListarEventosDeportivos();
    EventoDeportiva? GetEventoDeportivo(int ID);
    void ModificarEventoDeportivo(EventoDeportiva eventoDeportiva);
    void EliminarEventoDeportivo(int ID);

}