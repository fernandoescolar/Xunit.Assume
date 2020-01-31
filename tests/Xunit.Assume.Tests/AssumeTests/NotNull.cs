using Xunit.Sdk;

namespace Xunit.Tests.AssumeTests
{
    public class NotNull_Should
    {
        [Fact]
        public void throw_exception_when_object_is_null()
        {
            const object obj = null;

            try
            {
                Assume.NotNull(obj);
            }
            catch (AssumeException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_exception_when_object_is_null_with_specific_message()
        {
            const object obj = null;
            const string message = "my_message";

            try
            {
                Assume.NotNull(obj, message);
            }
            catch (AssumeException ex)
            {
                Assert.Equal(message, ex.Message);
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void do_nothing_when_object_is_not_null()
        {
            object obj = new object();

            try
            {
                Assume.NotNull(obj);
            }
            catch (AssumeException)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void throw_exception_when_object_from_expression_is_null()
        {
            const object obj = null;

            try
            {
                Assume.NotNull(() => obj);
            }
            catch (AssumeException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_exception_when_object_from_expression_is_null_with_specific_message()
        {
            const object obj = null;
            const string message = "my_message";

            try
            {
                Assume.NotNull(() => obj, message);
            }
            catch (AssumeException ex)
            {
                Assert.Equal(message, ex.Message);
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void do_nothing_when_object_from_expression_is_not_null()
        {
            object obj = new object();

            try
            {
                Assume.NotNull(() => obj);
            }
            catch (AssumeException)
            {
                Assert.True(false);
            }
        }
    }
}
