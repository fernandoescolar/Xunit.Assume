namespace Xunit.Tests.True
{
    public class Assume_Extensions_Should : Base
    {
        protected override bool Act(bool condition, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
                return condition.AssumeTrue();

            return condition.AssumeTrue(message);
        }
    }
}