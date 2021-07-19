using System;

namespace Xunit
{
    public static partial class AssumeFluentExtensions
    {
        /// <summary>
        ///     Assumes that the specified condition is false.
        /// </summary>
        /// <param name="assumption">
        ///     The specified <see cref="AssumeFluent{bool}" /> to test.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     <see cref="true" /> when condition is false.
        /// </returns>
        public static bool False(this AssumeFluent<bool> assumption, string message = null)
            => Xunit.Assume.False(assumption.InnerObject, message);

        /// <summary>
        ///     Assume that the specified condition is false.
        /// </summary>
        /// <param name="assumption">
        ///     The specified <see cref="AssumeFluent{T}" /> to test.
        /// </param>
        /// <param name="condition">
        ///     The condition to test.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     <see cref="true" /> when condition is false.
        /// </returns>
        public static T False<T>(this AssumeFluent<T> assumption, Func<T, bool> condition, string message = null)
            => Xunit.Assume.False(condition(assumption.InnerObject), message) ? assumption.InnerObject : default;
 }
}