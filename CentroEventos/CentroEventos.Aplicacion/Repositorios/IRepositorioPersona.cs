public interface IRepositorioPersona{
    void AgregarPersona(Persona persona);
    List<Persona> ListarPersonas();
    Persona? GetPersona(int ID);
    void ModificarPersona(Persona persona);
    void EliminarPersona(int ID);
}