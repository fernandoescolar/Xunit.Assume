namespace Xunit
{
    public static partial class Assume
    {
        /// <summary>
        ///     Rejects the current assumption.
        /// </summary>
        /// <typeparam name="T">
        ///     The type to return.
        /// </typeparam>
        /// <param name="message">
        ///     The message to display.
        /// </param>
        /// <returns>
        ///     The <typeparamref name="T"/> specified.
        /// </returns>
        public static T? Reject<T>(string? message = null, string? callerFilePath = null, int callerLineNumber = 0)
            => Reject<T>(default, message, callerFilePath, callerLineNumber);

        /// <summary>
        ///     Rejects the current assumption.
        /// </summary>
        /// <typeparam name="T">
        ///     The type to return.
        /// </typeparam>
        /// <param name="source">
        ///     The source source object to be returned.
        /// </param>
        /// <param name="message">
        ///     The message to display.
        /// </param>
        /// <returns>
        ///     The <typeparamref name="T"/> specified.
        /// </returns>
        public static T? Reject<T>(T? source, string? message = null, string? callerFilePath = null, int callerLineNumber = 0)
            => throw CreateAssumptionFailedException(message, callerFilePath, callerLineNumber);

        /// <summary>
        ///     Rejects the current assumption.
        /// </summary>
        /// <param name="message">
        ///     The message to display.
        /// </param>
        public static void Reject(string? message = null, string? callerFilePath = null, int callerLineNumber = 0)
            => throw CreateAssumptionFailedException(message, callerFilePath, callerLineNumber);
    }
}
