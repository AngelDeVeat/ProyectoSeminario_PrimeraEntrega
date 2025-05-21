//using CentroEventos.Aplicacion;

using System.Data;
using CentroEventos.Aplicacion;

public class RepositorioReservaTXT : IRepositorioReserva{
    readonly string _nombreArchID = "IDReservas.txt";
    readonly string _nombreArch = "Reservas.txt";
    private int _ID;

    public RepositorioReservaTXT()//creo los archivos si o existen
    {
        if (!File.Exists(_nombreArch))
            File.Create(_nombreArch).Close();
        if (!File.Exists(_nombreArchID))
            File.Create(_nombreArchID).Close();
        
    }
    public void AgregarReserva(Reserva reserva)//uso un archivo para llevar la cuenta de los id y otro para los eventos
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
        reserva.ID = _ID;
        sr.Close();
        using var sw2 = new StreamWriter(_nombreArchID, false);
        sw2.WriteLine(_ID);
        sw.WriteLine(reserva.ID);
        sw.WriteLine(reserva.PersonaID);
        sw.WriteLine(reserva.EventoDeportivoID);
        sw.WriteLine(reserva.FechaAltaReserva);
        sw.WriteLine(reserva.EstadoAsistencia);
    }

    public List<Reserva> ListarReservas()//leo desde el archivo y lo agrego a la lista
    {
        var resultado = new List<Reserva>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var reserva = new Reserva();
            reserva.ID = int.Parse(sr.ReadLine() ?? "");
            reserva.PersonaID = int.Parse(sr.ReadLine() ?? "");
            reserva.EventoDeportivoID = int.Parse(sr.ReadLine() ?? "");
            reserva.FechaAltaReserva=DateTime.Parse(sr.ReadLine()?? "");
            reserva.EstadoAsistencia=Enum.Parse<Estado>(sr.ReadLine()?? "");
            resultado.Add(reserva);
        }
        return resultado;
    }

    public Reserva? GetReserva(int ID)//si el evento existe lo devuelvo si no devuelve null
    {
        var reserva = new Reserva();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream && reserva.ID != ID)
        {
            reserva.ID = int.Parse(sr.ReadLine() ?? "");
            reserva.PersonaID = int.Parse(sr.ReadLine() ?? "");
            reserva.EventoDeportivoID = int.Parse(sr.ReadLine() ?? "");
            reserva.FechaAltaReserva=DateTime.Parse(sr.ReadLine()?? "");
            reserva.EstadoAsistencia=Enum.Parse<Estado>(sr.ReadLine()?? "");
        }
        return reserva.ID == ID ? reserva : null;
    }

    public void ModificarReserva(Reserva reserva)// tomo la primera linea del archivo que contine el id simpre porqeu es lo primero que se escribe
    {                                         //al tener 7 campos la posicion delid +7 se encuentra el proximo id
        {
            var lineas = File.ReadAllLines(_nombreArch);
            using var sw = new StreamWriter(_nombreArch, false);

            for (int i = 0; i < lineas.Length; i += 5)
            {// si el id es el mismo se sobrescribe y si no se escribe lo que estaba originalmente 
                int ID = int.Parse(lineas[i]);
                if (ID == reserva.ID)
                {
                    sw.WriteLine(reserva.ID);
                    sw.WriteLine(reserva.PersonaID);
                    sw.WriteLine(reserva.EventoDeportivoID);
                    sw.WriteLine(reserva.FechaAltaReserva);
                    sw.WriteLine(reserva.EstadoAsistencia);
                }
                else
                {
                    sw.WriteLine(lineas[i]);
                    sw.WriteLine(lineas[i + 1]);
                    sw.WriteLine(lineas[i + 2]);
                    sw.WriteLine(lineas[i + 3]);
                    sw.WriteLine(lineas[i + 4]);
                }
            }
        }
    }

    public void EliminarReserva(int ID)//si el id es el que se busca eliminar no se escribe 
    {
        var lineas = File.ReadAllLines(_nombreArch);
        using var sw = new StreamWriter(_nombreArch, false);

        for (int i = 0; i < lineas.Length; i += 5)
        {
            int id = int.Parse(lineas[i]);
            if (id != ID)
            {
                sw.WriteLine(lineas[i]);
                sw.WriteLine(lineas[i + 1]);
                sw.WriteLine(lineas[i + 2]);
                sw.WriteLine(lineas[i + 3]);
                sw.WriteLine(lineas[i + 4]);
            }
        }
    }
}