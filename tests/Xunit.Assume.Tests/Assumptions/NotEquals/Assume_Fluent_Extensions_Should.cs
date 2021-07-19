using System;

namespace Xunit.Tests.NotEquals
{
    [Obsolete("Tests replaced by NotEqual")]
    public class Assume_Fluent_Extensions_Should : Base
    {
        protected override bool Act(object objA, object objB, string message = null)
        {
            objA = objA ?? throw new ArgumentNullException(nameof(objA), "Invalid test");

            if (string.IsNullOrEmpty(message))
                return objA.Assume().NotEquals(objB);

            return objA.Assume().NotEquals(objB, message);
        }
    }
}