# Xunit.Assume

In unit tesing the 3-As (or Arrange-Act-Assert) pattern for arranging and formatting code in UnitTest methods, is defined as each method should group these functional sections, separated by blank lines:
- Arrange all necessary preconditions and inputs.
- Act on the object or method under test.
- Assert that the expected results have occurred.

But the syntax some people most commonly use ressembles an Arrange, Assume, Act and Assert (AAAA) pattern.

- **Arrange** the system in it's initial configuration. Create any collaborators and mocks you may need. Initialize artifacts.

- **Assume** that the initial state is correct. Because some tests have no sense with some initial conditions.

- **Act** on the system by invoking artifacts.

- **Assert** that the system is in it's expected state.

## Using Xunit.Assume

If I want assume that the current state is correct, with `Xunit.Assume` I can skip a `Xunit` test I don't expected:

```csharp
[AssumeFact]
public void AssumeFactTest()
{
    var some_var = 1;
    // Arrange

    Assume.That(some_var >= 0, "skip this test");

    // Act

    // Assert
}
```

In this code, if the `Assume` condition is not fulfilled, the test will be skipped.

I can use assume with `Theory` decorators:

```csharp
[AssumeTheory]
[InlineData(-1)]
[InlineData(0)]
[InlineData(1)]
public void AssumeFactTest(int some_var)
{
    // Arrange

    Assume.That(some_var >= 0, "skip this test");

    // Act

    // Assert
}
```
