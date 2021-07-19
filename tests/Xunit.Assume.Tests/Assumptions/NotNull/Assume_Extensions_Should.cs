namespace Xunit.Tests.NotNull
{
    public class Assume_Extensions_Should : Base
    {
        protected override object Act(object input, string message = null)
        {
            if (string.IsNullOrEmpty(message))
                return input.AssumeNotNull();

            return input.AssumeNotNull(message);
        }
    }
}