#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 10 — GRATTONI GABRIELE — Traccia D — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/d.cs.
// Fonte: test/consegne/d/grattoni_gabriele_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static String CategorizeEventCode(int eventCode)
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
}

[TestClass]
public class Esercizio1Tests
{
    [TestMethod]
    public void Should_ReturnInvalid_When_CodeIsZeroOrNegative()
    {
        Assert.AreEqual("INVALID", CategorizeEventCode(0),
            "Regola: codice <= 0 non è valido.");
    }

    [TestMethod]
    public void Should_ReturnCritical_When_DivisibleBy4And6()
    {
        Assert.AreEqual("CRITICAL_SYS_APP", CategorizeEventCode(12),
            "Regola: 12 è divisibile sia per 4 che per 6.");
    }

    [TestMethod]
    public void Should_ReturnSys_When_DivisibleOnlyBy4()
    {
        Assert.AreEqual("SYS", CategorizeEventCode(8),
            "Regola: 8 è divisibile per 4 ma non per 6.");
    }

    [TestMethod]
    public void Should_ReturnApp_When_DivisibleOnlyBy6()
    {
        Assert.AreEqual("APP", CategorizeEventCode(18),
            "Regola: 18 è divisibile per 6 ma non per 4.");
    }

    [TestMethod]
    public void Should_ReturnNumberAsString_When_NotDivisibleBy4Or6()
    {
        Assert.AreEqual("7", CategorizeEventCode(7),
            "Regola fallback: 7 non è divisibile né per 4 né per 6.");
    }

    [TestMethod]
    public void Should_CategorizeEvent_When_NegativeMultiple()
    {
        Assert.AreEqual("INVALID", CategorizeEventCode(-12));
    }

    [TestMethod]
    public void Should_CategorizeEvent_When_AnotherCommonMultiple()
    {
        Assert.AreEqual("CRITICAL_SYS_APP", CategorizeEventCode(24));
    }

    [TestMethod]
    public void Should_CategorizeEvent_When_OnlyFour()
    {
        Assert.AreEqual("SYS", CategorizeEventCode(4));
    }

    [TestMethod]
    public void Should_CategorizeEvent_When_OnlySix()
    {
        Assert.AreEqual("APP", CategorizeEventCode(6));
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
