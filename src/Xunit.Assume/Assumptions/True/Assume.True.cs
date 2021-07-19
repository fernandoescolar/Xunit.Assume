using System;

namespace Xunit
{
    public static partial class Assume
    {
        /// <summary>
        ///     Assumes that the specified <paramref name="condition" /> is true.
        /// </summary>
        /// <param name="condition">
        ///     The condition to test.
        /// </param>
        /// <param name="message">
        ///     The message to display if the condition is false.
        /// </param>
        /// <returns>
        ///     <see cref="true" /> when the specified <paramref name="condition" /> is true.
        /// </returns>
        public static bool True(bool condition, string message = null)
            => That(condition, message);

        /// <summary>
        ///     Assumes that the specified <paramref name="condition" /> is true.
        /// </summary>
        /// <param name="condition">
        ///     The expression to test.
        /// </param>
        /// <param name="message">
        ///     The message to display if the condition is false.
        /// </param>
        /// <returns>
        ///     <see cref="true" /> when the specified <paramref name="condition" /> is true.
        /// </returns>
        public static bool True(Func<bool> condition, string message = null)
            => True(condition(), message);
    }
}
