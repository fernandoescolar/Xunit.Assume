using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
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

        private static AssumptionFailedException CreateAssumptionFailedException(string? message = null, string? callerFilePath = null, int callerLineNumber = 0)
        {
            var sb = new StringBuilder();
            if (string.IsNullOrEmpty(message))
            {
                sb.Append(DefaultAssumeRejectedMessage);
            }
            else
            {
                sb.Append(message);
            }
            if (!string.IsNullOrEmpty(callerFilePath))
            {
                var callerFileName = System.IO.Path.GetFileName(callerFilePath);
                sb.Append($" (called from {callerFileName}:{callerLineNumber})");
            }

            var formattedMessage = sb.ToString();
            var exception = new AssumptionFailedException(formattedMessage);

            return exception;
        }
    }
}
