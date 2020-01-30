using System;

namespace Xunit.Sdk
{
    internal class AssumeException : Exception
    {
        public AssumeException(string message) : base(message)
        {
        }
    }
}
