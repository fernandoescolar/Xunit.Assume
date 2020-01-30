using System.Collections.Generic;
using Xunit.Abstractions;

namespace Xunit.Sdk
{
    public class AssumeTheoryDiscoverer : IXunitTestCaseDiscoverer
    {
        private readonly IMessageSink _diagnosticMessageSink;
        private readonly TheoryDiscoverer _theoryDiscoverer;

        public AssumeTheoryDiscoverer(IMessageSink diagnosticMessageSink)
        {
            _diagnosticMessageSink = diagnosticMessageSink;
            _theoryDiscoverer = new TheoryDiscoverer(diagnosticMessageSink);
        }

        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            var defaultMethodDisplay = discoveryOptions.MethodDisplayOrDefault();
            var defaultMethodDisplayOptions = discoveryOptions.MethodDisplayOptionsOrDefault();

            var basis = _theoryDiscoverer.Discover(discoveryOptions, testMethod, factAttribute);
            foreach (var testCase in basis)
            {
                if (testCase is XunitTheoryTestCase)
                {
                    yield return new AssumeTheoryTestCase(_diagnosticMessageSink, defaultMethodDisplay, defaultMethodDisplayOptions, testCase.TestMethod);
                }
                else
                {
                    yield return new AssumeFactTestCase(_diagnosticMessageSink, defaultMethodDisplay, defaultMethodDisplayOptions, testCase.TestMethod, testCase.TestMethodArguments);
                }
            }
        }
    }
}

