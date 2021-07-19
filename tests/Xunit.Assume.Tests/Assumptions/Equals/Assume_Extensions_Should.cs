using System;

namespace Xunit.Tests.Equals
{
    [Obsolete("Tests replaced by Equal")]
    public class Assume_Extensions_Should : Base
    {
        protected override bool Act(object objA, object objB, string message = null)
        {
            objA = objA ?? throw new ArgumentNullException(nameof(objA), "Invalid test");
            return objA.AssumeEquals(objB, message);
        }
    }
}