using System;
using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class AssumeExtensions
    {
        [Obsolete("As Equals is an override of Object.Equals(). AssumeNotEquals has been replaced by AssumeNotEqual.", true)]
        public static bool AssumeNotEquals<T>(this T expected, T target, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => AssumeNotEqual(expected, target, message, callerFilePath, callerLineNumber);
    }
}
