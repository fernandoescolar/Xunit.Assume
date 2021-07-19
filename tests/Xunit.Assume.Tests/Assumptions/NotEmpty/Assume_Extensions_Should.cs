using System;

namespace Xunit.Tests.NotEmpty
{
    public class Assume_Extensions_Should : Base
    {
        protected override string Act(string input, string message = null)
        {
            if (string.IsNullOrEmpty(message))
                return input.AssumeNotEmpty();

            return input.AssumeNotEmpty(message);
        }
    }
}