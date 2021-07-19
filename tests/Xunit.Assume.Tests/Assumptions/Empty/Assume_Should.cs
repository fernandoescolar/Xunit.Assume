namespace Xunit.Tests.Empty
{
    public class Assume_Should : Base
    {
        protected override string Act(string input, string message = null)
        {
            if (string.IsNullOrEmpty(message))
                return Assume.Empty(input);

            return Assume.Empty(input, message);
        }
    }
}