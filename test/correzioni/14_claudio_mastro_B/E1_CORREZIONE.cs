#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 14 — MASTRO CLAUDIO — Traccia B — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/b.cs.
// Fonte: test/consegne/b/mastro_claudio_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static double CalculateStorageCost(int gbUsed, bool hasPromotion)
    {
        double price = 0;

        if (gbUsed < 0)
            price = -1;

        else if (gbUsed <= 10 && gbUsed > 0)
            price = 0.0;

        else if (gbUsed > 10 && gbUsed <= 50)
            price = (gbUsed - 10) * 1.5;

        else if (gbUsed > 50)
            price = 10 + gbUsed;   //* 10 perchè alla fine se da 0 a 50 sono 60$ e devo sottrarre
                                   //* i 50 giga che non calcolo nel prezzo il risultato è quello

        if (hasPromotion)
            price = price * 0.8;

        return price;
    }
}

[TestClass]
public class Esercizio1Tests
{
    [TestMethod]
    public void Should_ReturnMinusOne_When_GbIsNegative()
    {
        Assert.AreEqual(-1.0, CalculateStorageCost(-1, false), 0.001,
            "Regola: GB negativi non sono ammessi.");
    }

    [TestMethod]
    public void Should_ReturnZero_When_GbIsUpTo10()
    {
        Assert.AreEqual(0.0, CalculateStorageCost(10, false), 0.001,
            "Regola: fino a 10 GB compresi il servizio è gratuito.");
    }

    [TestMethod]
    public void Should_Charge150PerGb_When_GbBetween11And50()
    {
        Assert.AreEqual(1.50, CalculateStorageCost(11, false), 0.001,
            "Regola: 11 GB = 1 GB eccedente a 1.50€.");
    }

    [TestMethod]
    public void Should_ChargeCorrectly_When_GbExceeds50()
    {
        Assert.AreEqual(61.0, CalculateStorageCost(51, false), 0.001,
            "Regola: 51 GB = 60€ (fascia 11-50) + 1.00€ (1 GB oltre 50).");
    }

    [TestMethod]
    public void Should_Apply20PercentDiscount_When_PromotionIsTrue()
    {
        Assert.AreEqual(48.0, CalculateStorageCost(50, true), 0.001,
            "Regola: 60€ con promozione -20% diventa 48€.");
    }

    [TestMethod]
    public void Should_CalculateStorage_When_NegativeWithPromotion()
    {
        Assert.AreEqual(-1.0, CalculateStorageCost(-1, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_Zero()
    {
        Assert.AreEqual(0.0, CalculateStorageCost(0, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_FreeWithPromotion()
    {
        Assert.AreEqual(0.0, CalculateStorageCost(10, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_Exactly50()
    {
        Assert.AreEqual(60.0, CalculateStorageCost(50, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_FarAbove50()
    {
        Assert.AreEqual(90.0, CalculateStorageCost(80, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_PromotionInMiddleRange()
    {
        Assert.AreEqual(1.2, CalculateStorageCost(11, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_PromotionAbove50()
    {
        Assert.AreEqual(48.8, CalculateStorageCost(51, true), 0.001);
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
