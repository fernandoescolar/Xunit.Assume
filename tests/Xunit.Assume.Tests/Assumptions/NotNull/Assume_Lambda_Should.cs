namespace Xunit.Tests.NotNull
{
    public class Assume_Lambda_Should : Base
    {
        protected override object Act(object input, string message = null)
        {
            if (string.IsNullOrEmpty(message))
                return Assume.NotNull(() => input);

            return Assume.NotNull(() => input, message);
        }
    }
}