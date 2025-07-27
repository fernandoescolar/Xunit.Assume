namespace Xunit.Tests.NotEmpty
{
    public abstract class Base : TestBase
    {
        private const string NotEmptyString = "some_content";
        private const string AnyExceptionMessage = "my_message";

        [Fact]
        public void throw_exception_when_string_is_empty()
            => AssertThrowAssumptionException(() => Act(string.Empty));

        [Fact]
        public void throw_exception_when_string_is_empty_with_specific_message()
            => AssertThrowAssumptionExceptionWithMessage(() => Act(string.Empty, AnyExceptionMessage), AnyExceptionMessage);

        [Fact]
        public void do_nothing_when_string_is_not_empty()
            => AssertAssumptionExceptionNotThrown(() => Act(NotEmptyString));

        [Fact]
        public void return_the_same_string_value_when_it_is_not_empty()
            => Assert.Equal(NotEmptyString, Act(NotEmptyString));

        protected abstract string Act(string input, string? message = null);
    }
}
