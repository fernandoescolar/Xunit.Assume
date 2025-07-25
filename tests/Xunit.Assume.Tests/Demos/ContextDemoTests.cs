using System;
using System.Collections.Generic;
using System.Linq;

namespace Xunit.Tests
{
    public interface IContext
    {
        T GetItem<T>();
    }

    public enum States
    {
        Unknown,
        Unactive,
        Active
    }

    public class Target
    {
        private readonly IContext _context;

        public Target(IContext context)
        {
            _context = context;
        }

        public bool CanExecute()
        {
            var state = _context.GetItem<States>();;
            return state != States.Active;
        }

        public int Execute()
        {
            var state = _context.GetItem<States>();
            // do stuff
            return 0;
        }
    }

    public class Test
    {
        [MemberData(nameof(GetAllStatesValues))]
        public void Target_Execute(States initialState)
        {
            // Arrange
            var expected = 0;
            var target = new Target(new FakeContext(initialState));

            // Assume
            Assume.NotEqual(initialState, States.Active, "Can execute only in not Active state");

            // Act
            var actual = target.Execute();

            // Assert
            Assert.Equal(expected, actual);
        }

        public  static IEnumerable<object[]> GetAllStatesValues()
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

    public class FakeContext : IContext
    {
        private readonly States _states;

        public FakeContext(States states)
        {
            _states = states;
        }
        public T GetItem<T>()
        {
            return (T)((object)_states);
        }
    }
}