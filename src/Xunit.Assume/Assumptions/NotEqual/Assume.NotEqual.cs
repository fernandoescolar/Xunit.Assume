namespace Xunit
{
    public static partial class Assume
    {
        /// <summary>
        ///     Assumes that two objects are not equal.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the objects being compared.
        /// </typeparam>
        /// <param name="expected">
        ///     The expected value
        /// </param>
        /// <param name="actual">
        ///     The actual value
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     <see cref="true" /> when objects are not equal.
        /// </returns>
        public static bool NotEqual<T>(T expected, T target, string message = null)
            => That(!expected.Equals(target), message);
    }
}
