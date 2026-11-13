#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 14 — MASTRO CLAUDIO — Traccia B — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/b.cs.
// Fonte: test/consegne/b/mastro_claudio_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static bool HasLatencySpike(List<int> latencies)
    {

        if (latencies.Count() < 2)
            return false;

        for (var i = 1; i < latencies.Count() - 1; i++)
        {
            if (latencies[i] > latencies[i - 1])
            {
                if (latencies[i] - latencies[i - 1] >= 50)
                    return true;
            }

        }

        return false;
    }
}

[TestClass]
public class Esercizio2Tests
{
    [TestMethod]
    public void Should_ReturnFalse_When_ListHasLessThanTwoElements()
    {
        Assert.IsFalse(HasLatencySpike([100]),
            "Regola: servono almeno 2 misurazioni per calcolare un salto.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_JumpIsExactly50Ms()
    {
        Assert.IsFalse(HasLatencySpike([10, 60]),
            "Regola di confine: incremento di 50 ms non basta, deve essere STRETTAMENTE > 50 ms.");
    }

    [TestMethod]
    public void Should_ReturnTrue_When_JumpExceeds50Ms()
    {
        Assert.IsTrue(HasLatencySpike([10, 61]),
            "Regola: incremento di 51 ms deve far scattare lo spike.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_LatencyDecreases()
    {
        Assert.IsFalse(HasLatencySpike([100, 20]),
            "Regola: un calo improvviso di latenza non è uno spike.");
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_Empty()
    {
        Assert.AreEqual(false, HasLatencySpike([]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_JumpAtLastPair()
    {
        Assert.AreEqual(true, HasLatencySpike([10, 20, 80]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_JumpAtFirstPair()
    {
        Assert.AreEqual(true, HasLatencySpike([10, 80, 85]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_EqualMeasurements()
    {
        Assert.AreEqual(false, HasLatencySpike([100, 100, 100]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_AllJumpsBelowThreshold()
    {
        Assert.AreEqual(false, HasLatencySpike([10, 20, 30, 40]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_PeakEqualsFirstMeasurement()
    {
        Assert.AreEqual(true, HasLatencySpike([100, 10, 100]));
    }

    [TestMethod]
    public void Should_RejectExactly50MsJump_InsideLongerList()
    {
        Assert.IsFalse(HasLatencySpike([10, 60, 70]));
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/b/mastro_claudio_clod_test_2026.cs
Dictionary<string, List<string>> GroupUsersByRole(List<(string Name, string Role)> users)
{
   var result = new Dictionary<string, List<string>>();

    foreach (var user in users)
    {
        if (!result.ContainsKey(user.Role))
            result.Add(user.Role, []);

        result[user.Role].Add(user.Name);
    }

    return result;
}


bool HasLatencySpike(List<int> latencies)
{

    if (latencies.Count() < 2)
        return false;

    for(var i=1; i<latencies.Count()-1; i++)
    {
        if (latencies[i] > latencies[i-1])
        {
            if (latencies[i] - latencies[i-1] >= 50)
                return true;
        }
            
    }

    return false;
}

double CalculateStorageCost(int gbUsed, bool hasPromotion)
{
    double price = 0;

    if (gbUsed<0)
        price = -1;

        else if (gbUsed<=10 && gbUsed>0)
            price = 0.0;

            else if (gbUsed>10 && gbUsed<=50)
                price = (gbUsed-10)*1.5;
            
                else if(gbUsed > 50)
                    price = 10 + gbUsed;   //* 10 perchè alla fine se da 0 a 50 sono 60$ e devo sottrarre
                                            //* i 50 giga che non calcolo nel prezzo il risultato è quello

    if (hasPromotion)
         price = price * 0.8;

        return price;
} 


#endif
