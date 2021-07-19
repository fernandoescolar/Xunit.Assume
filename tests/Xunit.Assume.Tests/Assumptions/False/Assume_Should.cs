namespace Xunit.Tests.False
{
    public class Assume_Should : Base
    {
        protected override bool Act(bool condition, string message = null)
        {
            if (string.IsNullOrEmpty(message))
                return Assume.False(condition);

            return Assume.False(condition, message);
        }
    }
}