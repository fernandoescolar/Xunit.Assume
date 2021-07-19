using Xunit.Sdk;

namespace Xunit
{
    /// <summary>
    /// A set of methods useful for stating assumptions about the conditions in which a test is meaningful.
    /// A rejected assumption does not mean the code is broken, but that the test provides no useful information.
    /// Assume basically means "don't run this test if these conditions don't apply".
    /// </summary>
    public static partial class Assume
    {
        private const string DefaultAssumeRejectedMessage = "Assume rule not fulfilled";

        private static AssumeException CreateAssumeException(string message = null)
            => new AssumeException(message ?? DefaultAssumeRejectedMessage);
    }
}
