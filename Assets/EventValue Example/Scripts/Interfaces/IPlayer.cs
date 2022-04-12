using System;
using NickKhalow.Util;

namespace EventValue_Example.Scripts.Interfaces
{
    public interface IPlayer
    {
        public event Action OutOfScreen;
        public IReadOnlyEventValue<int> JumpCount { get; }

        void Freeze();
    }
}