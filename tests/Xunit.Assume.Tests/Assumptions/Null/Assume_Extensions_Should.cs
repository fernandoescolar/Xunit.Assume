using System;

namespace Xunit.Tests.Null
{
    public class Assume_Extensions_Should : Base
    {
        protected override object? Act(object? input, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                return input.AssumeNull();
            }

            return input.AssumeNull(message);
        }
    }
}