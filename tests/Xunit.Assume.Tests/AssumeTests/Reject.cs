using Xunit.Sdk;

namespace Xunit.Tests.AssumeTests
{
    public class Reject_Should
    {
        [Fact]
        public void throw_assume_exception()
        {
            try
            {
                Assume.Reject();
            }
            catch (AssumeException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_assume_exception_with_specific_message()
        {
            const string message = "my_message";

            try
            {
                Assume.Reject(message);
            }
            catch (AssumeException ex)
            {
                Assert.Equal(message, ex.Message);
                return;
            }

            Assert.True(false);
        }
    }
}
