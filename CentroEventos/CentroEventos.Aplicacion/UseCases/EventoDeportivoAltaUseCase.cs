using System;

namespace CentroEventos.Aplicacion;

public class EventoDeportivoAltaUseCase
{
    private IRepositorioEventoDeportivo _ievento;
    private IRepositorioPersona _ipersona;
    private IServicioAutorizacion _autorizacion;
    public EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo ievento, IRepositorioPersona ipersona, IServicioAutorizacion autorizacion)
    {
        _ievento = ievento;
        _ipersona = ipersona;
        _autorizacion = autorizacion;
    }

    public void Alta(EventoDeportivo evento, Usuario usuario)
    {
        Permiso permiso = Permiso.EventoAlta;
        if (!_autorizacion.PoseeElPermiso(usuario.Permisos, permiso))
            throw new FalloAutorizacionException(usuario.Nombre, "Alta");

        if (Validador_EventoDeportivo.Validar_NombreVacio(evento.Nombre))
            throw new ValidacionException("Se intento dar alta a un EventoDeportivo con campo Nombre vacio");
        if (Validador_EventoDeportivo.Validar_DescripcionVacio(evento.Descripcion))
            throw new ValidacionException("Se intento dar alta a un EventoDeportivo con campo Descripcion vacio");

        if (!Validador_EventoDeportivo.Validar_FechaCorrecta(evento.FechaHoraInicio))
            throw new ValidacionException("Se intento dar alta a un Evento deportivo con fecha previa a la fecha actual");

        if (!Validador_EventoDeportivo.isCorrect_CupoMaximo(evento.CupoMaximo))
            throw new ValidacionException("Se intento dar alta a un Evento Deportivo con el campo CupoMaximo menor o igual a 0");
        if (!Validador_EventoDeportivo.isCorrect_DuracionHoras(evento.DuracionHoras))
            throw new ValidacionException("Se intento dar alta a un Evento Deportivo con el campo DuracionHoras menor o igual a 0");

        if (!Validador_EventoDeportivo.exist_ResponsableId(evento.ResponsableID, _ipersona))
            throw new EntidadNotFoundException("El id del responsable de este evento deportivo no corresponde a ninguna persona existente");

        _ievento.AgregarEventoDeportivo(evento);
    }

}
