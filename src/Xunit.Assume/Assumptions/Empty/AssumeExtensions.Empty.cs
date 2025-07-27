using System.Collections;
using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class AssumeExtensions
    {
        /// <summary>
        ///     Assumes that the specified <paramref name="enumerable" /> is empty.
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
        public static T? AssumeEmpty<T>(this T enumerable, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0) where T : IEnumerable
            => Assume.Empty(enumerable, message, callerFilePath, callerLineNumber);
    }
}
