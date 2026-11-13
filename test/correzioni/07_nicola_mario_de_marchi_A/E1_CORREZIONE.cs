#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 07 — DE MARCHI NICOLA MARIO — Traccia A — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/a.cs.
// Fonte: test/consegne/a/demarchi_nicolamario_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static string EvaluateServerStatus(int cpu, int ram, int temperature)
    {
        if (cpu < 0 || cpu > 100 || ram < 0 || ram > 100)
        {
            return "INVALID_DATA";
        }
        else if (temperature > 85 || cpu > 90 && ram > 90)
        {
            return "CRITICAL";
        }
        else if (cpu > 70 || ram > 70)
        {
            return "WARNING";
        }

        return "OK";
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
// Fonte: test/consegne/a/demarchi_nicolamario_clod_test_2026.cs
Console.WriteLine("FUNC EVALUATESERVERSTATUS");
Console.WriteLine(EvaluateServerStatus(101,100,100));
Console.WriteLine(EvaluateServerStatus(10,10,86));
Console.WriteLine(EvaluateServerStatus(10,71,32));
Console.WriteLine(EvaluateServerStatus(10,10,10));

Console.WriteLine();

Console.WriteLine("FUNC FINDLASTSERVERERRORINDEX");
List<int> statusCodes =  [200, 500, 404, 503, 200];
Console.WriteLine(FindLastServerErrorIndex(statusCodes));

Console.WriteLine();

Console.WriteLine("FUNC COUNTLOGLEVELS");
List<string> list = ["INFO", "ERROR", "INFO", "WARN"];
Dictionary<string,int> result = CountLogLevels(list);

foreach(var element in result)
{
    Console.WriteLine($"{element.Key} : {element.Value}");
}


string EvaluateServerStatus(int cpu, int ram, int temperature){
    if(cpu<0 || cpu>100 || ram <0 || ram>100){
        return "INVALID_DATA";
    }else if(temperature>85 || cpu>90 && ram>90){
        return "CRITICAL";
    }else if(cpu>70 || ram>70){
        return "WARNING";
    }
    
    return "OK";
}


int FindLastServerErrorIndex(List<int> statusCodes)
{
    int result = -1;
    for(int i = 0 ; i<statusCodes.Count ; i++)
    {
        if(statusCodes[i] >= 500)
        {
            result = i;
        }
    }

    return result;
}

Dictionary<string, int> CountLogLevels(List<string> logLevels)
{
    var result = new Dictionary<string , int> ();

    foreach(var log in logLevels)
    {
        if (result.ContainsKey(log))
        {
            result[log] += 1;
        }
        else
        {
            result[log] = 1;
        }
    }

    return result;
}
#endif
