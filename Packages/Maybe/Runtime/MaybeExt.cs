using System;
using System.Collections.Generic;
using System.Linq;

namespace Actuator
{
    public static class MaybeExt
    {
        public static Maybe<T> FirstOrNone<T>(this IEnumerable<T> source)
        {
            if (source.Any())
                return source.First();
            return default;
        }

        public static Maybe<T> FirstOrNone<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (!source.Any())
                return default;

            foreach (var item in source)
            {
                if (predicate(item))
                    return item;
            }

            return default;
        }
    }
}
