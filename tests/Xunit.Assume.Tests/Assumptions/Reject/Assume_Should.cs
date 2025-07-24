using Xunit.Sdk;

namespace Xunit.Tests.Reject
{
    public class Assume_Should
    {
        [Fact]
        public void throw_assume_exception()
        {
            try
            {
                Assume.Reject();
            }
            catch (AssumptionFailedException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_assume_exception_with_specific_message()
        {
            const string message = "my_message";
            const string fileName = "my_file_name";
            const int lineNumber = 3;

            try
            {
                Assume.Reject(message, fileName, lineNumber);
            }
            catch (AssumptionFailedException ex)
            {
                Assert.Contains(message, ex.Message);
                Assert.Contains(fileName, ex.Message);
                Assert.Contains(lineNumber.ToString(), ex.Message);
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_assume_exception_with_null_pattern()
        {
            try
            {
                var null_object = (object)null;
                var s = null_object ?? Assume.Reject<string>();
            }
            catch (AssumptionFailedException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_assume_exception_with_null_pattern_with_parameter()
        {
            try
            {
                var null_object = (object)null;
                var s = null_object ?? Assume.Reject(null_object);
            }
            catch (AssumptionFailedException)
            {
                return;
            }

            Assert.True(false);
        }
    }
}
