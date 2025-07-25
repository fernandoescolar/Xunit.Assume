using System.Runtime.CompilerServices;

namespace Xunit.Tests.Empty
{
    public abstract class Base : TestBase
    {
        private const string NotEmptyString = "some_content";
        private const string AnyExceptionMessage = "my_message";

        [Fact]
        public void throw_exception_when_string_is_not_empty()
            => AssertThrowAssumptionException(() => Act(NotEmptyString));

        [Fact]
        public void throw_exception_when_string_is_not_empty_with_specific_message()
        {
            string expectedMessage = GetExpectedErrorMessage(AnyExceptionMessage);
            AssertThrowAssumptionExceptionWithMessage(() => {
                Act(NotEmptyString, AnyExceptionMessage);
            }, expectedMessage);
        }

        [Fact]
        public void do_nothing_when_string_is_empty()
            => AssertAssumptionExceptionNotThrown(() => Act(string.Empty));

        [Fact]
        public void return_an_empty_string_value_when_it_is_empty()
            => Assert.Equal(string.Empty, Act(string.Empty));

        protected abstract string? Act(string input, string? message = null);

        protected abstract string GetExpectedErrorMessage(string? message);

        protected static string GetCurrentFilePath([CallerFilePath] string filePath = "")
        {
            return filePath;
        }
    }
}
