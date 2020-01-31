using Xunit.Sdk;

namespace Xunit.Tests.AssumeTests
{
    public class Empty_Should
    {
        private const string NotEmptyString = "some_content";

        [Fact]
        public void throw_exception_when_string_is_not_empty()
        {
            const string str = NotEmptyString;

            try
            {
                Assume.Empty(str);
            }
            catch (AssumeException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_exception_when_string_is_not_empty_with_specific_message()
        {
            const string str = NotEmptyString;
            const string message = "my_message";

            try
            {
                Assume.Empty(str, message);
            }
            catch (AssumeException ex)
            {
                Assert.Equal(message, ex.Message);
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void do_nothing_when_string_is_empty()
        {
            try
            {
                Assume.Empty(string.Empty);
            }
            catch (AssumeException)
            {
                Assert.True(false);
            }
        }


        [Fact]
        public void throw_exception_when_string_from_expression_is_not_empty()
        {
            const string str = NotEmptyString;

            try
            {
                Assume.Empty(() => str);
            }
            catch (AssumeException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_exception_when_string_from_expression_is_not_empty_with_specific_message()
        {
            const string str = NotEmptyString;
            const string message = "my_message";

            try
            {
                Assume.Empty(() => str, message);
            }
            catch (AssumeException ex)
            {
                Assert.Equal(message, ex.Message);
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void do_nothing_when_string_from_expression_is_empty()
        {
            try
            {
                Assume.NotNull(() => string.Empty);
            }
            catch (AssumeException)
            {
                Assert.True(false);
            }
        }
    }
}
