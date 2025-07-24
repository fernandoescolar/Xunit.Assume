using System;
using Xunit.Sdk;

namespace Xunit.Tests
{
    public abstract class TestBase
    {
        protected void AssertThrowAssumptionException(Action act)
        {
            try
            {
                act();
            }
            catch (AssumptionFailedException)
            {
                return;
            }

            throw new XunitException("Expected AssumeException has not been thrown!");
        }

        protected void AssertThrowAssumptionExceptionWithMessage(Action act, string expectedMessage)
        {
            try
            {
                act();
            }
            catch (AssumptionFailedException ex)
            {
                Assert.StartsWith(expectedMessage, ex.Message);
                return;
            }

            throw new XunitException("Expected AssumeException has not been thrown!");
        }

        protected void AssertAssumptionExceptionNotThrown(Action act)
        {
            try
            {
                act();
            }
            catch (AssumptionFailedException)
            {
                throw new XunitException("Unexpected AssumeException has been thrown!");
            }
        }
    }
}
