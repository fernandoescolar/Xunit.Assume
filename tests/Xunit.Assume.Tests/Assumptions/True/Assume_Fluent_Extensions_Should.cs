namespace Xunit.Tests.True
{
    public class Assume_Fluent_Extensions_Should : Base
    {
        protected override bool Act(bool condition, string message = null)
        {
            if (string.IsNullOrEmpty(message))
                return condition.Assume().True();

            return condition.Assume().True(message);
        }
    }
}