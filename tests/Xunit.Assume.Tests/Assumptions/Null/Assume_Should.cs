namespace Xunit.Tests.Null
{
    public class Assume_Should : Base
    {
        protected override object? Act(object? input, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
                return Assume.Null(input);

            return Assume.Null(input, message);
        }
    }
}