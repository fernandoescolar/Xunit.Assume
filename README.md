# xUnit.Assume

In unit tesing the 3-As (Arrange-Act-Assert or "AAA") is pattern for arranging and formatting code in unit test methods. It is defined as each method should group these functional sections separated by blank lines:

```csharp
[Fact]
public void AAA_Test()
{
    // Arrange
    var expected = new Result();
    var collaborator = new TestDouble();
    var target = new TargetObject(collaborator);

    // Act
    var actual = target.DoSomeStuff();

    // Assert
    Assert.Equal(expected, actual);
}
```

Ideally, the developer writing a test has control of all of the forces that might cause a test to fail. However, sometimes this is not desirable or possible. For example, if a test fails when run in a different locale than the developer intended, it can be fixed by explicitly passing a locale to the domain code. But if this isn't immediately possible, making dependencies explicit can often improve a design. 

Keeping this in mind, the best way is to use an extension on the 3-As pattern called "AAAA" or Arrange-Assume-Act-Assert pattern. Where:

- **Arrange** the execution context in its initial configuration. Create any test doubles you may need. Initialize artifacts.

- **Assume** that the initial state is correct. Because some tests have no sense with some expected conditions.

- **Act** on the object or method under testing.

- **Assert** that the expected results have occurred.

```csharp
[Fact]
public void AAAA_Test()
{
    // Arrange
    var expected = new Result();
    var collaborator = new TestDouble();
    var target = new TargetObject(collaborator);

    // Assume
    Assume.That(target.MakeSenseToTest(), "I'm actually not going to test it");

    // Act
    var actual = target.DoSomeStuff();

    // Assert
    Assert.Equal(expected, actual);
}
```

If you don't fulfill an `Assume` what you mean is this test should be skipped because it makes no sense to test it.

So `xUnit.Assume` extends the original `xUnit` open source library to help us following this pattern.

## Using xUnit.Assume

You can install `xUnit.Assume` using NuGet in dotnet core:

```bash
dotnet add package xUnit.Assume
```

It will add some new artifacts to help you testing:

- `Assume` is an static class to use assume clausules.
- `AssumeFact` is an attribute to substitute the original `Fact` attribute, to take care of assume conditions.
- `AssumeTheory` is an attribute to substitute the original `Theory` attribute, to take care of assume conditions.

If you want assume that the current state is correct, using the artifacts above you can skip a `xUnit` by giving a meaning or reason to it:

```csharp
[AssumeFact]
public void AssumeFactTest()
{
    // Arrange
    var some_var = 1;
    
    // Assume
    Assume.That(some_var >= 0, "some_var should be a natural number");

    // Act

    // Assert
}
```

In this code, if the `Assume` condition is not fulfilled, the test will be skipped.

You can use assume with `AssumeTheory` decorators:

```csharp
[AssumeTheory]
[InlineData(-1)]
[InlineData(0)]
[InlineData(1)]
public void AssumeFactTest(int some_var)
{
    // Arrange

    // Assume
    Assume.That(some_var >= 0, "some_var should be a natural number");

    // Act

    // Assert
}
```

## Assume

The static artifact `Assume` has the contract bellow:

```csharp
class Assume
{
    void Empty(string str, string message = null);
    void Empty(Func<string> getter, string message = null);

    void Equals<T>(T expected, T target, string message = null);
    
    void False(bool condition, string message = null);
    void False(Func<bool> condition, string message = null);
    
    void NotEmpty(string str, string message = null);
    void NotEmpty(Func<string> getter, string message = null);
    
    void NotEquals<T>(T expected, T target, string message = null);
    
    void NotNull<T>(T obj, string message = null);
    void NotNull<T>(Func<T> getter, string message = null);
    
    void That(bool condition, string message = null);
    void That(Func<bool> condition, string message = null);
    
    void True(bool condition, string message = null);
    void True(Func<bool> condition, string message = null);
}
```

## Examples

### Windows only

With dotnet core, your tests could be runned in any platform. Maybe your test is only ready for Windows platforms. You can use `Assume` to skip this test when the current execution platform is not the expected one:

```csharp
[AssumeFact]
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
```

You can see full impementation of this example [here](https://github.com/fernandoescolar/Xunit.Assume/blob/master/tests/Xunit.Assume.Tests/Demos/OSDemoTests.cs).

### Bug fixing

You can use `Assume` to skip tests that depends on a bug be fixed:

```csharp
[Fact]
[Bug("121")]
public void BugFixedChecker()
{
    // Arrange

    // Act

    // Assert
}

[AssumeFact]
public void AssumeBugsAreFixed()
{
    Assume.True(BugIsFixed("121"), "Bug #121 has not been fixed yet");

    // Arrange
    
    // Act
    
    // Assert
}
```

You can see full impementation of this example [here](https://github.com/fernandoescolar/Xunit.Assume/blob/master/tests/Xunit.Assume.Tests/Demos/BugsDemoTests.cs).

### Context value

In this utopian test case we can find an artifact we want to test called `Target`. This artifact has two methods: `CanExecute` and `Execute`. In our imaginary system, when you are going to use `Target` you will call `CanExecute` always before. And if the return value is `true` then you will call `Execute`:

```csharp
interface IContext
{
    T GetItem<T>();
}

enum States
{
    Unknown,
    Unactive,
    Active
}

class Target 
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
```

Going deep in to the code you can determine when the `state` stored in the context is `Active`,  `CanExecute` method will return `false`, and `true` otherwise. So you can test the `Execute` method excluding the case when `state` is `Active`, but it wont provide information about what really happens with this particular case.

For this case you may want to explicitly notify other developers about this special behavior. To achieve this you can use `Assume` to skip the test when `state` is `Active`: 

```csharp
[AssumeTheory]
[MemberData(nameof(GetAllStatesValues))]
public void Target_Execute(States initialState)
{
    // Arrange
    var expected = 0;
    var target = new Target(new FakeContext(initialState));

    // Assume
    Assume.NotEquals(initialState, States.Active, "Can execute only in not Active state");

    // Act
    var actual = target.Execute();

    // Assert
    Assert.Equal(expected, actual);
}
```

You can see full impementation of this example [here](https://github.com/fernandoescolar/Xunit.Assume/blob/master/tests/Xunit.Assume.Tests/Demos/ContextDemoTests.cs).