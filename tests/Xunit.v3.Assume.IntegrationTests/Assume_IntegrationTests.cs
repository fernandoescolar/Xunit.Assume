namespace Xunit.AssumeIntegrationTests
{
    /// <summary>
    /// Skipped tests mean it works
    /// </summary>
    public class Assume_IntegrationTests
    {
        [Fact(SkipExceptions = [typeof(AssumptionFailedException)])]
        public void That_FalseIsNotTrue()
        {
            Assume.That(false, "That false is not true");
        }

        [Fact(SkipExceptions = [typeof(AssumptionFailedException)])]
        public void True_IsNotFalse()
        {
            Assume.True(false, "True is not false");
        }

        [Fact(SkipExceptions = [typeof(AssumptionFailedException)])]
        public void Assume_ThatTrueIsTrue()
        {
            Assume.False(true, "False is not true");
        }

        [Fact(SkipExceptions = [typeof(AssumptionFailedException)])]
        public void Null_IsNotNotNull()
        {
            Assume.Null(new object(), "Null is not not null");
        }
    }
}