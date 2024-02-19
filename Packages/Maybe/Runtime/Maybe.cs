using System;

namespace Actuator
{
    public readonly struct Maybe<T>
    {
        private readonly T _value;
        private readonly bool _hasValue;

        public Maybe(T value)
        {
            if (value == null 
                || value.Equals(default))   // unity using fake objects as null means we need to do this
            {
                _value = default;
                _hasValue = false;
                return;
            }

            _value = value;
            _hasValue = true;
        }

        public Maybe(T value, bool hasValue)
        {
            _value = value;
            _hasValue = hasValue;
        }

        public static Maybe<T> None() => new(default, false);

        public bool IsNone => !IsSome;
        public bool IsSome => _hasValue;
        public T Value() => _value;
        public T ValueOr(T defaultValue) => _hasValue ? _value : defaultValue;

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

    public static class Maybe
    {
        public static Maybe<T> Some<T>(T value) => new(value, true);
        public static Maybe<T> None<T>() => new(default, false);
    }
}