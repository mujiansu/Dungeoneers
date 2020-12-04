using System;
using Zenject;

public class GameManager : IInitializable, IDisposable, ITickable
{
    public class OpenMenuSignal { }

    public class CloseMenuSignal { }

    public readonly SignalBus SignalBus;

    private bool IsMenuOpen = false;

    public GameManager(SignalBus signalBus)
    {
        SignalBus = signalBus;
    }
    public void OpenMenu()
    {
        IsMenuOpen = true;
        SignalBus.Fire<OpenMenuSignal>();
    }

    public void CloseMenu()
    {
        IsMenuOpen = false;
        SignalBus.Fire<CloseMenuSignal>();
    }

    public void ToggleMenu()
    {
        if (IsMenuOpen) CloseMenu();
        else OpenMenu();
    }


    public void Initialize()
    {
    }

    public void Dispose()
    {
    }

    public void Tick()
    {
    }
}
