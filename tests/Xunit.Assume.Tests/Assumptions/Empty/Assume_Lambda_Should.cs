namespace Xunit.Tests.Empty
{
    public class Assume_Lambda_Should : Base
    {
        protected override string Act(string input, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
                return Assume.Empty(() => input);

            return Assume.Empty(() => input, message);
        }

        protected override string GetExpectedErrorMessage(string? message)
        {
            string filePath = GetCurrentFilePath();
            int lineNumber = string.IsNullOrEmpty(message) ? 8 : 10;
            string expectedMessage = $"{message} (called from {System.IO.Path.GetFileName(filePath)}:{lineNumber})";
            return expectedMessage;
        }
    }
}