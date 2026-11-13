#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 19 — PARO GIOVANNI — Traccia A — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/a.cs.
// Fonte: test/consegne/a/paro_giovanni_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static Dictionary<string, int> CountLogLevels(List<string> logLevels)
    {
        Dictionary<string, int> results = [];
        foreach (string element in logLevels)
        {
            if (!results.ContainsKey(element))
            {
                results.Add[element.item1];
            }
            else
            {
                results.Add[results.Values];
            }
        }
        return results;
    }
}

[TestClass]
public class Esercizio3Tests
{
    [TestMethod]
    public void Should_ReturnEmptyDictionary_When_LogListIsEmpty()
    {
        var result = CountLogLevels([]);
        Assert.AreEqual(0, result.Count,
            "Regola: lista vuota produce mappa vuota.");
    }

    [TestMethod]
    public void Should_CountLogOccurrencesCorrectly()
    {
        var result = CountLogLevels(["INFO", "ERROR", "INFO", "WARN"]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(2, result["INFO"]);
        Assert.AreEqual(1, result["ERROR"]);
        Assert.AreEqual(1, result["WARN"]);
    }

    [TestMethod]
    public void Should_CountAllLevels_When_SingleLevel()
    {
        var result = CountLogLevels(["ERROR"]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(1, result["ERROR"]);
        CollectionAssert.AreEquivalent(new List<string> { "ERROR" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountAllLevels_When_AllLevelsRepeat()
    {
        var result = CountLogLevels(["INFO", "INFO", "INFO"]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(3, result["INFO"]);
        CollectionAssert.AreEquivalent(new List<string> { "INFO" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountAllLevels_When_AllLevelsDiffer()
    {
        var result = CountLogLevels(["INFO", "WARN", "ERROR"]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(1, result["INFO"]);
        Assert.AreEqual(1, result["WARN"]);
        Assert.AreEqual(1, result["ERROR"]);
        CollectionAssert.AreEquivalent(new List<string> { "INFO", "WARN", "ERROR" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountAllLevels_When_DifferentFrequencies()
    {
        var result = CountLogLevels(["WARN", "ERROR", "WARN", "INFO", "ERROR", "ERROR"]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(2, result["WARN"]);
        Assert.AreEqual(3, result["ERROR"]);
        Assert.AreEqual(1, result["INFO"]);
        CollectionAssert.AreEquivalent(new List<string> { "WARN", "ERROR", "INFO" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountAllLevels_When_UnknownLabels()
    {
        var result = CountLogLevels(["DEBUG", "TRACE", "DEBUG"]);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(2, result["DEBUG"]);
        Assert.AreEqual(1, result["TRACE"]);
        CollectionAssert.AreEquivalent(new List<string> { "DEBUG", "TRACE" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountAllLevels_When_EmptyLabel()
    {
        var result = CountLogLevels(["", "INFO", ""]);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(2, result[""]);
        Assert.AreEqual(1, result["INFO"]);
        CollectionAssert.AreEquivalent(new List<string> { "", "INFO" }, new List<string>(result.Keys));
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/a/paro_giovanni_clod_test_2026.cs
//ESERCIZIO 1
string EvaluateServerStatus(int cpu, int ram, int temperature)
{
    if (cpu < 0 || cpu > 100 || ram < 0 || ram > 100)
    {
        return "INVALID DATA";
    }
    else if (temperature > 85 || (cpu > 90 && ram > 90))
    {
        return "CRITICAL";
    }
    else if (cpu > 70 || ram > 70)
    {
        return "WARNING";
    }
    else
    {
        return "OK";
    }
}

Console.WriteLine(EvaluateServerStatus(92, 92, 87));


//ESERCIZIO 2
List<int> codes =[200, 500, 404, 503, 200];

int FindLastServerErrorIndex(List<int> statusCodes)
{
    int position=-1;
    for (int i=0; i<statusCodes.Count; i++)
    { 
        if (statusCodes.Count < 0)
        {
            position=-1;
            return position;
        }
        else if (statusCodes[i] >= 500)
        {
            position+=2;
            
        }
    }
    return position;
}
Console.WriteLine(FindLastServerErrorIndex(codes));


//ESERCIZIO 3
List<string> etiquettes = ["INFO", "ERROR", "INFO", "WARN"];
Dictionary<string, int> CountLogLevels(List<string> logLevels)
{
    Dictionary<string, int> results = [];
    foreach(string element in logLevels)
    {
        if (!results.ContainsKey(element))
        {
            results.Add[element.item1];
        }
        else
        {
            results.Add[results.Values];
        }
    }
    return results;
}

Console.WriteLine(CountLogLevels(etiquettes));
#endif
