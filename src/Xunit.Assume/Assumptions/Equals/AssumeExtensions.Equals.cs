using System;

namespace Xunit
{
    public static partial class AssumeExtensions
    {
        [Obsolete("As Equals is an override of Object.Equals(). AssumeEquals has been replaced by AssumeEqual.", true)]
        public static bool AssumeEquals<T>(this T expected, T target, string message = null)
            => AssumeEqual(expected, target, message);
    }
}
