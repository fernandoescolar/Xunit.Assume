namespace Xunit.Tests.True
{
    public class Assume_Extensions_Lambda_Should : Base
    {
        protected override bool Act(bool condition, string message = null)
        {
            var obj = new object();
            if (string.IsNullOrEmpty(message))
                return obj.AssumeTrue(x => condition) == obj;

            return obj.AssumeTrue(x => condition, message) == obj;
        }
    }
}