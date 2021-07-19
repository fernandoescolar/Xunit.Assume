using System;
using Xunit.Sdk;

namespace Xunit
{
    /// <inheritdoc cref="TheoryAttribute" />
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    [XunitTestCaseDiscoverer("Xunit.Sdk.AssumeTheoryDiscoverer", "Xunit.Assume")]
    public class AssumeTheoryAttribute : TheoryAttribute
    {
        public AssumeTheoryAttribute()
        {
        }
    }
}
