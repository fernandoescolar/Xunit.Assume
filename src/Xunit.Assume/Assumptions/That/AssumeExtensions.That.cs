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
        public static T? AssumeThat<T>(this T obj, Func<T, bool> condition, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => Assume.That(condition(obj), message, callerFilePath, callerLineNumber) ? obj : default;
    }
}
