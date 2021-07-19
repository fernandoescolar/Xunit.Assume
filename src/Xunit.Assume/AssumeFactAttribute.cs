using System;
using Xunit.Sdk;

namespace Xunit
{
    /// <inheritdoc cref="FactAttribute" />
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    [XunitTestCaseDiscoverer("Xunit.Sdk.AssumeFactDiscoverer", "Xunit.Assume")]
    public class AssumeFactAttribute : FactAttribute
    {
        public AssumeFactAttribute()
        {
        }
    }
}
