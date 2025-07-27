using System;
using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class Assume
    {
        /// <summary>
        ///     Assumes that the specified condition is false.
        /// </summary>
        /// <param name="condition">
        ///     The condition to check.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     <see cref="true" /> when condition is false.
        /// </returns>
        public static bool False(bool condition, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => That(!condition, message, callerFilePath, callerLineNumber);

        /// <summary>
        ///     Assume that the specified condition is false.
        /// </summary>
        /// <param name="condition">
        ///     The condition to check.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     <see cref="true" /> when condition is false.
        /// </returns>
        public static bool False(Func<bool> condition, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => False(condition(), message, callerFilePath, callerLineNumber);
 }
}
