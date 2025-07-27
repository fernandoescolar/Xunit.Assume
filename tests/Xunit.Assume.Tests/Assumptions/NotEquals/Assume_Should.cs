using System;

namespace Xunit.Tests.NotEquals
{
    [Obsolete("Tests replaced by NotEqual")]
    public class Assume_Should : Base
    {
        protected override bool Act(object objA, object objB, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
                return Assume.NotEquals(objA, objB);

            return Assume.NotEquals(objA, objB, message);
        }
    }
}