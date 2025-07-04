using System;

namespace CentroEventos.Aplicacion;

public class UserState
{
    //public Usuario? user { get; set; }

    private Usuario? _user;
    public Usuario? user
    {
        get => _user;
        set
        {
            _user = value;
            NotifyUserChanged();
        }
    }

    public event Action? OnUserChanged;

    private void NotifyUserChanged() => OnUserChanged?.Invoke();

}
