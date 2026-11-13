#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 10 — GRATTONI GABRIELE — Traccia D — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/d.cs.
// Fonte: test/consegne/d/grattoni_gabriele_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static int SumOddIndexElements(List<int> numbers)
    {
        int sum = 0;

        for (var i = 0; i < numbers.Count; i++)

            if (!(i % 2 == 0))
                sum += numbers[i];

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
// Fonte: test/consegne/d/grattoni_gabriele_clod_test_2026.cs
//es 1
System.Console.WriteLine("ES_1");
System.Console.WriteLine(CategorizeEventCode(-6)); //invalid
System.Console.WriteLine(CategorizeEventCode(12)); //CRITICAL_SYS_APP
System.Console.WriteLine(CategorizeEventCode(8));  //SYS
System.Console.WriteLine(CategorizeEventCode(18)); //APP
System.Console.WriteLine(CategorizeEventCode(7));  //"7"

//es 2
System.Console.WriteLine("\nES_2");
List<int> data = [10, 20, 30, 40, 50];
System.Console.WriteLine(SumOddIndexElements(data).ToString()); //20 + 40 = 60

//es 3
Dictionary<string, string> apiData = new();
apiData.Add("marco", "polo");
apiData.Add("quattro", "cinque");
apiData.Add("otto", "nove");

System.Console.WriteLine("\nES_3");
System.Console.WriteLine(ValidateApiKeyAccess(apiData, "gabriele", "grattoni")); //false, false => false
System.Console.WriteLine(ValidateApiKeyAccess(apiData, "marco", "pala")); //true, false => false
System.Console.WriteLine(ValidateApiKeyAccess(apiData, "quattro", "cinque")); //true, true => true


String CategorizeEventCode(int eventCode)
{
    if (eventCode <= 0)
        return ("INVALID");

    if (eventCode % 4 == 0 && eventCode % 6 == 0)
        return ("CRITICAL_SYS_APP");
    else
    {

        if (eventCode % 4 == 0)
            return ("SYS");

        if (eventCode % 6 == 0)
            return ("APP");

    }

    return (eventCode.ToString());

}

int SumOddIndexElements(List<int> numbers)
{
    int sum = 0;

    for (var i = 0; i < numbers.Count; i++)

        if (!(i % 2 == 0))
            sum += numbers[i];

    return sum;

}


bool ValidateApiKeyAccess(Dictionary<string, string> apiKeyMap, string apiKey, string requiredRole)
{

    if (apiKeyMap.ContainsKey(apiKey))

        if (apiKeyMap[apiKey] == requiredRole)

            return true;

    return false;

}


#endif
