using System;
using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class Assume
    {
        [Obsolete("This is an override of Object.Equals(). Call Assume.Equal() instead.", true)]
        public static bool Equals<T>(T expected, T target, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => Equal(expected, target, message, callerFilePath, callerLineNumber);
    }
}
