using System;

namespace Xunit
{
    public static partial class Assume
    {
        [Obsolete("As Equals is an override of Object.Equals(). NotEquals has been replaced by NotEqual.", true)]
        public static bool NotEquals<T>(T expected, T target, string message = null)
            => NotEqual(expected, target, message);
    }
}
