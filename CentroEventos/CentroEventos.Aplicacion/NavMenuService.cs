using System;

namespace CentroEventos.Aplicacion;

public class NavMenuService
{
    public event Action? OnMenuChanged;

    public void ActualizarMenu()
    {
        OnMenuChanged?.Invoke();
    }
}
