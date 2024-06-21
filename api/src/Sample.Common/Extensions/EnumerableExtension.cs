using System.Collections.Generic;
using System.Linq;

namespace Sample.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool SafeEmpty<T>(this IEnumerable<T> list) => list.SafeCount() == 0;

        public static bool SafeAny<T>(this IEnumerable<T> list) => list != null && list.Any();

        public static int SafeCount<T>(this IEnumerable<T> list) => list?.Count() ?? 0;
    }
}