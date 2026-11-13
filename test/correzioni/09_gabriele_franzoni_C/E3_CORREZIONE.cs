#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 09 — FRANZONI GABRIELE — Traccia C — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/c.cs.
// Fonte: test/consegne/c/Franzoni_Gabriele_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static Dictionary<int, int> CountHttpStatusCodeFrequency(List<int> input)
    {


        Dictionary<int, int> Result = new();

        for (int i = 0; i < input.Count; i++)
        {

            int frequenza = 0;

            if (Result.ContainsKey)
            {
                Result[input[i]].Add(frequenza = +1);


            }

            else
            {
                Result.Add[input[i]];
                Result[input[i]].Add(frequenza + 1);

            }


        }

        return Result;

    }
}

[TestClass]
public class Esercizio3Tests
{
    [TestMethod]
    public void Should_ReturnEmptyDictionary_When_StatusCodesListIsEmpty()
    {
        var result = CountHttpStatusCodeFrequency([]);
        Assert.AreEqual(0, result.Count,
            "Regola: lista vuota produce mappa vuota.");
    }

    [TestMethod]
    public void Should_CountHttpFrequenciesCorrectly()
    {
        var result = CountHttpStatusCodeFrequency([200, 404, 200]);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(2, result[200]);
        Assert.AreEqual(1, result[404]);
    }

    [TestMethod]
    public void Should_CountAllHttpCodes_When_SingleCode()
    {
        var result = CountHttpStatusCodeFrequency([201]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(1, result[201]);
    }

    [TestMethod]
    public void Should_CountAllHttpCodes_When_RepeatedCode()
    {
        var result = CountHttpStatusCodeFrequency([503, 503, 503]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(3, result[503]);
    }

    [TestMethod]
    public void Should_CountAllHttpCodes_When_DifferentCodes()
    {
        var result = CountHttpStatusCodeFrequency([200, 404, 500]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(1, result[200]);
        Assert.AreEqual(1, result[404]);
        Assert.AreEqual(1, result[500]);
    }

    [TestMethod]
    public void Should_CountAllHttpCodes_When_DifferentFrequencies()
    {
        var result = CountHttpStatusCodeFrequency([404, 200, 404, 500, 500, 500]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(2, result[404]);
        Assert.AreEqual(1, result[200]);
        Assert.AreEqual(3, result[500]);
    }

    [TestMethod]
    public void Should_CountAllHttpCodes_When_ClientAndServerCodes()
    {
        var result = CountHttpStatusCodeFrequency([200, 499, 500, 200]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(2, result[200]);
        Assert.AreEqual(1, result[499]);
        Assert.AreEqual(1, result[500]);
    }

    [TestMethod]
    public void Should_CountAllHttpCodes_When_SameCodeAtBothEnds()
    {
        var result = CountHttpStatusCodeFrequency([200, 404, 200]);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(2, result[200]);
        Assert.AreEqual(1, result[404]);
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/c/Franzoni_Gabriele_clod_test_2026.cs
//ESERCIZIO 1
string EvaluateFirewallRule(int port, bool isInternal, string protocol)
{
    if (port == 22 && isInternal == false)
    return "BLOCK_SSH_RISK";

    if (protocol == "HTTP")
    return "REDIRECT_HTTPS";

    if (port == 443 || isInternal == true)
    return "ALLOW";

    else 
    return "DENY";


}


//ESERCIZIO 2
List<string> AnonymizeUserIds(List<int> userIds)
{
    for (int i = 0; i<userIds.Count; i++)
    {
        if (userIds[i] >= 5000)
        {
            return "ANONYMUS";
        }
        else 
        return userIds[i];

    }

}






//ESERCIZIO 3
Dictionary<int, int> CountHttpStatusCodeFrequency(List <int> input)
{


Dictionary<int, int> Result = new();

for (int i = 0; i < input.Count; i++)
{

    int frequenza = 0;

    if (Result.ContainsKey)
    {
        Result [input[i]].Add (frequenza =+ 1);


    }

    else
        {
         Result.Add [input[i]];
         Result [input[i]].Add (frequenza + 1);

        }


}

return Result;

}


 
#endif
