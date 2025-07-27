namespace Xunit.Tests.NotEmpty
{
    public class Assume_Should : Base
    {
        protected override string Act(string input, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
                return Assume.NotEmpty(input)!;

            return Assume.NotEmpty(input, message)!;
        }
    }
}