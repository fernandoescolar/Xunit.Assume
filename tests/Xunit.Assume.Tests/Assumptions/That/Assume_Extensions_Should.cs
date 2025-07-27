namespace Xunit.Tests.That
{
    public class Assume_Extensions_Should : Base
    {
        protected override bool Act(bool condition, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
                return condition.AssumeThat(x => x && condition);

            return condition.AssumeThat(x => x && condition, message);
        }
    }
}