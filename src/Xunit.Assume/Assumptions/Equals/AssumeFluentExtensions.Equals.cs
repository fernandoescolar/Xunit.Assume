using System;
using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class AssumeFluentExtensions
    {
        [Obsolete("This is an override of Object.Equals(). Call AssumeFluent<T>.Equal() instead.", true)]
        public static bool Equals<T>(this AssumeFluent<T> assumption, T target, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => assumption.Equal(target, message, callerFilePath, callerLineNumber);
    }
}