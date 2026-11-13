#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 19 — PARO GIOVANNI — Traccia A — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/a.cs.
// Fonte: test/consegne/a/paro_giovanni_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static string EvaluateServerStatus(int cpu, int ram, int temperature)
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
}

[TestClass]
public class Esercizio1Tests
{
    [TestMethod]
    public void Should_ReturnInvalidData_When_CpuIsNegative()
    {
        Assert.AreEqual("INVALID_DATA", EvaluateServerStatus(-1, 50, 70),
            "Regola: percentuali sotto lo 0% non sono valide.");
    }

    [TestMethod]
    public void Should_ReturnInvalidData_When_CpuIsAbove100()
    {
        Assert.AreEqual("INVALID_DATA", EvaluateServerStatus(101, 50, 70),
            "Regola: percentuali sopra il 100% non sono valide.");
    }

    [TestMethod]
    public void Should_ReturnInvalidData_When_RamIsNegative()
    {
        Assert.AreEqual("INVALID_DATA", EvaluateServerStatus(50, -5, 70),
            "Regola: RAM sotto lo 0% deve invalidare i dati.");
    }

    [TestMethod]
    public void Should_ReturnCritical_When_TemperatureExceeds85()
    {
        Assert.AreEqual("CRITICAL", EvaluateServerStatus(0, 0, 86),
            "Regola: temperatura > 85°C fa scattare CRITICAL a prescindere da CPU/RAM.");
    }

    [TestMethod]
    public void Should_ReturnOk_When_TemperatureIsExactly85()
    {
        Assert.AreEqual("OK", EvaluateServerStatus(50, 50, 85),
            "Regola di confine: 85°C è l'ultimo valore tollerato, non è ancora CRITICAL (> 85).");
    }

    [TestMethod]
    public void Should_ReturnWarning_When_CpuAndRamAreExactly90()
    {
        Assert.AreEqual("WARNING", EvaluateServerStatus(90, 90, 50),
            "Regola di confine: CPU e RAM a 90 non bastano per CRITICAL (servono entrambe > 90).");
    }

    [TestMethod]
    public void Should_ReturnCritical_When_CpuAndRamBothExceed90()
    {
        Assert.AreEqual("CRITICAL", EvaluateServerStatus(91, 91, 50),
            "Regola: sia CPU che RAM > 90 fanno scattare CRITICAL.");
    }

    [TestMethod]
    public void Should_ReturnWarning_When_CpuExceeds70()
    {
        Assert.AreEqual("WARNING", EvaluateServerStatus(71, 50, 50),
            "Regola: CPU > 70 fa scattare WARNING.");
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_RamIsAbove100()
    {
        Assert.AreEqual("INVALID_DATA", EvaluateServerStatus(50, 101, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_InvalidCpuTakesPriorityOverCriticalTemperature()
    {
        Assert.AreEqual("INVALID_DATA", EvaluateServerStatus(-1, 50, 100));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_InvalidRamTakesPriorityOverHighLoad()
    {
        Assert.AreEqual("INVALID_DATA", EvaluateServerStatus(95, 101, 90));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_CpuAndRamAreZero()
    {
        Assert.AreEqual("OK", EvaluateServerStatus(0, 0, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_CpuAndRamAre100()
    {
        Assert.AreEqual("CRITICAL", EvaluateServerStatus(100, 100, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_CpuAndRamAreExactly70()
    {
        Assert.AreEqual("OK", EvaluateServerStatus(70, 70, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_OnlyRamExceeds70()
    {
        Assert.AreEqual("WARNING", EvaluateServerStatus(50, 71, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_OnlyCpuExceeds90()
    {
        Assert.AreEqual("WARNING", EvaluateServerStatus(91, 50, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_OnlyRamExceeds90()
    {
        Assert.AreEqual("WARNING", EvaluateServerStatus(50, 91, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_CpuIs90AndRamExceeds90()
    {
        Assert.AreEqual("WARNING", EvaluateServerStatus(90, 91, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_RamIs90AndCpuExceeds90()
    {
        Assert.AreEqual("WARNING", EvaluateServerStatus(91, 90, 50));
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
