namespace Xunit.Tests.NotNull
{
    public abstract class Base : TestBase
    {
        private const string AnyExceptionMessage = "my_message";
        private static readonly object NotNullObject = new object();

        [Fact]
        public void throw_exception_when_object_is_null()
            => AssertThrowAssumptionException(() => Act());

        [Fact]
        public void throw_exception_when_object_is_null_with_specific_message()
            => AssertThrowAssumptionExceptionWithMessage(() => Act(null, AnyExceptionMessage), AnyExceptionMessage);

        [Fact]
        public void do_nothing_when_object_is_not_null()
            => AssertAssumptionExceptionNotThrown(() => Act(NotNullObject));

        [Fact]
        public void return_the_same_object_value_when_it_is_not_null()
            => Assert.Equal(NotNullObject, Act(NotNullObject));

        protected abstract object Act(object? input = null, string? message = null);
    }
}
