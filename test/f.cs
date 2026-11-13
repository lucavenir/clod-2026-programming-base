#:sdk MSTest.Sdk@4.5.2

using static F_CILUFFO;

public static class F_CILUFFO
{

}
public static class F_LACCHIN
{

}
public static class F_NOGARÈ
{

}
public static class F_TEGON
{

}

[TestClass]
public class TrackFTests
{
    [TestMethod]
    public void Should_ReturnZero_When_UserCountIsZeroOrNegative()
    {
        Assert.AreEqual(0.0, CalculateLicenseCost(0, false), 0.001,
            "Regola: 0 utenti costano 0€.");
    }

    [TestMethod]
    public void Should_Charge10PerUser_UpTo10Users()
    {
        Assert.AreEqual(100.0, CalculateLicenseCost(10, false), 0.001,
            "Regola: 10 utenti * 10€ = 100€.");
    }

    [TestMethod]
    public void Should_Charge8PerUser_Between11And50Users()
    {
        Assert.AreEqual(140.0, CalculateLicenseCost(15, false), 0.001,
            "Regola: 15 utenti = 100€ (primi 10) + 40€ (5 utenti * 8€).");
    }

    [TestMethod]
    public void Should_Apply50PercentDiscount_When_IsNonProfit()
    {
        Assert.AreEqual(70.0, CalculateLicenseCost(15, true), 0.001,
            "Regola: 140€ scontati del 50% diventano 70€.");
    }

    [TestMethod]
    public void Should_ReturnTrue_When_SequenceIsStrictlyIncreasing()
    {
        Assert.IsTrue(IsStrictlyIncreasing([1, 3, 5, 10]),
            "Regola: ogni elemento è maggiore del precedente.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_AdjacentElementsAreEqual()
    {
        Assert.IsFalse(IsStrictlyIncreasing([1, 3, 3, 5]),
            "Regola: 3 == 3 non è 'STRETTAMENTE' crescente.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_SequenceDecreases()
    {
        Assert.IsFalse(IsStrictlyIncreasing([5, 2, 8]),
            "Regola: un calo rende la sequenza non crescente.");
    }

    [TestMethod]
    public void Should_CountFrequencies_CaseInsensitively()
    {
        var result = CountWordFrequencies(["Cloud", "cloud", "NET", "CLOUD"]);

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(3, result["cloud"]);
        Assert.AreEqual(1, result["net"]);
        CollectionAssert.AreEquivalent(new List<string> { "cloud", "net" }, new List<string>(result.Keys));
    }


    [TestMethod]
    public void Should_CalculateLicense_When_Negative()
    {
        Assert.AreEqual(0.0, CalculateLicenseCost(-1, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_NegativeWithDiscount()
    {
        Assert.AreEqual(0.0, CalculateLicenseCost(-1, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_ZeroWithDiscount()
    {
        Assert.AreEqual(0.0, CalculateLicenseCost(0, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_OneUser()
    {
        Assert.AreEqual(10.0, CalculateLicenseCost(1, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_ElevenUsers()
    {
        Assert.AreEqual(108.0, CalculateLicenseCost(11, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_FiftyUsers()
    {
        Assert.AreEqual(420.0, CalculateLicenseCost(50, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_FiftyOneUsers()
    {
        Assert.AreEqual(425.0, CalculateLicenseCost(51, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_ManyUsers()
    {
        Assert.AreEqual(470.0, CalculateLicenseCost(60, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_DiscountBelowTen()
    {
        Assert.AreEqual(25.0, CalculateLicenseCost(5, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_DiscountAboveFifty()
    {
        Assert.AreEqual(212.5, CalculateLicenseCost(51, true), 0.001);
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_Empty()
    {
        Assert.AreEqual(true, IsStrictlyIncreasing([]));
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_Single()
    {
        Assert.AreEqual(true, IsStrictlyIncreasing([5]));
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_TwoIncreasing()
    {
        Assert.AreEqual(true, IsStrictlyIncreasing([1, 2]));
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_TwoEqual()
    {
        Assert.AreEqual(false, IsStrictlyIncreasing([3, 3]));
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_TwoDecreasing()
    {
        Assert.AreEqual(false, IsStrictlyIncreasing([5, 2]));
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_OnlyLastPairDecreases()
    {
        Assert.AreEqual(false, IsStrictlyIncreasing([1, 3, 2]));
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_OnlyLastPairIsEqual()
    {
        Assert.AreEqual(false, IsStrictlyIncreasing([1, 2, 2]));
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_IncludesNegativeValues()
    {
        Assert.AreEqual(true, IsStrictlyIncreasing([-5, -2, 0, 3]));
    }

    [TestMethod]
    public void Should_CountEveryWord_When_EmptyList()
    {
        var result = CountWordFrequencies([]);
        Assert.AreEqual(0, result.Count);
        CollectionAssert.AreEquivalent(new List<string> {  }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountEveryWord_When_SingleWord()
    {
        var result = CountWordFrequencies(["Cloud"]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(1, result["cloud"]);
        CollectionAssert.AreEquivalent(new List<string> { "cloud" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountEveryWord_When_AllWordsDiffer()
    {
        var result = CountWordFrequencies(["Cat", "DOG", "bird"]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(1, result["cat"]);
        Assert.AreEqual(1, result["dog"]);
        Assert.AreEqual(1, result["bird"]);
        CollectionAssert.AreEquivalent(new List<string> { "cat", "dog", "bird" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountEveryWord_When_RepeatedWord()
    {
        var result = CountWordFrequencies(["Net", "NET", "net"]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(3, result["net"]);
        CollectionAssert.AreEquivalent(new List<string> { "net" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountEveryWord_When_DifferentFrequencies()
    {
        var result = CountWordFrequencies(["A", "b", "a", "C", "B", "c", "C"]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(2, result["a"]);
        Assert.AreEqual(2, result["b"]);
        Assert.AreEqual(3, result["c"]);
        CollectionAssert.AreEquivalent(new List<string> { "a", "b", "c" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountEveryWord_When_EmptyWord()
    {
        var result = CountWordFrequencies(["", "Cloud", ""]);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(2, result[""]);
        Assert.AreEqual(1, result["cloud"]);
        CollectionAssert.AreEquivalent(new List<string> { "", "cloud" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountEveryWord_When_SpacesInsideWords()
    {
        var result = CountWordFrequencies(["Hello World", "HELLO WORLD", "Hello"]);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(2, result["hello world"]);
        Assert.AreEqual(1, result["hello"]);
        CollectionAssert.AreEquivalent(new List<string> { "hello world", "hello" }, new List<string>(result.Keys));
    }
}
