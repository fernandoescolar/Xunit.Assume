namespace Xunit.Tests.NotNull
{
    public class Assume_Fluent_Extensions_Should : Base
    {
        protected override object Act(object? input = null, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
                return input.Assume().NotNull()!;

            return input.Assume().NotNull(message)!;
        }
    }
}