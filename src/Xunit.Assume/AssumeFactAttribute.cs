using System;
using Xunit.Sdk;

namespace Xunit
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    [XunitTestCaseDiscoverer("Xunit.Sdk.AssumeFactDiscoverer", "Xunit.Assume")]
    public class AssumeFactAttribute : FactAttribute
    {
        public AssumeFactAttribute()
        {
        }
    }
}
