namespace Xunit.Tests.True
{
    public class Assume_Fluent_Extensions_Lambda_Should : Base
    {
        protected override bool Act(bool condition, string message = null)
        {
            var obj = new object();
            if (string.IsNullOrEmpty(message))
                return obj.Assume().True(x => condition) == obj;

            return obj.Assume().True(x => condition, message) == obj;
        }
    }
}