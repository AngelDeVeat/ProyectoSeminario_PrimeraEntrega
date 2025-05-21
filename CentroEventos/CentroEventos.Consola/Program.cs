// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata;
using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.UseCases;
int Usuario=3;
IRepositorioPersona repositorioPersona = new RepositorioPersonaTXT();
IRepositorioEventoDeportivo repositorioEventoDeportivo = new RepositorioEventoDeportivoTXT();
IRepositorioReserva repositorioReserva = new RepositorioReservaTXT();
IServicioAutorizacion autorizacion = new ServicioAutorizacionProvisorio();
PersonaAltaUseCase AltaPersona = new PersonaAltaUseCase(repositorioPersona, autorizacion);
PersonaBajaUseCase BajaPersona = new PersonaBajaUseCase(repositorioReserva, repositorioPersona, autorizacion);
PersonaListadoUseCase ListadoPersona = new PersonaListadoUseCase(repositorioPersona);
PersonaModificacionUseCase modificarPersona = new PersonaModificacionUseCase(repositorioPersona, autorizacion);
ReservaAltaUseCase AltaReserva = new ReservaAltaUseCase(repositorioEventoDeportivo, repositorioReserva, repositorioPersona, autorizacion);
ReservaBajaUseCase BajaReserva = new ReservaBajaUseCase(repositorioReserva, autorizacion);
ReservaListadoUseCase ListarReserva = new ReservaListadoUseCase(repositorioReserva);
ReservaModificacionUseCase ModificarReserva = new ReservaModificacionUseCase(repositorioEventoDeportivo, repositorioReserva, repositorioPersona, autorizacion);
EventoDeportivoAltaUseCase AltaEvento = new EventoDeportivoAltaUseCase(repositorioEventoDeportivo, repositorioPersona, autorizacion);
EventoDeportivoBajaUseCase BajaEvento = new EventoDeportivoBajaUseCase(repositorioEventoDeportivo, repositorioReserva, autorizacion);
EventoDeportivoListadoUseCase ListarEvento = new EventoDeportivoListadoUseCase(repositorioEventoDeportivo);
EventoDeportivoModificacionUseCase ModificarEvento = new EventoDeportivoModificacionUseCase(repositorioEventoDeportivo, repositorioPersona, autorizacion);
ListarAsistenciaAEventoUseCase ListarAsistenciaEvento = new ListarAsistenciaAEventoUseCase(repositorioReserva, repositorioPersona, repositorioEventoDeportivo);
ListarEventosConCupoDisponibleUseCase ListarEventosConCuposDis = new ListarEventosConCupoDisponibleUseCase(repositorioEventoDeportivo, repositorioReserva);
Boolean ok = false;
while (ok == false)
{
    Console.WriteLine("ingrese id de usuario 1 o 0 : (ingrese 1 para poder probar los casos si elige 0 entonces solo podra acceder a los listados)");
    string? lec = Console.ReadLine();
    if (int.TryParse(lec, out Usuario))
    {
        if (Usuario == 0 || Usuario == 1)
            ok = true;
        else
            Console.WriteLine("ingrese id valido(1 o 0)");

    }
    else
    {
        Console.WriteLine("ingrse un numero 1 o 0");
    }
}
ok = false;
while (ok == false)
{
    int Opcion;
    Console.WriteLine("ingrese que operacion desea Hacer ");
    Console.WriteLine("1. Para dar de alta una persona");
    Console.WriteLine("2. Para dar de baja una persona");
    Console.WriteLine("3. Para listar todas las personas");
    Console.WriteLine("4. Para modificar a una persona");
    Console.WriteLine("5. Para dar de alta una Reserva");
    Console.WriteLine("6. Para dar de baja una Reserva");
    Console.WriteLine("7. Para Listar todas las Reservas");
    Console.WriteLine("8. Para modificar una reserva");
    Console.WriteLine("9. para dar de alta un Evento");
    Console.WriteLine("10. Para dar de baja un Evento");
    Console.WriteLine("11. Para listar todos los Eventos");
    Console.WriteLine("12. Para modificar un Evento");
    Console.WriteLine("13. Para listar todos los eventos con cupos disponibles");
    Console.WriteLine("14. Para listar todos los asistentes a un evento pasado");
    Console.WriteLine("pulse cualquier otro valor para cerrar menu");
    string? lec = Console.ReadLine();
    if (int.TryParse(lec, out Opcion))
    {
        if (Opcion < 1 || Opcion > 14)
        {
            ok = true;
        }
        else
        {
            switch (Opcion)
            {
                case 1:
                    // Alta de persona
                    Persona nuevaPersona = InicializarPersona();
                    AltaPersona.Alta(nuevaPersona, Usuario);
                    break;
                case 2:
                    // Baja de persona
                    Console.WriteLine("ingrese id de la persona a dar de baja ");
                    int idbaja;
                    while (!int.TryParse(Console.ReadLine(), out idbaja))
                    {
                        Console.WriteLine("ingrese un id válido ");
                    }
                    BajaPersona.Baja(idbaja, Usuario);
                    break;
                case 3:
                    // Listar personas
                    var personas = ListadoPersona.Listado();
                    foreach (var p in personas)
                    {
                        Console.WriteLine(p.ToString());
                    }
                    break;
                case 4:
                    // Modificar persona
                    Persona personaMod = InicializarPersonaM();//uso otro metodo que usa otro constructor de Persona para poder hacer la busqueda por id  
                    modificarPersona.Modificacion(personaMod, Usuario);
                    break;
                case 5:
                    // Alta de reserva
                    Reserva nuevaReserva = InicializarReserva();
                    AltaReserva.Ejecutar(nuevaReserva, Usuario);
                    break;
                case 6:
                    // Baja de reserva
                    Console.WriteLine("ingrese id de la reserva a dar de baja");
                    int idReservaBaja;
                    while (!int.TryParse(Console.ReadLine(), out idReservaBaja))
                    {
                        Console.WriteLine("ingrese un id válido ");
                    }
                    BajaReserva.Ejecutar(idReservaBaja, Usuario);
                    break;
                case 7:
                    // Listar reservas
                    var reservas = ListarReserva.Ejecutar();
                    foreach (var r in reservas)
                    {
                        Console.WriteLine(r.ToString());
                    }
                    break;
                case 8:
                    // Modificar reserva
                    Reserva reservaMod = InicializarReservaM();//uso otro metodo que usa otro constructor de Reserva para poder hacer la busqueda por id
                    ModificarReserva.Ejecutar(reservaMod, Usuario);
                    break;
                case 9:
                    // Alta de evento deportivo
                    EventoDeportivo nuevoEvento = InicializarEventoeportivo();
                    AltaEvento.Alta(nuevoEvento, Usuario);
                    break;
                case 10:
                    // Baja de evento deportivo
                    Console.WriteLine("ingrese id del evento a dar de baja ");
                    int idEventoBaja;
                    while (!int.TryParse(Console.ReadLine(), out idEventoBaja))
                    {
                        Console.WriteLine("ingrese un id valido");
                    }
                    BajaEvento.Baja(idEventoBaja, Usuario);
                    break;
                case 11:
                    // Listar eventos deportivos
                    var eventos = ListarEvento.Listado();
                    foreach (var e in eventos)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    break;
                case 12:
                    // Modificar evento deportivo
                    EventoDeportivo eventoMod = InicializarEventoeportivoM();//uso otro metodo que usa otro constructor de EventoDeportivo para poder hacer la busqueda por id
                    ModificarEvento.Modificacion(eventoMod, Usuario);
                    break;
                case 13:
                    // Listar eventos con cupos disponibles
                    var eventosCupo = ListarEventosConCuposDis.Ejecutar();
                    foreach (var ec in eventosCupo)
                    {
                        Console.WriteLine(ec.ToString());
                    }
                    break;
                case 14:
                    // Listar asistentes a evento pasado
                    Console.WriteLine("ingrese id del evento ");
                    int idEventoAsist;
                    while (!int.TryParse(Console.ReadLine(), out idEventoAsist))
                    {
                        Console.WriteLine("ingrese un id válido");
                    }
                    List<Persona> asistentes = ListarAsistenciaEvento.Ejecutar(idEventoAsist);
                    foreach (var a in asistentes)
                    {
                        Console.WriteLine(a.ToString());
                    }
                    break;

            }
        }
    }
    else
    {
        ok = true;
    }
}


    static Persona InicializarPersona()
    {
        Console.WriteLine("ingrese DNI de la persona ");
        int dni;
        while (!int.TryParse(Console.ReadLine(), out dni))
        {
            Console.WriteLine("ingrese un dni válido ");
        }

        Console.WriteLine("ingrese nombre ");
        string? nombre = Console.ReadLine();

        Console.WriteLine("ingrese apellido");
        string? apellido = Console.ReadLine();

        Console.WriteLine("ingrese dirección");
        string? direccion = Console.ReadLine();

        Console.WriteLine("ingrese teléfono");
        int telefono;
        while (!int.TryParse(Console.ReadLine(), out telefono))
        {
            Console.WriteLine("ingrese un telefono válido ");
        }

        Console.WriteLine("ingrese facultad ");
        string? facultad = Console.ReadLine();

        Console.WriteLine("ingrese correo electrónico ");
        string? email = Console.ReadLine();

        return new Persona(dni, nombre ?? "", apellido ?? "", direccion ?? "", telefono, facultad ?? "", email ?? "");
    }
    static Reserva InicializarReserva()
    {
        Console.WriteLine("ingrese id del evento deportivo ");
        int eventoid;
        while (!int.TryParse(Console.ReadLine(), out eventoid))
        {
            Console.WriteLine(" ingrese un id válido ");
        }

        Console.WriteLine("ingrese id de la persona ");
        int personaid;
        while (!int.TryParse(Console.ReadLine(), out personaid))
        {
            Console.WriteLine("ingrese un id válido ");
        }
        return new Reserva( personaid,eventoid);
    }
    static EventoDeportivo InicializarEventoeportivo()
    {

        Console.WriteLine("ingrese nombre del evento ");
        string? nombre = Console.ReadLine();

        Console.WriteLine("ingrese descripción del evento ");
        string? descripcion = Console.ReadLine();

        Console.WriteLine("ingrese fecha y hora de inicio (yyyy-MM-dd HH:mm):");
        DateTime fechaHoraInicio;
        while (!DateTime.TryParse(Console.ReadLine(), out fechaHoraInicio))
        {
            Console.WriteLine("ingrese una fecha y hora válida (yyyy-MM-dd HH:mm):");
        }

        Console.WriteLine("ingrese duración en horas ");
        double duracionHoras;
        while (!double.TryParse(Console.ReadLine(), out duracionHoras))
        {
            Console.WriteLine("ingrese una duración válida ");
        }

        Console.WriteLine("ingrese cupo máximo");
        int cupoMaximo;
        while (!int.TryParse(Console.ReadLine(), out cupoMaximo))
        {
            Console.WriteLine("ingrese un cupo máximo válido");
        }

        Console.WriteLine("ingrese id del responsable");
        int responsableId;
        while (!int.TryParse(Console.ReadLine(), out responsableId))
        {
            Console.WriteLine("ingrese un ID de responsable válido ");
        }
        return new EventoDeportivo(nombre, cupoMaximo, fechaHoraInicio, duracionHoras, descripcion, responsableId);
    }
    static Persona InicializarPersonaM()
    {
        Console.WriteLine("ingrese id de la persona ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("ingrese un id válido ");
        }
        
        Console.WriteLine("ingrese DNI de la persona ");
        int dni;
        while (!int.TryParse(Console.ReadLine(), out dni))
        {
            Console.WriteLine("ingrese un dni válido ");
        }

        Console.WriteLine("ingrese nombre ");
        string? nombre = Console.ReadLine();

        Console.WriteLine("ingrese apellido");
        string? apellido = Console.ReadLine();

        Console.WriteLine("ingrese dirección");
        string? direccion = Console.ReadLine();

        Console.WriteLine("ingrese teléfono");
        int telefono;
        while (!int.TryParse(Console.ReadLine(), out telefono))
        {
            Console.WriteLine("ingrese un telefono válido ");
        }

        Console.WriteLine("ingrese facultad ");
        string? facultad = Console.ReadLine();

        Console.WriteLine("ingrese correo electrónico ");
        string? email = Console.ReadLine();

        return new Persona(id,dni, nombre ?? "", apellido ?? "", direccion ?? "", telefono, facultad ?? "", email ?? "");
    }
    static Reserva InicializarReservaM()
    {
        Console.WriteLine("ingrese id de la reserva");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine(" ingrese un id válido ");
        }
        Console.WriteLine("ingrese id del evento deportivo ");
        int eventoid;
        while (!int.TryParse(Console.ReadLine(), out eventoid))
        {
            Console.WriteLine(" ingrese un id válido ");
        }

        Console.WriteLine("ingrese id de la persona ");
        int personaid;
        while (!int.TryParse(Console.ReadLine(), out personaid))
        {
            Console.WriteLine("ingrese un id válido ");
        }
    Estado asistencia;
    Console.WriteLine("ingrese un estado de asistencia");
     while (!Estado.TryParse(Console.ReadLine(), out asistencia))
    {
        Console.WriteLine("ingrese un Estado válido ");
    }
        return new Reserva(id,personaid, eventoid, asistencia);
    }
    
    static EventoDeportivo InicializarEventoeportivoM()
{
    int id;
    Console.WriteLine("ingrese el id del evento");
    while (!int.TryParse(Console.ReadLine(), out id))
    {
        Console.WriteLine("ingrese un id valido");
    }

    Console.WriteLine("ingrese nombre del evento ");
    string? nombre = Console.ReadLine();

    Console.WriteLine("ingrese descripción del evento ");
    string? descripcion = Console.ReadLine();

    Console.WriteLine("ingrese fecha y hora de inicio (yyyy-MM-dd HH:mm):");
    DateTime fechaHoraInicio;
    while (!DateTime.TryParse(Console.ReadLine(), out fechaHoraInicio))
    {
        Console.WriteLine("ingrese una fecha y hora válida (yyyy-MM-dd HH:mm):");
    }

    Console.WriteLine("ingrese duración en horas ");
    double duracionHoras;
    while (!double.TryParse(Console.ReadLine(), out duracionHoras))
    {
        Console.WriteLine("ingrese una duración válida ");
    }

    Console.WriteLine("ingrese cupo máximo");
    int cupoMaximo;
    while (!int.TryParse(Console.ReadLine(), out cupoMaximo))
    {
        Console.WriteLine("ingrese un cupo máximo válido");
    }

    Console.WriteLine("ingrese id del responsable");
    int responsableId;
    while (!int.TryParse(Console.ReadLine(), out responsableId))
    {
        Console.WriteLine("ingrese un ID de responsable válido ");
    }
    return new EventoDeportivo(id, nombre, cupoMaximo, fechaHoraInicio, duracionHoras, descripcion, responsableId);
}
