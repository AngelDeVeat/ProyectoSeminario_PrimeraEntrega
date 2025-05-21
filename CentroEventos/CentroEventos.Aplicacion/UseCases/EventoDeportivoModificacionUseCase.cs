using System;

namespace CentroEventos.Aplicacion.UseCases;

public class EventoDeportivoModificacionUseCase
{
    private IRepositorioEventoDeportivo _ievento;
    private IRepositorioPersona _ipersona;
    private IServicioAutorizacion _autorizacion;
    public EventoDeportivoModificacionUseCase(IRepositorioEventoDeportivo ievento, IRepositorioPersona ipersona, IServicioAutorizacion autorizacion)
    {
        _ievento = ievento;
        _ipersona = ipersona;
        _autorizacion = autorizacion;
    }

    public void Modificacion(EventoDeportivo evento, int IdUsuario)
    {
        Permiso permiso = new Permiso();
        if (!_autorizacion.PoseeElPermiso(IdUsuario, permiso))
            throw new FalloAutorizacionException(IdUsuario, "Modificacion");

        if (!Validador_EventoDeportivo.exist_ID(evento.ID, _ievento))
            throw new EntidadNotFoundException("El id al que se esta intentando modificar no existe");
      
        EventoDeportivo? to_modify = _ievento.GetEventoDeportivo(evento.ID);
        if (to_modify == null)
            throw new EntidadNotFoundException("El evento deportivo a modificar no existe");
        if (!Validador_EventoDeportivo.Validar_FechaCorrecta(to_modify.FechaHoraInicio))
            throw new OperacionInvalidaException("Se ha intentado modificar un evento deportivo cuya fecha es anterior a la actual");

        if (Validador_EventoDeportivo.Validar_NombreVacio(evento.Nombre))
            throw new ValidacionException("Se intento modificar a un EventoDeportivo con campo Nombre vacio");
        if (Validador_EventoDeportivo.Validar_DescripcionVacio(evento.Descripcion))
            throw new ValidacionException("Se intento modificar a un EventoDeportivo con campo Descripcion vacio");

        if (!Validador_EventoDeportivo.Validar_FechaCorrecta(evento.FechaHoraInicio))
            throw new ValidacionException("Se intento modificar a un Evento deportivo con fecha previa a la fecha actual");

        if (!Validador_EventoDeportivo.isCorrect_CupoMaximo(evento.CupoMaximo))
            throw new ValidacionException("Se intento modificar a un Evento Deportivo con el campo CupoMaximo menor o igual a 0");
        if (!Validador_EventoDeportivo.isCorrect_DuracionHoras(evento.DuracionHoras))
            throw new ValidacionException("Se intento modificar a un Evento Deportivo con el campo DuracionHoras menor o igual a 0");

        if (!Validador_EventoDeportivo.exist_ResponsableId(evento.ResponsableID, _ipersona))
            throw new EntidadNotFoundException("El id del responsable de este evento deportivo no corresponde a ninguna persona existente");

        _ievento.ModificarEventoDeportivo(evento);
    }
}
