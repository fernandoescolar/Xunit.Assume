using System;
using System.Collections;
using System.Linq;

namespace Xunit
{
    public static partial class Assume
    {
        /// <summary>
        ///     Assumes that the specified <paramref name="enumerable" /> is not empty.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the enumerable.
        /// </typeparam>
        /// <param name="enumerable">
        ///     The enumerable to be tested.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     The specified enumerable to be tested.
        /// </returns>
        public static T NotEmpty<T>(T enumerable, string message = null) where T : IEnumerable
            => That(enumerable.Cast<object>().Any(), message) ? enumerable : default;

        /// <summary>
        ///     Assumes that the specified enumerable returned in <paramref name="getter" /> is not empty.
        /// </summary>
        /// <typeparam name="T">The type of the enumerable.</typeparam>
        /// <param name="getter">
        ///     The collection to be tested.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     The specified enumerable to be tested.
        /// </returns>
        public static T NotEmpty<T>(Func<T> getter, string message = null) where T : IEnumerable
            => NotEmpty(getter(), message);
    }
}
