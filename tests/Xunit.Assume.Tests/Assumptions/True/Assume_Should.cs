namespace Xunit.Tests.True
{
    public class Assume_Should : Base
    {
        protected override bool Act(bool condition, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
                return Assume.True(condition);

            return Assume.True(condition, message);
        }
    }
}