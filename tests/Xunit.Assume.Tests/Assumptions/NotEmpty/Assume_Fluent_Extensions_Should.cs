using System;

namespace Xunit.Tests.NotEmpty
{
    public class Assume_Fluent_Extensions_Should : Base
    {
        protected override string Act(string input, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
                return input.Assume().NotEmpty()!;

            return input.Assume().NotEmpty(message)!;
        }
    }
}