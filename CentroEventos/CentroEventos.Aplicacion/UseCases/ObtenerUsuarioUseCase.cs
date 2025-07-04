using System;

namespace CentroEventos.Aplicacion;

public class ObtenerUsuarioUseCase
{
    private IRepositorioUsuario _isuario;
    public ObtenerUsuarioUseCase(IRepositorioUsuario isuario)
    {
        _isuario = isuario;
    }

    public Usuario? Ejecutar(int id)
    {
        return _isuario.GetUsuario(id);
    }
}
