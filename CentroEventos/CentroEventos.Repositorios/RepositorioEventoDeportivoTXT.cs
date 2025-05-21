using CentroEventos.Aplicacion;

public class RepositorioEventoDeportivoTXT : IRepositorioEventoDeportivo
{
    readonly string _nombreArchID = "IDEventoDeportivo.txt";
    readonly string _nombreArch = "EventosDeportivas.txt";
    private int _ID;
    public RepositorioEventoDeportivoTXT()//creo los archivos si o existen
    {
         if (!File.Exists(_nombreArch))
            File.Create(_nombreArch).Close();
        if (!File.Exists(_nombreArchID))
            File.Create(_nombreArchID).Close();
    }
    public void AgregarEventoDeportivo(EventoDeportivo evento)//uso un archivo para llevar la cuenta de los id y otro para los eventos
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
        evento.ID=_ID;
        sr.Close();
        using var sw2 = new StreamWriter(_nombreArchID, false);
        sw2.WriteLine(_ID);
        sw.WriteLine(evento.ID);
        sw.WriteLine(evento.Nombre);
        sw.WriteLine(evento.Descripcion);
        sw.WriteLine(evento.FechaHoraInicio);
        sw.WriteLine(evento.DuracionHoras);
        sw.WriteLine(evento.CupoMaximo);
        sw.WriteLine(evento.ResponsableID);
    }

    public List<EventoDeportivo> ListarEventosDeportivos()//leo desde el archivo y lo agrego a la lista
    {
        var resultado = new List<EventoDeportivo>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var evento = new EventoDeportivo();
            evento.ID=int.Parse(sr.ReadLine()?? "");
            evento.Nombre=sr.ReadLine()??"";
            evento.Descripcion=sr.ReadLine()?? "";
            evento.FechaHoraInicio=DateTime.Parse(sr.ReadLine()?? "");
            evento.DuracionHoras=double.Parse(sr.ReadLine()?? "");
            evento.CupoMaximo=int.Parse(sr.ReadLine()?? "");
            evento.ResponsableID=int.Parse(sr.ReadLine()?? "");
            resultado.Add(evento);
        }
        return resultado;
    }

    public EventoDeportivo? GetEventoDeportivo(int ID)//si el evento existe lo devuelvo si no devuelve null
    {
        using var sr = new StreamReader(_nombreArch);
        var evento = new EventoDeportivo();
        while (!sr.EndOfStream && evento.ID != ID)
        {
            evento.ID = int.Parse(sr.ReadLine() ?? "");
            evento.Nombre = sr.ReadLine() ?? "";
            evento.Descripcion = sr.ReadLine() ?? "";
            evento.FechaHoraInicio = DateTime.Parse(sr.ReadLine() ?? "");
            evento.DuracionHoras = double.Parse(sr.ReadLine() ?? "");
            evento.CupoMaximo = int.Parse(sr.ReadLine() ?? "");
            evento.ResponsableID = int.Parse(sr.ReadLine() ?? "");
        }
        return evento.ID == ID ? evento : null;
    }

    public void ModificarEventoDeportivo(EventoDeportivo evento)
    {
        var lineas = File.ReadAllLines(_nombreArch);
        using var sw = new StreamWriter(_nombreArch, false);

        for (int i = 0; i < lineas.Length; i += 7)// tomo la primera linea del archivo que contine el id simpre porqeu es lo primero que se escribe
        {                                         //al tener 7 campos la posicion delid +7 se encuentra el proximo id
            int ID = int.Parse(lineas[i]);
            if (ID == evento.ID)
            { // si el id es el mismo se sobrescribe y si no se escribe lo que estaba originalmente 
                 sw.WriteLine(evento.ID);
                 sw.WriteLine(evento.Nombre);
                 sw.WriteLine(evento.Descripcion);
                 sw.WriteLine(evento.FechaHoraInicio);
                 sw.WriteLine(evento.DuracionHoras);
                 sw.WriteLine(evento.CupoMaximo);
                 sw.WriteLine(evento.ResponsableID);
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
            }
        }
    }

    public void EliminarEventoDeportivo(int ID)//si el id es el que se busca eliminar no se escribe 
    {
        var lineas = File.ReadAllLines(_nombreArch);
        using var sw = new StreamWriter(_nombreArch, false);

        for (int i = 0; i < lineas.Length; i += 7)
        {
            int id = int.Parse(lineas[i]);
            if (id != ID)
            {
                sw.WriteLine(lineas[i]);
                sw.WriteLine(lineas[i + 1]);
                sw.WriteLine(lineas[i + 2]);
                sw.WriteLine(lineas[i + 3]);
                sw.WriteLine(lineas[i + 4]);
                sw.WriteLine(lineas[i + 5]);
                sw.WriteLine(lineas[i + 6]);
            }
        }
    }
}