using System;
using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class Assume
    {
        /// <summary>
        ///     Assumes that the specified <paramref name="condition" /> is true.
        /// </summary>
        /// <param name="condition">
        ///     The condition to test.
        /// </param>
        /// <param name="message">
        ///     The message to display if the condition is false.
        /// </param>
        /// <returns>
        ///     <see cref="true" /> when the specified <paramref name="condition" /> is true.
        /// </returns>
        public static bool That(bool condition, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => condition
                ? true
                : Reject<bool>(message, callerFilePath, callerLineNumber);

        /// <summary>
        ///     Assumes that the specified <paramref name="condition" /> is true.
        /// </summary>
        /// <param name="condition">
        ///     The expression to test.
        /// </param>
        /// <param name="message">
        ///     The message to display if the condition is false.
        /// </param>
        /// <returns>
        ///     <see cref="true" /> when the specified <paramref name="condition" /> is true.
        /// </returns>
        public static bool That(Func<bool> condition, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => That(condition(), message, callerFilePath, callerLineNumber);
    }
}
