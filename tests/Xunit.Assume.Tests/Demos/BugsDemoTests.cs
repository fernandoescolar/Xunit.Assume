using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xunit.Tests
{
    public class BugsDemoTests
    {
        [Fact]
        [Bug("121")]
        public void BugFixedChecker()
        {
            // Arrange

            // Act

            // Assert
        }

        public void AssumeBugsAreFixed()
        {
            Assume.True(BugIsFixed("121"), "Bug #121 has not been fixed yet");

            // Arrange

            // Act

            // Assert
        }

        static bool BugIsFixed(string id)
        {
            return AllBugs().Any(x => x.Equals(id, StringComparison.InvariantCultureIgnoreCase));
        }

        static IEnumerable<string> AllBugs()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly
                        .GetTypes()
                        .SelectMany(x => x.GetMethods())
                        .SelectMany(m => m.GetCustomAttributes<BugAttribute>())
                        .Where(a => a != null && !string.IsNullOrEmpty(a.Id))
                        .Select(a => a.Id);
        }

        class BugAttribute : Attribute
        {
            public BugAttribute(string bugId)
            {
                Id = bugId;
            }

            public string Id { get; set; }
        }
    }
}