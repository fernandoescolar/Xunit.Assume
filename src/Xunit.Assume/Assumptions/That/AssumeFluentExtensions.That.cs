using System;
using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class AssumeFluentExtensions
    {
        /// <summary>
        ///     Assumes that the specified <paramref name="condition" /> is true.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the object to test.
        /// </typeparam>
        /// <param name="assumption">
        ///     The specified <see cref="AssumeFluent{T}" /> to test.
        /// </param>
        /// <param name="condition">
        ///     The condition expression to test <paramref name="assumption" />.
        /// </param>
        /// <param name="message">
        ///     The message to display if the condition is false.
        /// </param>
        /// <returns>
        ///     <see cref="true" /> when the specified <paramref name="condition" /> is true.
        /// </returns>
        public static T? That<T>(this AssumeFluent<T> assumption, Func<T, bool> condition, string? message = null, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
            => Xunit.Assume.That(condition(assumption.InnerObject), message, callerFilePath, callerLineNumber) ? assumption.InnerObject : default;
    }
}