namespace Xunit.Tests.NotNull
{
    public class Assume_Should : Base
    {
        protected override object Act(object? input = null, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
                return Assume.NotNull(input)!;

            return Assume.NotNull(input, message)!;
        }
    }
}