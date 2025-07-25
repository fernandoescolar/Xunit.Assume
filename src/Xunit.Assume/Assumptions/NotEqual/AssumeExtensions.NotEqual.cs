using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class AssumeExtensions
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
        public static bool AssumeNotEqual<T>(this T expected, T target, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => Assume.NotEqual(expected, target, message, callerFilePath, callerLineNumber);
    }
}
