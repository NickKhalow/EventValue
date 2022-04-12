using System;

namespace NickKhalow.Util
{
    public sealed class EventValue<T> : IReadOnlyEventValue<T> where T : new()
    {
        /// <summary>
        /// Contains current value.
        /// </summary>
        private T _value;

        public event Action<T> ValueChanged;
        
        public T Value
        {
            get => _value;
            set => _value = value;
        }

        /// <summary>
        /// Creates an Instance of EventValue of T and returns setter, that allows set values to current Instance. 
        /// </summary>
        public EventValue(T value) => _value = value;

        /// <summary>
        /// Allows implicitly converts EventValue object to type, that it contains.
        /// </summary>
        /// <returns>Value of EventValue type.</returns>
        public static implicit operator T(EventValue<T> eventValue) => eventValue.Value;

        /// <summary>
        /// Allows implicitly converts value to EventValue shell with it.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>EventValue shell.</returns>
        public static implicit operator EventValue<T>(T value) => new EventValue<T>(value);
    }
}