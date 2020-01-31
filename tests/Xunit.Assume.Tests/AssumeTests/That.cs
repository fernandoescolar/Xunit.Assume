using Xunit.Sdk;

namespace Xunit.Tests.AssumeTests
{
    public class That_Should
    {
        [Fact]
        public void throw_exception_when_condition_is_not_fulfilled()
        {
            const bool condition = false;

            try
            {
                Assume.That(condition);
            }
            catch (AssumeException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_exception_when_condition_is_not_fulfilled_with_specific_message()
        {
            const bool condition = false;
            const string message = "my_message";

            try
            {
                Assume.That(condition, message);
            }
            catch (AssumeException ex)
            {
                Assert.Equal(message, ex.Message);
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void do_nothing_when_condition_is_fulfilled()
        {
            const bool condition = true;

            try
            {
                Assume.That(condition);
            }
            catch (AssumeException)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void throw_exception_when_condition_expression_is_not_fulfilled()
        {
            const bool condition = false;

            try
            {
                Assume.That(() => condition);
            }
            catch (AssumeException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_exception_when_condition_expression_is_not_fulfilled_with_specific_message()
        {
            const bool condition = false;
            const string message = "my_message";

            try
            {
                Assume.That(() => condition, message);
            }
            catch (AssumeException ex)
            {
                Assert.Equal(message, ex.Message);
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void do_nothing_when_condition_expression_is_fulfilled()
        {
            const bool condition = true;

            try
            {
                Assume.That(() => condition);
            }
            catch (AssumeException)
            {
                Assert.True(false);
            }
        }
    }
}
