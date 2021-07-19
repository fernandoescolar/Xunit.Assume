namespace Xunit.Tests.That
{
    public abstract class Base : TestBase
    {
        private const bool Success = true;
        private const bool Failure = false;
        private const string AnyExceptionMessage = "my_message";


        [Fact]
        public void throw_exception_when_condition_is_not_fulfilled()
            => AssertThrowAssumeException(() => Act(Failure));

        [Fact]
        public void throw_exception_when_condition_is_not_fulfilled_with_specific_message()
            => AssertThrowAssumeExceptionWithMessage(() => Act(Failure, AnyExceptionMessage), AnyExceptionMessage);

        [Fact]
        public void do_nothing_when_condition_is_fulfilled()
            => AssertAssumeExceptionNotThrown(() => Act(Success));

        [Fact]
        public void return_true_when_condition_is_fulfilled()
            => Assert.True(Act(Success));

        protected abstract bool Act(bool condition, string message = null);
    }
}
