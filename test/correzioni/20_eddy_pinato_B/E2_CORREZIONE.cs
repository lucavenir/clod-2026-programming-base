#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 20 — PINATO EDDY — Traccia B — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/b.cs.
// Fonte: test/consegne/b/PINATO_EDDY_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static bool HasLatencySpike(List<int> latencies);
{
    for(i = 0; i <= 3; i++)
    {
        if(latencies[i] >latencies[i + 1])
        {
            Console.WriteLine(true);
        }
        else
{
    Console.WriteLine(false);
}
    }
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
// Fonte: test/consegne/b/PINATO_EDDY_clod_test_2026.cs

//esercizio 1

double CalculateStorageCost(int gbUsed, bool hasPromotion){

    if(gbUsed < 0){
        Console.WriteLine(-1.0);
    }elseif( gbUsed <=10);
    {
        Console.WriteLine(0.0 + "€");
    }elseif(gbUsed >= 11 && gbUsed <= 50);
    {
        Console.WriteLine(gbUsed * 1.50 + "€");
    }elseif(gbUsed > 50);
    {
        Console.WriteLine(gbUsed * 1.00 + "€");
    }
    if (hasPromotion == true)
    {
        Console.WriteLine(gbUsed * 0.8 + "€");
    }
}

//esercizio 2

bool HasLatencySpike(List<int> latencies);
{
    for(i = 0; i <= 3; i++)
    {
        if(latencies[i] >latencies[i+1])
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}

//esercizio 3

Dictionary<string, List<string>> GroupUsersByRole(List<(string Name,string Role)> users);




#endif
