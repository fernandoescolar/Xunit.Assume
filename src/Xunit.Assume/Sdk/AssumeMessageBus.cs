using System;
using System.Linq;
using Xunit.Abstractions;

namespace Xunit.Sdk
{
    internal class AssumeMessageBus : IMessageBus
    {
        private readonly IMessageBus _inner;

        internal AssumeMessageBus(IMessageBus inner)
        {
            _inner = inner;
        }

        internal int Counter { get; private set; }

        public void Dispose()
        {
            _inner.Dispose();
        }

        public bool QueueMessage(IMessageSinkMessage message)
        {
            var testFailed = message as TestFailed;
            if (testFailed != null)
            {
                var exceptionType = testFailed.ExceptionTypes.FirstOrDefault();
                if (ShoulSkip(exceptionType))
                {
                    var reason = testFailed.Messages.FirstOrDefault();
                    Counter++;
                    return _inner.QueueMessage(new TestSkipped(testFailed.Test, reason));
                }
            }

            return _inner.QueueMessage(message);
        }

        private bool ShoulSkip(string exceptionType)
        {
            return exceptionType.Equals(typeof(AssumeException).FullName, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}

