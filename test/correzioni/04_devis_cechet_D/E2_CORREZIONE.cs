#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 04 — CECHET DEVIS — Traccia D — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/d.cs.
// Fonte: test/consegne/d/cechet_devis_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static int SumOddIndexElements(List<int> numbers)
    {
        var sum = 0;

        for (int i = 0; i < numbers.Count; i++)
        {
            if (i % 2 != 0)
            {
                sum += numbers[i];
            }
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
// Fonte: test/consegne/d/cechet_devis_clod_test_2026.cs
//ESERCIZIO 1 - Categorizzazione Eventi di Sistema

string CategorizeEventCode(int eventCode)
{
    if (eventCode <= 0)
    {
        return "INVALID";
    }

    if (eventCode % 4 == 0 && eventCode % 6 == 0)
    {
        return "CRITICAL_SYS_APP";
    } else if (eventCode % 4 == 0 && eventCode % 6 != 0)
    {
        return "SYS";
    } else if (eventCode % 6 == 0 && eventCode % 4 != 0)
    {
        return "APP";
    }

    return eventCode.ToString();
}

//ESERCIZIO 2 - Somma Elementi di Indice Dispari

int SumOddIndexElements(List<int> numbers)
{
    var sum = 0;

    for (int i = 0; i < numbers.Count; i++)
    {
        if (i % 2 != 0)
        {
            sum += numbers[i];
        }
    }

    return sum;
}

//ESERCIZIO 3 - Verifica Permessi API Key

bool ValidateApiKeyAccess(Dictionary<string, string> apiKeyMap, string apiKey, string requiredRole)
{
    foreach (var element in apiKeyMap)
    {
        if (element.Key == apiKey)
        {
            if (element.Value == requiredRole)
            {
                return true;
            }
        }
    }

    return false;
}
#endif
