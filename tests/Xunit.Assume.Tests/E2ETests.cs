namespace Xunit.Tests
{
    public class E2ETests
    {
        private const string SkipMessage = "Assumption not fulfilled";

        [Theory(SkipExceptions = [typeof(AssumptionFailedException)])]
        [InlineData(SkipMessage)]
        public static void AssumeTheory_should_be_skipped_when_assumption_is_not_fulfilled(string message)
        {
            Assume.False(true, message);
        }

        [Theory()]
        [InlineData(SkipMessage)]
        public static void AssumeTheory_should_not_be_skipped_when_assumption_is_fulfilled(string message)
        {
            Assume.False(false, message);
        }

        [Fact(SkipExceptions = [typeof(AssumptionFailedException)])]
        public static void AssumeFact_should_be_skipped_when_assumption_is_not_fulfilled()
        {
            Assume.False(true, SkipMessage);
        }

        [Fact]
        public static void AssumeFact_should_not_be_skipped_when_assumption_is_fulfilled()
        {
            Assume.False(false, SkipMessage);
        }
    }
}
