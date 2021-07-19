namespace Xunit.Tests.False
{
    public class Assume_Fluent_Extensions_Lambda_Should : Base
    {
        protected override bool Act(bool condition, string message = null)
        {
            var obj = new object();
            if (string.IsNullOrEmpty(message))
                return obj.Assume().False(x => condition) == obj;

            return obj.Assume().False(x => condition, message) == obj;
        }
    }
}