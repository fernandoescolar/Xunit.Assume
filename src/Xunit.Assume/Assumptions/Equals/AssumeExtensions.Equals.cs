using System;
using System.Runtime.CompilerServices;

namespace Xunit
{
    public static partial class AssumeExtensions
    {
        [Obsolete("As Equals is an override of Object.Equals(). AssumeEquals has been replaced by AssumeEqual.", true)]
        public static bool AssumeEquals<T>(this T expected, T target, string? message = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
            => AssumeEqual(expected, target, message, callerFilePath, callerLineNumber);
    }
}
