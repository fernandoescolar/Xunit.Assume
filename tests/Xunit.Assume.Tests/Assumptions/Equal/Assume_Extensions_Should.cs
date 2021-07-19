using System;

namespace Xunit.Tests.Equal
{
    public class Assume_Extensions_Should : Base
    {
        protected override bool Act(object objA, object objB, string message = null)
        {
            objA = objA ?? throw new ArgumentNullException(nameof(objA), "Invalid test");

            if (string.IsNullOrEmpty(message))
                return objA.AssumeEqual(objB);

            return objA.AssumeEqual(objB, message);
        }
    }
}