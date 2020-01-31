using Xunit.Sdk;

namespace Xunit.Tests.AssumeTests
{
    public class Equals_Should
    {
        private readonly object ObjectA = new object();
        private readonly object ObjectB = new object();

        [Fact]
        public void throw_exception_when_objects_are_not_equal()
        {
            try
            {
                Assume.Equals(ObjectA, ObjectB);
            }
            catch (AssumeException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_exception_when_objects_are_not_equal_with_specific_message()
        {
            const string message = "my_message";

            try
            {
                Assume.Equals(ObjectA, ObjectB, message);
            }
            catch (AssumeException ex)
            {
                Assert.Equal(message, ex.Message);
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void do_nothing_when_objects_are_equal()
        {
            try
            {
                Assume.Equals(ObjectA, ObjectA);
            }
            catch (AssumeException)
            {
                Assert.True(false);
            }
        }
    }
}
