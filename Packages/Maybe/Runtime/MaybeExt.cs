using System;
using System.Collections.Generic;
using System.Linq;

namespace Actuator
{
    public static class MaybeExt
    {
        public static Maybe<T> FirstOrNone<T>(this IEnumerable<T> source)
        {
            if (!source.Any())
                return Maybe<T>.None();

            return new(source.First());
        }

        public static Maybe<T> FirstOrNone<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (!source.Any())
                return Maybe<T>.None();

            foreach (var item in source)
            {
                if (predicate(item))
                    return new(item);
            }

            return Maybe<T>.None();
        }

        public static IEnumerable<Maybe<T>> ToMaybe<T>(this IEnumerable<T> source)
        {
            foreach (var item in source)
                yield return new(item);
        }
    }
}
