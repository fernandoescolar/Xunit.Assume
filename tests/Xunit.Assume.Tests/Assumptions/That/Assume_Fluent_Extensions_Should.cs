namespace Xunit.Tests.That
{
    public class Assume_Fluent_Extensions_Should : Base
    {
        protected override bool Act(bool condition, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
                return condition.Assume().That(x => x && condition);

            return condition.Assume().That(x => x && condition, message);
        }
    }
}