namespace Xunit.Tests.Null
{
    public abstract class Base : TestBase
    {
        private const string AnyExceptionMessage = "my_message";
        private static readonly object NotNullObject = new object();

        [Fact]
        public void throw_exception_when_object_is_not_null()
            => AssertThrowAssumeException(() => Act(NotNullObject));

        [Fact]
        public void throw_exception_when_object_is_not_null_with_specific_message()
            => AssertThrowAssumeExceptionWithMessage(() => Act(NotNullObject, AnyExceptionMessage), AnyExceptionMessage);

        [Fact]
        public void do_nothing_when_object_is_null()
            => AssertAssumeExceptionNotThrown(() => Act(null));

        [Fact]
        public void return_the_same_object_value_when_it_is_null()
            => Assert.Null(Act(null));

        protected abstract object Act(object input, string message = null);
    }
}
