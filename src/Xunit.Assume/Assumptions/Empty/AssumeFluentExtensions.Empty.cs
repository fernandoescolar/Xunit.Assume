using System.Collections;

namespace Xunit
{
    public static partial class AssumeFluentExtensions
    {
        /// <summary>
        ///     Assumes that the specified enumerable in <paramref name="assumption" /> is empty.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the enumerable.
        /// </typeparam>
        /// <param name="assumption">
        ///     The specified <see cref="AssumeFluent{string}" /> to test.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     The specified enumerable to be tested.
        /// </returns>
        public static T Empty<T>(this AssumeFluent<T> assumption, string message = null) where T : IEnumerable
            => Xunit.Assume.Empty(assumption.InnerObject, message);
    }
}