using System;
using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class Assume
    {
        [Obsolete("As Equals is an override of Object.Equals(). NotEquals has been replaced by NotEqual.", true)]
        public static bool NotEquals<T>(T expected, T target, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => NotEqual(expected, target, message, callerFilePath, callerLineNumber);
    }
}
