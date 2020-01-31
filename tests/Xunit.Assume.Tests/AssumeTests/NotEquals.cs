﻿using Xunit.Sdk;

namespace Xunit.Tests.AssumeTests
{
    public class NotEquals_Should
    {
        private readonly object ObjectA = new object();
        private readonly object ObjectB = new object();

        [Fact]
        public void throw_exception_when_objects_are_equal()
        {
            try
            {
                Assume.NotEquals(ObjectA, ObjectA);
            }
            catch (AssumeException)
            {
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void throw_exception_when_objects_are_equal_with_specific_message()
        {
            const string message = "my_message";

            try
            {
                Assume.NotEquals(ObjectA, ObjectA, message);
            }
            catch (AssumeException ex)
            {
                Assert.Equal(message, ex.Message);
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public void do_nothing_when_objects_are_not_equal()
        {
            try
            {
                Assume.NotEquals(ObjectA, ObjectB);
            }
            catch (AssumeException)
            {
                Assert.True(false);
            }
        }
    }
}
