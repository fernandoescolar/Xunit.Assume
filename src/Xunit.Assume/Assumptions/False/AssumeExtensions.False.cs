using System;

namespace Xunit
{
    public static partial class AssumeExtensions
    {
        /// <summary>
        ///     Assumes that the specified <paramref name="condition" /> is false.
        /// </summary>
        /// <param name="condition">
        ///     The condition to check.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     <see cref="true" /> when condition is false.
        /// </returns>
        public static bool AssumeFalse(this bool condition, string message = null)
            => Assume.False(condition, message);

        /// <summary>
        ///     Assumes that the specified <paramref name="condition" /> is false.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <paramref name="source" />.
        /// </typeparam>
        /// <param name="source">
        ///     The object to be checked.
        /// </param>
        /// <param name="condition">
        ///     The condition to check.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     The <paramref name="source" /> object.
        /// </returns>
        public static T AssumeFalse<T>(this T source, Func<T, bool> condition, string message = null)
            => Xunit.Assume.False(condition(source), message) ? source : default;
    }
}
