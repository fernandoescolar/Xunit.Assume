﻿using System;

namespace Xunit
{
    public static partial class Assume
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
        public static T Null<T>(T obj, string message = null)
            => That(obj == null, message) ? obj : default;

        /// <summary>
        ///     Assumes that the specified object returned in <paramref name="getter" /> is null.
        /// </summary>
        /// <param name="getter">
        ///     The expression that is expected to be null.
        /// </param>
        /// <param name="message">
        ///     The message to display if the assumption is rejected.
        /// </param>
        /// <returns>
        ///     The object returned in the <paramref name="getter" />.
        /// </returns>
        public static T Null<T>(Func<T> getter, string message = null)
            => Null(getter(), message);
    }
}
