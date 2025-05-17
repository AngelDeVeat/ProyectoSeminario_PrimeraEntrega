public class RepositorioReservaTXT : IRepositorioReserva{
    readonly string _nombreArch = "Reservas.txt";
    static int _ID = 0;

    public void AgregarReserva(Reserva reserva)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        _ID++;
        reserva.ID = _ID;
        sw.WriteLine(reserva.ID);
        sw.WriteLine(reserva.Persona);
        sw.WriteLine(reserva.ActividadDeportiva);
    }

    public List<Reserva> ListarReservas()
    {
        var resultado = new List<Reserva>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var reserva = new Reserva();
            reserva.ID = int.Parse(sr.ReadLine() ?? "");
            reserva.Persona = int.Parse(sr.ReadLine() ?? "");
            reserva.ActividadDeportiva = int.Parse(sr.ReadLine() ?? "");
            resultado.Add(reserva);
        }
        return resultado;
    }

    public Reserva? GetReserva(int ID)
    {
        var reserva = new Reserva();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream && reserva.ID != ID)
        {
            reserva.ID = int.Parse(sr.ReadLine() ?? "");
            reserva.Persona = int.Parse(sr.ReadLine() ?? "");
            reserva.ActividadDeportiva = int.Parse(sr.ReadLine() ?? "");
        }
        return reserva.ID == ID ? reserva : null;
    }

    public void ModificarReserva(Reserva reserva)
    {
        var lineas = File.ReadAllLines(_nombreArch);
        using var sw = new StreamWriter(_nombreArch, false);

        for (int i = 0; i < lineas.Length; i += 3)
        {
            int id = int.Parse(lineas[i]);
            if (id == reserva.ID)
            {
                sw.WriteLine(reserva.ID);
                sw.WriteLine(reserva.Persona);
                sw.WriteLine(reserva.ActividadDeportiva);
            }
            else
            {
                sw.WriteLine(lineas[i]);
                sw.WriteLine(lineas[i + 1]);
                sw.WriteLine(lineas[i + 2]);
            }
        }
    }

    public void EliminarReserva(int ID)
    {
        var lineas = File.ReadAllLines(_nombreArch);
        using var sw = new StreamWriter(_nombreArch, false);

        for (int i = 0; i < lineas.Length; i += 3)
        {
            int id = int.Parse(lineas[i]);
            if (id != ID)
            {
                sw.WriteLine(lineas[i]);
                sw.WriteLine(lineas[i + 1]);
                sw.WriteLine(lineas[i + 2]);
            }
        }
    }
}