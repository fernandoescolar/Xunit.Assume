using System;
using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class AssumeFluentExtensions
    {
        [Obsolete("As Equals is an override of Object.Equals(). NotEquals has been replaced by NotEqual.", true)]
        public static bool NotEquals<T>(this AssumeFluent<T> assumption, T target, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => NotEqual(assumption, target, message, callerFilePath, callerLineNumber);
    }
}