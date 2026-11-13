#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 22 — SOLONYSHYN MAKSYM — Traccia D — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/d.cs.
// Fonte: test/consegne/d/solonshyn_maksym.cs
public static class ConsegnaStudente
{
    public static int SumOddIndexElements(List<int> numbers)
    {
        int sum = 0;
        for (int i = 1; i < numbers.Count; i += 2)
        {
            sum += numbers[i];
        }
        return sum;
    }
}

[TestClass]
public class Esercizio2Tests
{
    [TestMethod]
    public void Should_SumOnlyOddIndices()
    {
        Assert.AreEqual(60, SumOddIndexElements([10, 20, 30, 40, 50]),
            "Regola: deve sommare gli elementi agli indici 1 (20) e 3 (40).");
    }

    [TestMethod]
    public void Should_ReturnZero_When_NoOddIndicesExist()
    {
        Assert.AreEqual(0, SumOddIndexElements([100]),
            "Regola: lista con 1 solo elemento ha solo l'indice 0 (pari).");
    }

    [TestMethod]
    public void Should_ReturnZero_When_ListIsEmpty()
    {
        Assert.AreEqual(0, SumOddIndexElements([]),
            "Regola: lista vuota ha somma 0.");
    }

    [TestMethod]
    public void Should_SumOddPositions_When_TwoElements()
    {
        Assert.AreEqual(20, SumOddIndexElements([10, 20]));
    }

    [TestMethod]
    public void Should_SumOddPositions_When_EvenLength()
    {
        Assert.AreEqual(60, SumOddIndexElements([10, 20, 30, 40]));
    }

    [TestMethod]
    public void Should_SumOddPositions_When_OddValuesAtEvenIndices()
    {
        Assert.AreEqual(6, SumOddIndexElements([1, 2, 3, 4, 5]));
    }

    [TestMethod]
    public void Should_SumOddPositions_When_NegativeElements()
    {
        Assert.AreEqual(-60, SumOddIndexElements([10, -20, 30, -40]));
    }

    [TestMethod]
    public void Should_SumOddPositions_When_Zeros()
    {
        Assert.AreEqual(0, SumOddIndexElements([0, 0, 0, 0]));
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/d/solonshyn_maksym.cs
namespace FundamentsOfPrograming;

public static class test1
{
    public static string CategorizeEventCode(int eventCode)
    {
        if (eventCode <= 0) return "INVALID";
        else if (eventCode % 4 == 0)
        {
            if (eventCode % 6 == 0) return "CRITICAL_SYS_APP";
            return "SYS";
        }
        else if (eventCode % 6 == 0) return "APP";
        return eventCode.ToString();
    }

    public static int SumOddIndexElements(List<int> numbers)
    {
        int sum = 0;
        for (int i = 1; i < numbers.Count; i += 2)
        {
            sum += numbers[i];
        }
        return sum;
    }

    public static bool ValidateApiKeyAccess(Dictionary<string, string> apiKeyMap, string apiKey, string requiredRole)
    {
        return (apiKeyMap.ContainsKey(apiKey) && apiKeyMap[apiKey] == requiredRole);
    }
}
#endif
