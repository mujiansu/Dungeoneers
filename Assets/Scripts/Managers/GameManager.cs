using System;
using Zenject;

public class GameManager : IInitializable, IDisposable, ITickable
{
    public class OpenMenuSignal { }

    public class ClonseMenuSignal { }

    public readonly SignalBus SignalBus;

    public GameManager(SignalBus signalBus)
    {
        SignalBus = signalBus;
    }
    public void OpenMenu()
    {
        SignalBus.Fire<OpenMenuSignal>();
    }

    public void CloseMenu()
    {
        SignalBus.Fire<ClonseMenuSignal>();
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
