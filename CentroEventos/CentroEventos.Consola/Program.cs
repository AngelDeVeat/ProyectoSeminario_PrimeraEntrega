// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata;
using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.UseCases;

int Usuario=3;
IRepositorioPersona repositorioPersona = new RepositorioPersonaTXT();
IRepositorioEventoDeportivo repositorioEventoDeportivo = new RepositorioEventoDeportivoTXT();
IRepositorioReserva repositorioReserva = new RepositorioReservaTXT();
IServicioAutorizacion autorizacion = new ServicioAutorizacionProvisorio();

bool ok = false;
while (ok == false)
{
    Console.WriteLine("Ingrese id de usuario 1 o 0 : (ingrese 1 para poder probar los casos si elige 0 entonces solo podra acceder a los listados)");
    string? lec = Console.ReadLine();
    if (int.TryParse(lec, out Usuario))
    {
        if (Usuario == 0 || Usuario == 1)
            ok = true;
        else
            Console.WriteLine("Ingrese id valido(1 o 0)");

    }
    else
    {
        Console.WriteLine("Ingrese un numero 1 o 0");
    }
}
Console.WriteLine("");
Console.WriteLine("///////////////////////////////////////////////////////////////////////////////");
Console.WriteLine("");
ok = false;
while (ok == false)
{
    int Opcion;
    Console.WriteLine("Ingrese que operacion desea realizar: ");
    Console.WriteLine("Entidad Persona: ");
    Console.WriteLine("  Alta de Persona => 1");
    Console.WriteLine("  Baja de Persona => 2");
    Console.WriteLine("  Listar Personas => 3");
    Console.WriteLine("  Modificar Persona => 4");
    Console.WriteLine("Entidad Reserva: ");
    Console.WriteLine("  Alta de Reserva => 5");
    Console.WriteLine("  Baja de Reserva => 6");
    Console.WriteLine("  Listar Reservas => 7");
    Console.WriteLine("  Modificar Reserva => 8");
    Console.WriteLine("Entidad Evento Deportivo: ");
    Console.WriteLine("  Alta de Evento => 9");
    Console.WriteLine("  Baja de Evento => 10");
    Console.WriteLine("  Listar Eventos => 11");
    Console.WriteLine("  Modificar Evento => 12");
    Console.WriteLine("  Listar eventos con cupos disponibles => 13");
    Console.WriteLine("  Listar asistentes a un evento pasado => 14");
    Console.WriteLine("");
    Console.WriteLine("pulse cualquier otro valor para cerrar menu");

    string? lec = Console.ReadLine();

    Console.WriteLine("");
    Console.WriteLine("///////////////////////////////////////////////////////////////////////////////");
    Console.WriteLine("");

    if (int.TryParse(lec, out Opcion))
    {
        if (Opcion < 1 || Opcion > 14)
        {
            ok = true;
        }
        else
        {
            bool finalizar = false;
            while (!finalizar)
            {
                try
                {
                    finalizar = true;
                    switch (Opcion)
                    {
                        // Alta de persona
                        case 1:
                            PersonaAltaUseCase AltaPersona = new PersonaAltaUseCase(repositorioPersona, autorizacion);
                            Persona nuevaPersona = InicializarPersona();
                            AltaPersona.Alta(nuevaPersona, Usuario);

                            Console.WriteLine($"Se ha dado de alta correctamente a la persona {nuevaPersona.ToString()}");
                            break;
                        // Baja de persona
                        case 2:
                            PersonaBajaUseCase BajaPersona = new PersonaBajaUseCase(repositorioReserva, repositorioPersona, autorizacion);
                            Console.WriteLine("[Ingrese id de la Persona a dar de baja]");
                            int idbaja;
                            while (!int.TryParse(Console.ReadLine(), out idbaja))
                            {
                                Console.WriteLine("ingrese un id válido ");
                            }
                            BajaPersona.Baja(idbaja, Usuario);

                            Console.WriteLine($"Se ha eliminado a la persona con id = {idbaja} correctamente");
                            break;
                        // Listar personas
                        case 3:
                            PersonaListadoUseCase ListadoPersona = new PersonaListadoUseCase(repositorioPersona);
                            var personas = ListadoPersona.Listado();
                            foreach (var p in personas)
                            {
                                Console.WriteLine(p.ToString());
                            }
                            break;
                        // Modificar persona
                        case 4:
                            PersonaModificacionUseCase modificarPersona = new PersonaModificacionUseCase(repositorioPersona, autorizacion);
                            Persona personaMod = InicializarPersonaM();//uso otro metodo que usa otro constructor de Persona para poder hacer la busqueda por id  
                            modificarPersona.Modificacion(personaMod, Usuario);

                            Console.WriteLine($"Se ha modificado a la persona de id = {personaMod.ID} correctamente");
                            break;
                        // Alta de reserva
                        case 5:
                            ReservaAltaUseCase AltaReserva = new ReservaAltaUseCase(repositorioEventoDeportivo, repositorioReserva, repositorioPersona, autorizacion);
                            Reserva nuevaReserva = InicializarReserva();
                            AltaReserva.Ejecutar(nuevaReserva, Usuario);

                            Console.WriteLine($"Se ha dado de alta correctamente a la reserva {nuevaReserva.ToString()}");
                            break;
                        // Baja de reserva
                        case 6:
                            ReservaBajaUseCase BajaReserva = new ReservaBajaUseCase(repositorioReserva, autorizacion);
                            Console.WriteLine("ingrese id de la reserva a dar de baja");
                            int idReservaBaja;
                            while (!int.TryParse(Console.ReadLine(), out idReservaBaja))
                            {
                                Console.WriteLine("ingrese un id válido ");
                            }
                            BajaReserva.Ejecutar(idReservaBaja, Usuario);

                            Console.WriteLine($"Se ha eliminado a la reserva con id = {idReservaBaja} correctamente");
                            break;
                        // Listar reservas
                        case 7:
                            ReservaListadoUseCase ListarReserva = new ReservaListadoUseCase(repositorioReserva);
                            var reservas = ListarReserva.Ejecutar();
                            foreach (var r in reservas)
                            {
                                Console.WriteLine(r.ToString());
                            }
                            break;
                        // Modificar reserva
                        case 8:
                            ReservaModificacionUseCase ModificarReserva = new ReservaModificacionUseCase(repositorioEventoDeportivo, repositorioReserva, repositorioPersona, autorizacion);
                            Reserva reservaMod = InicializarReservaM();//uso otro metodo que usa otro constructor de Reserva para poder hacer la busqueda por id
                            ModificarReserva.Ejecutar(reservaMod, Usuario);

                            Console.WriteLine($"Se ha modificado a la reserva de id = {reservaMod.ID} correctamente");
                            break;
                        // Alta de evento deportivo
                        case 9:
                            EventoDeportivoAltaUseCase AltaEvento = new EventoDeportivoAltaUseCase(repositorioEventoDeportivo, repositorioPersona, autorizacion);
                            EventoDeportivo nuevoEvento = InicializarEventoeportivo();
                            AltaEvento.Alta(nuevoEvento, Usuario);

                            Console.WriteLine($"Se ha dado de alta correctamente al evento deportivo: {nuevoEvento.ToString()}");
                            break;
                        // Baja de evento deportivo
                        case 10:
                            EventoDeportivoBajaUseCase BajaEvento = new EventoDeportivoBajaUseCase(repositorioEventoDeportivo, repositorioReserva, autorizacion);
                            Console.WriteLine("ingrese id del evento a dar de baja ");
                            int idEventoBaja;
                            while (!int.TryParse(Console.ReadLine(), out idEventoBaja))
                            {
                                Console.WriteLine("ingrese un id valido");
                            }
                            BajaEvento.Baja(idEventoBaja, Usuario);

                            Console.WriteLine($"Se ha eliminado al evento deportivo con id = {idEventoBaja} correctamente");
                            break;
                        // Listar eventos deportivos
                        case 11:
                            EventoDeportivoListadoUseCase ListarEvento = new EventoDeportivoListadoUseCase(repositorioEventoDeportivo);
                            var eventos = ListarEvento.Listado();
                            foreach (var e in eventos)
                            {
                                Console.WriteLine(e.ToString());
                            }
                            break;
                        // Modificar evento deportivo
                        case 12:
                            EventoDeportivoModificacionUseCase ModificarEvento = new EventoDeportivoModificacionUseCase(repositorioEventoDeportivo, repositorioPersona, autorizacion);
                            EventoDeportivo eventoMod = InicializarEventoeportivoM();//uso otro metodo que usa otro constructor de EventoDeportivo para poder hacer la busqueda por id
                            ModificarEvento.Modificacion(eventoMod, Usuario);

                            Console.WriteLine($"Se ha modificado al evento deportivo de id = {eventoMod.ID} correctamente");
                            break;
                        // Listar eventos con cupos disponibles
                        case 13:
                            ListarEventosConCupoDisponibleUseCase ListarEventosConCuposDis = new ListarEventosConCupoDisponibleUseCase(repositorioEventoDeportivo, repositorioReserva);
                            var eventosCupo = ListarEventosConCuposDis.Ejecutar();
                            foreach (var ec in eventosCupo)
                            {
                                Console.WriteLine(ec.ToString());
                            }
                            break;
                        // Listar asistentes a evento pasado
                        case 14:
                            ListarAsistenciaAEventoUseCase ListarAsistenciaEvento = new ListarAsistenciaAEventoUseCase(repositorioReserva, repositorioPersona, repositorioEventoDeportivo);
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
                    Console.WriteLine("");
                    Console.WriteLine("///////////////////////////////////////////////////////////////////////////////");
                    Console.WriteLine("");
                }
                catch (FalloAutorizacionException e)
                {
                    Console.WriteLine(e.Message);
                    finalizar = true;
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    PreguntarParaContinuar(out finalizar, Opcion);
                }
            }
        }
    }
    else
    {
        ok = true;
    }
}

static void PreguntarParaContinuar(out bool finalizar, int Opcion)
{
    Console.WriteLine($"¿Desea volver a intentar la opcion {Opcion}?");
    Console.WriteLine("Presione 1 para aceptar");

    finalizar = true;
    int aux;
    if (int.TryParse(Console.ReadLine(), out aux))
    {
        if (aux == 1) finalizar = false;
    }
    Console.WriteLine("");
    Console.WriteLine("///////////////////////////////////////////////////////////////////////////////");
    Console.WriteLine("");
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

    return new Persona(id, dni, nombre ?? "", apellido ?? "", direccion ?? "", telefono, facultad ?? "", email ?? "");
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
    Console.WriteLine("ingrese un estado de asistencia (Pendiente - Presente - Ausente)");
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
