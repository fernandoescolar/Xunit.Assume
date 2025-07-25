namespace Xunit.Tests
{
    public class E2ETests
    {
        private const string SkipMessage = "Assumption not fulfilled";

        [InlineData(SkipMessage)]
        public void AssumeTheory_should_be_skipped_when_assumption_is_not_fulfilled(string message)
        {
            Assume.False(true, message);
        }

        [InlineData(SkipMessage)]
        public void AssumeTheory_should_not_be_skipped_when_assumption_is_fulfilled(string message)
        {
            Assume.False(false, message);
        }

        public void AssumeFact_should_be_skipped_when_assumption_is_not_fulfilled()
        {
            Assume.False(true, SkipMessage);
        }

        public void AssumeFact_should_not_be_skipped_when_assumption_is_fulfilled()
        {
            Assume.False(false, SkipMessage);
        }
    }
}
