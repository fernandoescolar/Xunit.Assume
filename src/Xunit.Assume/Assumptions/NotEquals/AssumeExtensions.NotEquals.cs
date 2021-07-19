using System;

namespace Xunit
{
    public static partial class AssumeExtensions
    {
        [Obsolete("As Equals is an override of Object.Equals(). AssumeNotEquals has been replaced by AssumeNotEqual.", true)]
        public static bool AssumeNotEquals<T>(this T expected, T target, string message = null)
            => AssumeNotEqual(expected, target, message);
    }
}
