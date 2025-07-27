namespace Xunit.Tests.False
{
    public class Assume_Extensions_Should : Base
    {
        protected override bool Act(bool condition, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
                return condition.AssumeFalse();

            return condition.AssumeFalse(message);
        }
    }
}