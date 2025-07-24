using System;
using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class Assume
    {
        /// <summary>
        ///     Assumes that the specified <paramref name="obj" /> is not null.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the object to assume is not null.
        /// </typeparam>
        /// <param name="obj">
        ///     The object that is not expected to be null.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     The specified object.
        /// </returns>
        public static T? NotNull<T>(T obj, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => That(obj != null, message) ? obj : default;

        /// <summary>
        ///     Assumes that the specified object returned in <paramref name="getter" /> is not null.
        /// </summary>
        /// <param name="getter">
        ///     The expression that is not expected to be null.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     The object returned in the <paramref name="getter" />.
        /// </returns>
        public static T? NotNull<T>(Func<T> getter, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => NotNull(getter(), message, callerFilePath, callerLineNumber);
    }
}
