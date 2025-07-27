using System;

namespace Xunit.Tests.Equals
{
    [Obsolete("Tests replaced by Equal")]
    public class Assume_Should : Base
    {
        protected override bool Act(object objA, object objB, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
                return Assume.Equals(objA, objB);

            return Assume.Equals(objA, objB, message);
        }
    }
}