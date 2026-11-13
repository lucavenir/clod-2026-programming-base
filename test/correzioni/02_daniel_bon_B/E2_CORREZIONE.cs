#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 02 — BON DANIEL — Traccia B — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/b.cs.
// Fonte: test/consegne/b/Bon_Daniel_cloud_test_2026.cs
public static class ConsegnaStudente
{
    public static bool HasLatencySpike(List<int> latencies)
    {

        int preweus_element = 0;

        if (latencies.Count < 2)
            return false;

        foreach (var element in latencies)
        {
            if (((element - preweus_element) > 50) && element != latencies[0])
                return true;
            preweus_element = element;
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
