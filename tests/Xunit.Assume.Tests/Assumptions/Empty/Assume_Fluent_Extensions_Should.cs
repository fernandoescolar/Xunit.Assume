using System;

namespace Xunit.Tests.Empty
{
    public class Assume_Fluent_Extensions_Should : Base
    {
        protected override string Act(string input, string? message = null)
        {
            input = input ?? throw new ArgumentNullException(nameof(input), "Invalid test");

            if (string.IsNullOrEmpty(message))
                return input.Assume().Empty()!;

            return input.Assume().Empty(message)!;
        }

        protected override string GetExpectedErrorMessage(string? message)
        {
            string filePath = GetCurrentFilePath();
            int lineNumber = string.IsNullOrEmpty(message) ? 12 : 14;
            string expectedMessage = $"{message} (called from {System.IO.Path.GetFileName(filePath)}:{lineNumber})";
            return expectedMessage;
        }
    }
}