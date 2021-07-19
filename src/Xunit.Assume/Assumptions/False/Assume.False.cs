using System;

namespace Xunit
{
    public static partial class Assume
    {
        /// <summary>
        ///     Assumes that the specified condition is false.
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
        public static bool False(bool condition, string message = null)
            => That(!condition, message);

        /// <summary>
        ///     Assume that the specified condition is false.
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
        public static bool False(Func<bool> condition, string message = null)
            => False(condition(), message);
 }
}
