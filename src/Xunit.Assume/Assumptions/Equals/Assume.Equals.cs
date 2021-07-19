using System;

namespace Xunit
{
    public static partial class Assume
    {
        [Obsolete("This is an override of Object.Equals(). Call Assume.Equal() instead.", true)]
        public static bool Equals<T>(T expected, T target, string message = null)
            => Equal(expected, target, message);
    }
}
