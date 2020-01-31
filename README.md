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

But maybe a developer can find a situation where testing a particular context state makes no sense. To solve this, the best way is to use an extension on the 3-As pattern calld "AAAA" or Arrange-Assume-Act-Assert pattern. Where:

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
- `AssumeFact` is an attribute to substitute the original `Fact` attribute, to take care os assume conditions.
- `AssumeTheory` is an attribute to substitute the original `Theory` attribute, to take care os assume conditions.

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

I can use assume with `AssumeTheory` decorators:

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

## Almost real world case

In this utopian test case we can find an artifact we want to test called `Target`. This artifact has two methods: `CanExecute` and `Execute`. In our imaginary system, always I'm going to use `Target` I will call `CanExecute` first. And if the return value is `true` then I will call `Execute`:

```csharp
enum States
{
    Unknown,
    Unactive,
    Active
}

class Target 
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
```

Going deep in to the code you can determine when the `state` used is `Active`,  `CanExecute` method will return `false`, and `true` otherwise. So I can test the `Execute` method excluding the case when `state` is `Active`, but it wont provide information about what really happens with this particular case.

For this case you may want to explicitly notify other developers about this special behavior. To achieve this you can use `Assume` to skip the test when `state` is `Active`: 

```csharp
class Test
{
    [AssumeTheory]
    [MemberData(nameof(GetAllStatesValues))]
    public void Target_Execute(States initialState)
    {
        // Arrange
        var expected = 0;
        var target = new Target();

        // Assume
        Assume.NotEquals(initialState, States.Active, "CanExecute returns true only with non Active states");

        // Act
        var actual = target.Execute(initialState);

        // Assert
        Assert.Equal(expected, actual);
    }
}
```

You can see full impementation of this example [here](https://github.com/fernandoescolar/Xunit.Assume/blob/master/tests/Xunit.Assume.Tests/DemoTests.cs).