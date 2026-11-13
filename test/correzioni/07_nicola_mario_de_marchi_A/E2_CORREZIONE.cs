#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 07 — DE MARCHI NICOLA MARIO — Traccia A — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/a.cs.
// Fonte: test/consegne/a/demarchi_nicolamario_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static int FindLastServerErrorIndex(List<int> statusCodes)
    {
        int result = -1;
        for (int i = 0; i < statusCodes.Count; i++)
        {
            if (statusCodes[i] >= 500)
            {
                result = i;
            }
        }

        return result;
    }
}

[TestClass]
public class Esercizio2Tests
{
    [TestMethod]
    public void Should_ReturnMinusOne_When_ListIsEmpty()
    {
        Assert.AreEqual(-1, FindLastServerErrorIndex([]),
            "Regola: lista vuota deve restituire -1.");
    }

    [TestMethod]
    public void Should_ReturnMinusOne_When_NoServerErrorExists()
    {
        Assert.AreEqual(-1, FindLastServerErrorIndex([200, 201, 404, 499]),
            "Regola: nessun codice >= 500 presente.");
    }

    [TestMethod]
    public void Should_ReturnZero_When_ServerErrorIsAtFirstPosition()
    {
        Assert.AreEqual(0, FindLastServerErrorIndex([500, 200, 200]),
            "Regola: unico errore all'indice 0.");
    }

    [TestMethod]
    public void Should_ReturnLastIndex_When_MultipleServerErrorsExist()
    {
        Assert.AreEqual(3, FindLastServerErrorIndex([500, 200, 404, 502, 200]),
            "Regola: deve trovare l'ULTIMO errore nella lista (indice 3), non il primo.");
    }

    [TestMethod]
    public void Should_FindLastError_When_OnlySuccess()
    {
        Assert.AreEqual(-1, FindLastServerErrorIndex([200]));
    }

    [TestMethod]
    public void Should_FindLastError_When_Only499()
    {
        Assert.AreEqual(-1, FindLastServerErrorIndex([499]));
    }

    [TestMethod]
    public void Should_FindLastError_When_Only500()
    {
        Assert.AreEqual(0, FindLastServerErrorIndex([500]));
    }

    [TestMethod]
    public void Should_FindLastError_When_ErrorIsAtLastPosition()
    {
        Assert.AreEqual(2, FindLastServerErrorIndex([200, 404, 500]));
    }

    [TestMethod]
    public void Should_FindLastError_When_AllCodesAreErrors()
    {
        Assert.AreEqual(2, FindLastServerErrorIndex([500, 503, 502]));
    }

    [TestMethod]
    public void Should_FindLastError_When_ErrorsHaveIrregularPositions()
    {
        Assert.AreEqual(4, FindLastServerErrorIndex([200, 500, 200, 200, 503, 200]));
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
