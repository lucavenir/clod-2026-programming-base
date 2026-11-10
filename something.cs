#:sdk MSTest.Sdk@4.5.2

[TestClass]
public class ArithmeticTests
{
    static int Add(int a, int b) => a + b;

    [TestMethod]
    public void AddsTwoNumbers()
    {
        Assert.AreEqual(5, Add(2, 3));
    }

    [TestMethod]
    public void WorksWithNegatives()
    {
        Assert.AreEqual(0, Add(-2, 2));
    }

    [TestMethod]
    public void WorksWithZero()
    {
        Assert.AreEqual(2, Add(2, 0));
    }
}
