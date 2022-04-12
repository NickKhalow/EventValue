using System;

namespace NickKhalow.Util
{
    public interface IReadOnlyEventValue<out T> where T : new()
    {
        /// <summary>
        /// Action notifies of any value changes  
        /// </summary>
        public event Action<T> ValueChanged;

        /// <summary>
        /// Returns current value.
        /// </summary>
        public T Value { get; }
    }
}