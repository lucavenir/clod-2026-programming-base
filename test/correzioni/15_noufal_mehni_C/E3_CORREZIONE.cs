#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 15 — MEHNI NOUFAL — Traccia C — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/c.cs.
// Fonte: test/consegne/c/[mehni]_[noufal]_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static Dictionary<int, int> CountHttpStatusCodeFrequency(List<int> statusCodes)
    {
        var result = new Dictionary<int, int>();
        foreach (var (frequency, codes) in statusCodes)
        {
            if (entry.Value = statusCodes.frequency)
            {
                result.Add(entry, value())
            }
        }







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
// Fonte: test/consegne/c/[mehni]_[noufal]_clod_test_2026.cs
//ESERCIZIO 2 MASCHERAMENTO ID UTENTE//

List<string> AnonymizeUserIds(List<int> userIds)
{
    var result=[];
    for(var i=0; i<userIds.length;i++)
    {
        if(userIds.length(i)>= 5000)
        {
            result.Add(userIds.length(i));
        }
        return "ANONYMOUS";
    }

return result;
    
}    


//ESERCIZIO 3 FREQUENZA CODICI HTTP//

Dictionary<int,int> CountHttpStatusCodeFrequency(List<int> statusCodes)
{
    var result= new Dictionary<int,int> ();
    foreach(var(frequency,codes) in statusCodes)
    {
        if(entry.Value=statusCodes.frequency)
        {
            result.Add(entry,value())
        }
    }
    
        
    
    
    
        
    
}

        







//ESERCIZIO 1 REGOLE FIREWALL DI RETE//
string EvaluateFirewallRule(int port, bool isInternal, string protocol)
{
    string decision= [];
    for(var port=0;)
}

#endif
