using System;

namespace Actuator
{
    public readonly struct Maybe<T>
    {
        private readonly T _value;
        private readonly bool _hasValue;

        public Maybe(T value)
        {
            if (value is null)
            {
                _value = default;
                _hasValue = false;
            }
            else
            {
                _value = value;
                _hasValue = true;
            }
        }

        public bool IsNone => !IsSome;
        public bool IsSome => _hasValue;
        public T Value() => _value;
        public T ValueOr(T defaultValue) => _hasValue ? _value : defaultValue;

        public static implicit operator Maybe<T>(T value) => new(value);

        public void MatchSome(Action<T> action)
        {
            if (_hasValue)
                action(_value);
        }

        public void MatchNone(Action action)
        {
            if (!_hasValue)
                action();
        }

        public void Match(Action<T> some, Action none)
        {
            if (_hasValue)
                some(_value);
            else
                none();
        }
    }
}