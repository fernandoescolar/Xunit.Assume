using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class AssumeExtensions
    {
        /// <summary>
        ///     Assumes that the specified <paramref name="obj" /> is null.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the object to assume is null.
        /// </typeparam>
        /// <param name="obj">
        ///     The object that is expected to be null.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     The specified object.
        /// </returns>
        public static T? AssumeNull<T>(this T obj, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => Assume.Null(obj, message, callerFilePath, callerLineNumber);
    }
}
