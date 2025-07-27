using System;
using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class AssumeExtensions
    {
        /// <summary>
        ///     Assumes that the specified <paramref name="condition" /> is true.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the object to test.
        /// </typeparam>
        /// <param name="obj">
        ///     The object to test.
        /// </param>
        /// <param name="condition">
        ///     The condition expression to test <paramref name="obj" />.
        /// </param>
        /// <param name="message">
        ///     The message to display if the condition is false.
        /// </param>
        /// <returns>
        ///     <see cref="true" /> when the specified <paramref name="condition" /> is true.
        /// </returns>
        public static bool AssumeTrue(this bool condition, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => Assume.True(condition, message);

        /// <summary>
        ///     Assumes that the specified <paramref name="condition" /> is true.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <paramref name="source" />.
        /// </typeparam>
        /// <param name="source">
        ///     The object to be checked.
        /// </param>
        /// <param name="condition">
        ///     The condition to check.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     The <paramref name="source" /> object.
        /// </returns>
        public static T? AssumeTrue<T>(this T source, Func<T, bool> condition, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => Assume.True(condition(source), message, callerFilePath, callerLineNumber) ? source : default;
    }
}
