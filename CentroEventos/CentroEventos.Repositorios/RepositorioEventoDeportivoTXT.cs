using CentroEventos.Aplicacion;

public class RepositorioActividadDeportivaTXT : IRepositorioEventoDeportivo
{
    readonly string _nombreArch = "ActividadesDeportivas.txt";
    static int _ID = 0;

    public void AgregarEventoDeportivo(EventoDeportivo evento)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        _ID++;
        evento.ID = _ID;
        sw.WriteLine(evento.ID);
        sw.WriteLine(evento.Nombre);
        sw.WriteLine(evento.Descripcion);
        sw.WriteLine(evento.FechaHoraInicio);
        sw.WriteLine(evento.DuracionHoras);
        sw.WriteLine(evento.DiasDisponibles);
        sw.WriteLine(evento.CupoMaximo);
        sw.WriteLine(evento.CuposOcupados);
        sw.WriteLine(evento.ResponsableID);
    }

    public List<EventoDeportivo> ListarEventosDeportivos()
    {
        var resultado = new List<EventoDeportivo>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var evento = new EventoDeportivo();
            evento.ID = int.Parse(sr.ReadLine() ?? "");
            evento.Nombre = sr.ReadLine() ?? "";
            evento.Descripcion = sr.ReadLine() ?? "";
            evento.FechaHoraInicio = DateTime.Parse(sr.ReadLine() ?? "");
            evento.DuracionHoras = double.Parse(sr.ReadLine() ?? "");
            evento.DiasDisponibles = int.Parse(sr.ReadLine() ?? "");
            evento.CupoMaximo = int.Parse(sr.ReadLine() ?? "");
            evento.CuposOcupados = int.Parse(sr.ReadLine() ?? "");
            evento.ResponsableID = int.Parse(sr.ReadLine() ?? "");
            resultado.Add(evento);
        }
        return resultado;
    }

    public EventoDeportivo? GetEventoDeportivo(int ID)
    {
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var evento = new EventoDeportivo();
            evento.ID = int.Parse(sr.ReadLine() ?? "");
            evento.Nombre = sr.ReadLine() ?? "";
            evento.Descripcion = sr.ReadLine() ?? "";
            evento.FechaHoraInicio = DateTime.Parse(sr.ReadLine() ?? "");
            evento.DuracionHoras = double.Parse(sr.ReadLine() ?? "");
            evento.DiasDisponibles = int.Parse(sr.ReadLine() ?? "");
            evento.CupoMaximo = int.Parse(sr.ReadLine() ?? "");
            evento.CuposOcupados = int.Parse(sr.ReadLine() ?? "");
            evento.ResponsableID = int.Parse(sr.ReadLine() ?? "");

            if (evento.ID == ID)
            {
                return evento;
            }
        }
        return null;
    }

    public void ModificarEventoDeportivo(EventoDeportivo evento)
    {
        var lineas = File.ReadAllLines(_nombreArch);
        using var sw = new StreamWriter(_nombreArch, false);

        for (int i = 0; i < lineas.Length; i += 9)
        {
            int id = int.Parse(lineas[i]);
            if (id == evento.ID)
            {
                sw.WriteLine(evento.ID);
                sw.WriteLine(evento.Nombre);
                sw.WriteLine(evento.Descripcion);
                sw.WriteLine(evento.FechaHoraInicio);
                sw.WriteLine(evento.DuracionHoras);
                sw.WriteLine(evento.DiasDisponibles);
                sw.WriteLine(evento.CupoMaximo);
                sw.WriteLine(evento.CuposOcupados);
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
                sw.WriteLine(lineas[i + 7]);
                sw.WriteLine(lineas[i + 8]);
            }
        }
    }

    public void EliminarEventoDeportivo(int ID)
    {
        var lineas = File.ReadAllLines(_nombreArch);
        using var sw = new StreamWriter(_nombreArch, false);

        for (int i = 0; i < lineas.Length; i += 9)
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
                sw.WriteLine(lineas[i + 7]);
                sw.WriteLine(lineas[i + 8]);
            }
        }
    }
}