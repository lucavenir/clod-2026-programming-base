#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 02 — BON DANIEL — Traccia B — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/b.cs.
// Fonte: test/consegne/b/Bon_Daniel_cloud_test_2026.cs
public static class ConsegnaStudente
{
    public static double CalculateStorageCost(int gbUsed, bool hasPromotion)
    {

        /*Se gbUsed < 0 → restituisce -1.0.
        Fino a 10 GB compresi → 0.0€.
        Da 11 a 50 GB compresi → i GB oltre i 10 costano 1.50€ al GB.
        Oltre i 50 GB → i primi 10 gratis, da 11 a 50 costano 1.50€/GB (totale 60€), e ogni GB oltre 50 costa 1.00€/GB.
        Se hasPromotion == true, viene applicato uno sconto del 20% sul totale finale calcolato.
        */

        double final_cost = 0;
        if (gbUsed < 0)
            return -1;
        else if (gbUsed <= 10)
            return 0;
        else if (gbUsed <= 50)
            final_cost = ((gbUsed - 10) * 1.5);
        else final_cost = (gbUsed + 50);

        if (hasPromotion == true)
            final_cost *= 0.2;

        return final_cost;
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
// Fonte: test/consegne/b/Bon_Daniel_cloud_test_2026.cs
using System.Linq.Expressions;

int gbUsed=60;

bool hasPromotion=false;

Console.WriteLine($"The final cost of your {gbUsed} GB is :{CalculateStorageCost(gbUsed,hasPromotion)} dollars");


double CalculateStorageCost(int gbUsed, bool hasPromotion){

    /*Se gbUsed < 0 → restituisce -1.0.
    Fino a 10 GB compresi → 0.0€.
    Da 11 a 50 GB compresi → i GB oltre i 10 costano 1.50€ al GB.
    Oltre i 50 GB → i primi 10 gratis, da 11 a 50 costano 1.50€/GB (totale 60€), e ogni GB oltre 50 costa 1.00€/GB.
    Se hasPromotion == true, viene applicato uno sconto del 20% sul totale finale calcolato.
    */
    
    double final_cost = 0;
    if(gbUsed<0)
            return -1;
        else if(gbUsed<=10)
            return 0;
            else if(gbUsed<=50)
                final_cost = ((gbUsed - 10)*1.5);
                else final_cost = (gbUsed +50);

    if(hasPromotion==true)
        final_cost*=0.2;

    return final_cost;
}

List<int> latencies = [10, 20, 80, 85];

Console.WriteLine($"The control of latency skies has returned: {HasLatencySpike(latencies)}");

bool HasLatencySpike(List<int> latencies){

    int preweus_element=0;

    if(latencies.Count<2)
        return false;
    
    foreach(var element in latencies){
        if(((element-preweus_element)>50)&&element!=latencies[0])
            return true;
        preweus_element=element;
    }
    return false;
}

List<(string Name, string Role)> users = [
    ("Nome","Ruolo"),
    ("AAAA","Ruolo"),
    ("BBBB","Si"),
];

foreach(var element in GroupUsersByRole(users))
{
    Console.WriteLine($"{element.Key}: {string.Join(", ",element.Value)}");
}

Dictionary<string, List<string>> GroupUsersByRole(List<(string Name, string Role)> users){
    Dictionary<string,List<string>> Final = new();

    foreach(var element in users){
        if (!Final.ContainsKey(element.Role))
            Final[element.Role]= new List<string>();
        Final[element.Role].Add(element.Name);
    } 

    return Final;
}

#endif
