using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class AssumeFluentExtensions
    {
        /// <summary>
        ///     Assumes that the specified <paramref name="assumption" /> is not null.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the object to assume is not null.
        /// </typeparam>
        /// <param name="assumption">
        ///     The specified <see cref="AssumeFluent{T}" /> to test.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     The specified object.
        /// </returns>
        public static T? NotNull<T>(this AssumeFluent<T> assumption, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => Xunit.Assume.NotNull(assumption.InnerObject, message, callerFilePath, callerLineNumber);
    }
}