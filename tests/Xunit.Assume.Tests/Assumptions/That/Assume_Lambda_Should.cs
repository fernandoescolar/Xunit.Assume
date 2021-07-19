namespace Xunit.Tests.That
{
    public class Assume_Lambda_Should : Base
    {
        protected override bool Act(bool condition, string message = null)
        {
            if (string.IsNullOrEmpty(message))
                return Assume.That(() => condition);

            return Assume.That(() => condition, message);
        }
    }
}