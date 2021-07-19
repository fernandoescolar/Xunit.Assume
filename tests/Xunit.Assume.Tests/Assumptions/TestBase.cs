using System;
using Xunit.Sdk;

namespace Xunit.Tests
{
    public abstract class TestBase
    {
        protected void AssertThrowAssumeException(Action act)
        {
            try
            {
                act();
            }
            catch (AssumeException)
            {
                return;
            }

            throw new XunitException("Expected AssumeException has not been thrown!");
        }

        protected void AssertThrowAssumeExceptionWithMessage(Action act, string expectedMessage)
        {
            try
            {
                act();
            }
            catch (AssumeException ex)
            {
                Assert.Equal(expectedMessage, ex.Message);
                return;
            }

            throw new XunitException("Expected AssumeException has not been thrown!");
        }

        protected void AssertAssumeExceptionNotThrown(Action act)
        {
            try
            {
                act();
            }
            catch (AssumeException)
            {
                throw new XunitException("Unexpected AssumeException has been thrown!");
            }
        }
    }
}
