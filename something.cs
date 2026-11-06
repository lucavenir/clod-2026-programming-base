// This is your "main": execution starts here.
Console.WriteLine(Add(2, 3));

RunTests();

// Functions can appear below their calls.
int Add(int a, int b) => a + b;

void RunTests()
{
    AssertEqual(5, Add(2, 3));
    AssertEqual(0, Add(-2, 2));
    AssertEqual(-5, Add(-2, -3));

    Console.WriteLine("All tests passed.");
}

void AssertEqual(int expected, int actual)
{
    if (expected != actual)
        throw new Exception($"Expected {expected}, got {actual}");
}