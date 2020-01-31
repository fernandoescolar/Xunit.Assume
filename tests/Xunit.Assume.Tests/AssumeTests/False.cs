using Xunit.Sdk;

namespace Xunit.Tests.AssumeTests
{
    public class False_Should
    {
        [Fact]
        public void throw_exception_when_condition_is_fulfilled()
        {
            const bool condition = true;

            try
            {
                Assume.False(condition);
            }
            catch (AssumeException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_exception_when_condition_is_fulfilled_with_specific_message()
        {
            const bool condition = true;
            const string message = "my_message";

            try
            {
                Assume.False(condition, message);
            }
            catch (AssumeException ex)
            {
                Assert.Equal(message, ex.Message);
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void do_nothing_when_condition_is_not_fulfilled()
        {
            const bool condition = false;

            try
            {
                Assume.False(condition);
            }
            catch (AssumeException)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void throw_exception_when_condition_expression_is_fulfilled()
        {
            const bool condition = true;

            try
            {
                Assume.False(() => condition);
            }
            catch (AssumeException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_exception_when_condition_expression_is_fulfilled_with_specific_message()
        {
            const bool condition = true;
            const string message = "my_message";

            try
            {
                Assume.False(() => condition, message);
            }
            catch (AssumeException ex)
            {
                Assert.Equal(message, ex.Message);
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void do_nothing_when_condition_expression_is__not_fulfilled()
        {
            const bool condition = false;

            try
            {
                Assume.False(() => condition);
            }
            catch (AssumeException)
            {
                Assert.True(false);
            }
        }
    }
}
