public class RepositorioPersonaTXT : IRepositorioPersona {
    readonly string _nombreArch="Personas.txt";
    static int _ID=0;
    public void AgregarPersona(Persona persona){
        using var sw = new StreamWriter(_nombreArch,true);
        _ID++;
        persona.ID=_ID;
        sw.WriteLine(persona.ID);
        sw.WriteLine(persona.NumeroDeCarnet);
        sw.WriteLine(persona.Nombre);
        sw.WriteLine(persona.Apellido);
        sw.WriteLine(persona.Direccion);
        sw.WriteLine(persona.Telefono);
        sw.WriteLine(persona.Facultad);
        sw.WriteLine(persona.CorreoElectronico);
    }
    public List<Persona> ListarPersona(){
        var resultado = new List<Persona>();
        using var sr= new StreamReader(_nombreArch);
        while(!sr.EndOfStream ){
            var persona= new Persona();
            persona.ID=int.Parse(sr.ReadLine()?? "");
            persona.NumeroDeCarnet=int.Parse(sr.ReadLine()?? "");
            persona.Nombre=sr.ReadLine()?? "";
            persona.Apellido=sr.ReadLine()?? "";
            persona.Direccion=sr.ReadLine()?? "";
            persona.Telefono=int.Parse(sr.ReadLine()?? "");
            persona.Facultad=sr.ReadLine()?? "";
            persona.CorreoElectronico=sr.ReadLine()?? "";
            resultado.Add(persona);
        }
        return resultado;
    }
    public Persona? GetPersona(int ID){
        var persona= new Persona();
        using var sr= new StreamReader(_nombreArch);
        while(!sr.EndOfStream && persona.ID!=ID ){
            persona.ID=int.Parse(sr.ReadLine()?? "");
            persona.NumeroDeCarnet=int.Parse(sr.ReadLine()?? "");
            persona.Nombre=sr.ReadLine()?? "";
            persona.Apellido=sr.ReadLine()?? "";
            persona.Direccion=sr.ReadLine()?? "";
            persona.Telefono=int.Parse(sr.ReadLine()?? "");
            persona.Facultad=sr.ReadLine()?? "";
            persona.CorreoElectronico=sr.ReadLine()?? "";
        }
        return persona;
    }
    public void ModificarPersona(Persona persona){
        var lineas = File.ReadAllLines(_nombreArch); 
    using var sw = new StreamWriter(_nombreArch, false); 

    for (int i = 0; i < lineas.Length; i += 8) 
    {
        int id = int.Parse(lineas[i]); 
        if (id == persona.ID)
        {
            sw.WriteLine(persona.ID);
            sw.WriteLine(persona.NumeroDeCarnet);
            sw.WriteLine(persona.Nombre);
            sw.WriteLine(persona.Apellido);
            sw.WriteLine(persona.Direccion);
            sw.WriteLine(persona.Telefono);
            sw.WriteLine(persona.Facultad);
            sw.WriteLine(persona.CorreoElectronico);
        }
        else
        {
            sw.WriteLine(lineas[i]);   
            sw.WriteLine(lineas[i + 1]); 
            sw.WriteLine(lineas[i + 2]); 
            sw.WriteLine(lineas[i + 3]); 
            sw.WriteLine(lineas[i + 4]); 
            sw.WriteLine(lineas[i + 5]); 
            sw.WriteLine(lineas[i + 6]); 
            sw.WriteLine(lineas[i + 7]); 
    }
}}
    public void EliminarPersona(int ID){
        var lineas = File.ReadAllLines(_nombreArch);
        using var sw =new StreamWriter(_nombreArch,false);
        for (int i=0; i < lineas.Length; i+=8 ){
            int Id=int.Parse(lineas[i]);
            if (Id!=ID){
                 sw.WriteLine(lineas[i]);     
            sw.WriteLine(lineas[i + 1]); 
            sw.WriteLine(lineas[i + 2]); 
            sw.WriteLine(lineas[i + 3]); 
            sw.WriteLine(lineas[i + 4]); 
            sw.WriteLine(lineas[i + 5]); 
            sw.WriteLine(lineas[i + 6]); 
            sw.WriteLine(lineas[i + 7]);
            }
        }

    }

}