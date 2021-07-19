using System;

namespace Xunit
{
    public static partial class AssumeFluentExtensions
    {
        /// <summary>
        ///     Assumes that the specified <paramref name="assumption" /> is true.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the object to test.
        /// </typeparam>
        /// <param name="assumption">
        ///     The specified <see cref="AssumeFluent{T}" /> to test.
        /// </param>
        /// <param name="message">
        ///     The message to display if the condition is false.
        /// </param>
        /// <returns>
        ///     <see cref="true" /> when the specified <paramref name="assumption" /> is true.
        /// </returns>
        public static bool True(this AssumeFluent<bool> assumption, string message = null)
            => Xunit.Assume.True(assumption.InnerObject, message);

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
        public static T True<T>(this AssumeFluent<T> assumption, Func<T, bool> condition, string message = null)
            => Xunit.Assume.True(condition(assumption.InnerObject), message) ? assumption.InnerObject : default;
    }
}