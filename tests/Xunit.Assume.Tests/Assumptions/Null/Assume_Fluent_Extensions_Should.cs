namespace Xunit.Tests.Null
{
    public class Assume_Fluent_Extensions_Should : Base
    {
        protected override object Act(object input, string message = null)
        {
            if (string.IsNullOrEmpty(message))
                return input.Assume().Null();

            return input.Assume().Null(message);
        }
    }
}