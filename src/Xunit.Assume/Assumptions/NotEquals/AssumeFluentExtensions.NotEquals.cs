using System;

namespace Xunit
{
    public static partial class AssumeFluentExtensions
    {
        [Obsolete("As Equals is an override of Object.Equals(). NotEquals has been replaced by NotEqual.", true)]
        public static bool NotEquals<T>(this AssumeFluent<T> assumption, T target, string message = null)
            => NotEqual(assumption, target, message);
    }
}