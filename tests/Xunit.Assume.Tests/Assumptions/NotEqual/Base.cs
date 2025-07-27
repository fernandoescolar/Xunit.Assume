namespace Xunit.Tests.NotEqual
{
    public abstract class Base : TestBase
    {
        private const string AnyExceptionMessage = "my_message";
        private readonly object ObjectA = new object();
        private readonly object ObjectB = new object();

        [Fact]
        public void throw_exception_when_objects_are_equal()
            => AssertThrowAssumptionException(() => Act(ObjectA, ObjectA));

        [Fact]
        public void throw_exception_when_objects_are_equal_with_specific_message()
            => AssertThrowAssumptionExceptionWithMessage(() => Act(ObjectA, ObjectA, AnyExceptionMessage), AnyExceptionMessage);

        [Fact]
        public void do_nothing_when_objects_are_not_equal()
            => AssertAssumptionExceptionNotThrown(() => Act(ObjectA, ObjectB));

        [Fact]
        public void return_true_when_objects_are_not_equal()
            => Assert.True(Act(ObjectA, ObjectB));

        protected abstract bool Act(object objA, object objB, string? message = null);
    }
}
