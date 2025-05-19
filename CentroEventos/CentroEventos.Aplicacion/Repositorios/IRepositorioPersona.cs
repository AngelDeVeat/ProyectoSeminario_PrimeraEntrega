public interface IRepositorioPersona{
    void AgregarPersona(Persona persona);
    List<Persona> ListarPersona();
    Persona? GetPersona(int ID);
    void ModificarPersona(Persona persona);
    void EliminarPersona(int ID);
}