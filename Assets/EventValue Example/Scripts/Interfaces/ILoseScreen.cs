using System;

namespace EventValue_Example.Scripts.Interfaces
{
    public interface ILoseScreen
    {
        event Action RestartRequest;

        void Show();
    }
}