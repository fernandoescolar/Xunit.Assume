using System.Collections;

namespace Xunit
{
    public static partial class AssumeFluentExtensions
    {
         /// <summary>
        ///     Assumes that the specified <paramref name="enumerable" /> is not empty.
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
        public static T NotEmpty<T>(this AssumeFluent<T> assumption, string message = null) where T : IEnumerable
            => Xunit.Assume.NotEmpty(assumption.InnerObject, message);
    }
}