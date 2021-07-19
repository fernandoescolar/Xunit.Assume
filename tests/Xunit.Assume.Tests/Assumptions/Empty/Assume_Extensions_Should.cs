using System;

namespace Xunit.Tests.Empty
{
    public class Assume_Extensions_Should : Base
    {
        protected override string Act(string input, string message = null)
        {
            input = input ?? throw new ArgumentNullException(nameof(input), "Invalid test");

            if (string.IsNullOrEmpty(message))
                return input.AssumeEmpty();

            return input.AssumeEmpty(message);
        }
    }
}