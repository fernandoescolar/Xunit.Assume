using System.Runtime.InteropServices;

namespace Xunit.Tests
{
    public class OSDemoTests
    {
        public void AssumeWindows()
        {
            // Arrange
            
            // Assume
            Assume.True(IsWindows(), "This OS is not supported");

            // Act

            // Assert
        }

        private static bool IsWindows()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        }
    }
}