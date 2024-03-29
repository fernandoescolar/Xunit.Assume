﻿using Xunit.Sdk;

namespace Xunit.Tests.Reject
{
    public class Assume_Should
    {
        [Fact]
        public void throw_assume_exception()
        {
            try
            {
                Assume.Reject();
            }
            catch (AssumeException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_assume_exception_with_specific_message()
        {
            const string message = "my_message";

            try
            {
                Assume.Reject(message);
            }
            catch (AssumeException ex)
            {
                Assert.Equal(message, ex.Message);
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_assume_exception_with_null_pattern()
        {
            try
            {
                var null_object = (object)null;
                var s = null_object ?? Assume.Reject<string>();
            }
            catch (AssumeException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_assume_exception_with_null_pattern_with_parameter()
        {
            try
            {
                var null_object = (object)null;
                var s = null_object ?? Assume.Reject(null_object);
            }
            catch (AssumeException)
            {
                return;
            }

            Assert.True(false);
        }
    }
}
