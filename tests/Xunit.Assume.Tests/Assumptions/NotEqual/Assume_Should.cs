namespace Xunit.Tests.NotEqual
{
    public class Assume_Should : Base
    {
        protected override bool Act(object objA, object objB, string message = null)
        {
            if (string.IsNullOrEmpty(message))
                return Assume.NotEqual(objA, objB);

            return Assume.NotEqual(objA, objB, message);
        }
    }
}