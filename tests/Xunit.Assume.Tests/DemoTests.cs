using System;
using System.Collections.Generic;
using System.Linq;

namespace Xunit.Tests
{
    public enum States
    {
        Unknown,
        Unactive,
        Active
    }

    public class Target 
    {
        public bool CanExecute(States state)
        {
            return state != States.Active;
        }

        public int Execute(States state)
        {
            // do stuff
            return 0;
        }
    }

    public class Test
    {
        [AssumeTheory]
        [MemberData(nameof(GetStatesValues))]
        public void Target_Execute(States initialState)
        {
            // Arrange
            var expected = 0;
            var target = new Target();

            // Assume
            Assume.NotEquals(initialState, States.Active, "Can execute only in not Active state");

            // Act
            var actual = target.Execute(initialState);

            // Assert
            Assert.Equal(expected, actual);
        }

        public  static IEnumerable<object[]> GetStatesValues()
        {
            return GetEnumValues<States>();
        }

        private static IEnumerable<object[]> GetEnumValues<T>()
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum) throw new ArgumentException(nameof(enumType));

            return Enum.GetValues(enumType)
                    .Cast<T>()
                    .Select(x => new object[] { x });
        }
    }
}