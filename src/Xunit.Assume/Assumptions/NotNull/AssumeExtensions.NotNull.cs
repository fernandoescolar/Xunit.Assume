﻿namespace Xunit
{
    public static partial class AssumeExtensions
    {
        /// <summary>
        ///     Assumes that the specified <paramref name="obj" /> is not null.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the object to assume is not null.
        /// </typeparam>
        /// <param name="obj">
        ///     The object that is not expected to be null.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     The specified object.
        /// </returns>
        public static T AssumeNotNull<T>(this T obj, string message = null)
            => Assume.NotNull(obj, message);
    }
}
