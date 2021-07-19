namespace Xunit.Tests
{
    public class IssueTests
    {
        private const string NotNullString = "not null";

        [AssumeFact]
        public void IssueTest()
        {
            var expected = NotNullString;
            var value1 = CouldBeNull() ?? Assume.Reject<string>("Can not be null");
            var value2 = Assume.NotNull(CouldBeNull(), "Can not be null");
            var value3 = CouldBeNull().AssumeNotNull("Can not be null");
            var value4 = CouldBeNull().Assume()
                                    .NotNull("Can not be null");

            Assert.Equal(expected, value1);
            Assert.Equal(expected, value2);
            Assert.Equal(expected, value3);
            Assert.Equal(expected, value4);
        }

        private static string CouldBeNull() => NotNullString;
    }
}
