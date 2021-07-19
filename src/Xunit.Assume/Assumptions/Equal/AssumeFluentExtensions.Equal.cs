namespace Xunit
{
    public static partial class AssumeFluentExtensions
    {
        /// <summary>
        ///     Assumes that two objects are equal.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the objects being compared.
        /// </typeparam>
        /// <param name="assumption">
        ///     The specified <see cref="AssumeFluent{T}" /> to test.
        /// </param>
        /// <param name="actual">
        ///     The actual value
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     <see cref="true" /> when objects are equal.
        /// </returns>
        public static bool Equal<T>(this AssumeFluent<T> assumption, T target, string message = null)
            => Xunit.Assume.Equal(assumption.InnerObject, target, message);
    }
}