#:sdk MSTest.Sdk@4.5.2

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static StudentSolution;

public static class StudentSolution
{
    public static double CalculateLicenseCost(int userCount, bool isNonProfit)
    {
        return -99;
    }

    public static bool IsStrictlyIncreasing(List<int> values)
    {
        return false;
    }

    public static Dictionary<string, int> CountWordFrequencies(List<string> words)
    {
        return new Dictionary<string, int>
        {
            ["cloud"] = 3,
            ["net"] = 1
        };
    }
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

        Assert.AreEqual(3, result["cloud"],
            "Regola: 'Cloud', 'cloud' e 'CLOUD' devono essere conteggiati insieme sotto la chiave minuscola 'cloud'.");
    }
}
