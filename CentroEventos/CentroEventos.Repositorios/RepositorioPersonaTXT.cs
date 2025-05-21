public class RepositorioPersonaTXT : IRepositorioPersona {
    readonly string _nombreArchID = "IDPersonas.txt";
    readonly string _nombreArch = "Personas.txt";
    private int _ID;
    public RepositorioPersonaTXT()//creo los archivos si o existen
    
    {
         if (!File.Exists(_nombreArch))
            File.Create(_nombreArch).Close();
        if (!File.Exists(_nombreArchID))
            File.Create(_nombreArchID).Close();
    }
    public void AgregarPersona(Persona persona)//uso un archivo para llevar la cuenta de los id y otro para los eventos
    {
        using var sw = new StreamWriter(_nombreArch, true);
        using var sr = new StreamReader(_nombreArchID);
        if (!sr.EndOfStream)
        {
            _ID = int.Parse(sr.ReadLine() ?? "");
            _ID++;
        }
        else
            _ID = 1;
        persona.ID = _ID;
        sr.Close();
        using var sw2 = new StreamWriter(_nombreArchID, false);
        sw2.WriteLine(_ID);
        sw.WriteLine(persona.ID);
        sw.WriteLine(persona.DNI);
        sw.WriteLine(persona.Nombre);
        sw.WriteLine(persona.Apellido);
        sw.WriteLine(persona.Direccion);
        sw.WriteLine(persona.Telefono);
        sw.WriteLine(persona.Facultad);
        sw.WriteLine(persona.Email);
    }
    public List<Persona> ListarPersonas()//leo desde el archivo y lo agrego a la lista  
    {
        var resultado = new List<Persona>();
        using var sr= new StreamReader(_nombreArch);
        while(!sr.EndOfStream ){
            var persona= new Persona();
            persona.ID=int.Parse(sr.ReadLine()?? "");
            persona.DNI=int.Parse(sr.ReadLine()?? "");
            persona.Nombre=sr.ReadLine()?? "";
            persona.Apellido=sr.ReadLine()?? "";
            persona.Direccion=sr.ReadLine()?? "";
            persona.Telefono=int.Parse(sr.ReadLine()?? "");
            persona.Facultad=sr.ReadLine()?? "";
            persona.Email=sr.ReadLine()?? "";
            resultado.Add(persona);
        }
        return resultado;
    }
    public Persona? GetPersona(int ID)//si el evento existe lo devuelvo si no devuelve null
    {
        var persona= new Persona();
        using var sr= new StreamReader(_nombreArch);
        while (!sr.EndOfStream && persona.ID!=ID)
        {
            persona.ID = int.Parse(sr.ReadLine() ?? "");
            persona.DNI = int.Parse(sr.ReadLine() ?? "");
            persona.Nombre = sr.ReadLine() ?? "";
            persona.Apellido = sr.ReadLine() ?? "";
            persona.Direccion = sr.ReadLine() ?? "";
            persona.Telefono = int.Parse(sr.ReadLine() ?? "");
            persona.Facultad = sr.ReadLine() ?? "";
            persona.Email = sr.ReadLine() ?? "";
        }
        return persona.ID == ID ? persona : null;
    }
    public void ModificarPersona(Persona persona)
    {           // tomo la primera linea del archivo que contine el id simpre porqeu es lo primero que se escribe
                //al tener 7 campos la posicion delid +7 se encuentra el proximo id
        var lineas = File.ReadAllLines(_nombreArch);
        using var sw = new StreamWriter(_nombreArch, false);

        for (int i = 0; i < lineas.Length; i += 8)
        {// si el id es el mismo se sobrescribe y si no se escribe lo que estaba originalmente 
            int ID = int.Parse(lineas[i]);
            if (ID == persona.ID)
            {
                sw.WriteLine(persona.ID);
                sw.WriteLine(persona.DNI);
                sw.WriteLine(persona.Nombre);
                sw.WriteLine(persona.Apellido);
                sw.WriteLine(persona.Direccion);
                sw.WriteLine(persona.Telefono);
                sw.WriteLine(persona.Facultad);
                sw.WriteLine(persona.Email);
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
        }
    }
    public void EliminarPersona(int ID){//si el id es el que se busca eliminar no se escribe 
        var lineas = File.ReadAllLines(_nombreArch);
        using var sw =new StreamWriter(_nombreArch,false);
        
        for (int i = 0; i < lineas.Length; i += 8)
        {
            int Id = int.Parse(lineas[i]);
            if (Id != ID)
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
        }

    }

}