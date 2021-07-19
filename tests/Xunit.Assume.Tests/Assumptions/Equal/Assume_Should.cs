namespace Xunit.Tests.Equal
{
    public class Assume_Should : Base
    {
        protected override bool Act(object objA, object objB, string message = null)
        {
            if (string.IsNullOrEmpty(message))
                return Assume.Equal(objA, objB);

            return Assume.Equal(objA, objB, message);
        }
    }
}