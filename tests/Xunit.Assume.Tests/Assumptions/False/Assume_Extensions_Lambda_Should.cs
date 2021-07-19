namespace Xunit.Tests.False
{
    public class Assume_Extensions_Lambda_Should : Base
    {
        protected override bool Act(bool condition, string message = null)
        {
            var obj = new object();
            if (string.IsNullOrEmpty(message))
                return obj.AssumeFalse(x => condition) == obj;

            return obj.AssumeFalse(x => condition, message) == obj;
        }
    }
}