namespace Xunit.Tests.False
{
    public abstract class Base : TestBase
    {
        private const bool Success = true;
        private const bool Failure = false;
        private const string AnyExceptionMessage = "my_message";


        [Fact]
        public void throw_exception_when_condition_is_fulfilled()
            => AssertThrowAssumeException(() => Act(Success));

        [Fact]
        public void throw_exception_when_condition_is_fulfilled_with_specific_message()
            => AssertThrowAssumeExceptionWithMessage(() => Act(Success, AnyExceptionMessage), AnyExceptionMessage);

        [Fact]
        public void do_nothing_when_condition_is_not_fulfilled()
            => AssertAssumeExceptionNotThrown(() => Act(Failure));

        [Fact]
        public void return_true_when_condition_is_not_fulfilled()
            => Assert.True(Act(Failure));

        protected abstract bool Act(bool condition, string message = null);
    }
}
