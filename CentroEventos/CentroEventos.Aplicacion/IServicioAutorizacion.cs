public enum Permisos{
    EventoAlta,
    EventoModificacion,
    EventoBaja,
    ReservaAlta,
    ReservaBaja,
    ReservaModificacion,
    UsuarioAlta,
    UsuarioBaja,
    UsuarioModificacion
}
public interface IServicioAutorizacion{
    public bool PoseeElPermiso(int IDUsuario, Permisos permiso);

}