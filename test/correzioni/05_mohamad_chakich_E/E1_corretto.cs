#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 05 — CHAKICH MOHAMAD — Traccia E — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Copia corretta: interventi minimi documentati qui sotto. Nessuna modifica algoritmica. Test invariati da test/e.cs.
// Fonte: test/consegne/e/[Chakich]_[Mohamad]_clod_test_2026(1).cs.cs
// Nome originale ClassifyPingLatecy conservato: i test richiedono ClassifyPingLatency.
// Interventi: Rinominata solo ClassifyPingLatecy in ClassifyPingLatency. else; conservato: warning, non blocca i test.
public static class ConsegnaStudente
{
    public static string ClassifyPingLatency(int pingMs)
    {

        if (pingMs <= 0)
            return "TIMEOUT";


        if (pingMs > 400)
            return "CRITICAL";


        if (pingMs > 150 && pingMs <= 400)
            return "SLOW";

        else;
        return "FAST";






    }
}

[TestClass]
public class Esercizio1Tests
{
    [TestMethod]
    public void Should_ReturnTimeout_When_PingIsZeroOrNegative()
    {
        Assert.AreEqual("TIMEOUT", ClassifyPingLatency(0),
            "Regola: latenza <= 0ms significa TIMEOUT.");
    }

    [TestMethod]
    public void Should_ReturnFast_When_PingIsUpTo150()
    {
        Assert.AreEqual("FAST", ClassifyPingLatency(150),
            "Regola di confine: 150ms è compreso in FAST.");
    }

    [TestMethod]
    public void Should_ReturnSlow_When_PingIsBetween151And400()
    {
        Assert.AreEqual("SLOW", ClassifyPingLatency(151),
            "Regola di confine: 151ms entra nella categoria SLOW.");
    }

    [TestMethod]
    public void Should_ReturnSlow_When_PingIsExactly400()
    {
        Assert.AreEqual("SLOW", ClassifyPingLatency(400),
            "Regola di confine: 400ms è l'ultimo valore compreso in SLOW.");
    }

    [TestMethod]
    public void Should_ReturnCritical_When_PingExceeds400()
    {
        Assert.AreEqual("CRITICAL", ClassifyPingLatency(401),
            "Regola: ping > 400ms è CRITICAL.");
    }

    [TestMethod]
    public void Should_ClassifyPing_When_Negative()
    {
        Assert.AreEqual("TIMEOUT", ClassifyPingLatency(-1));
    }

    [TestMethod]
    public void Should_ClassifyPing_When_MinimumPositive()
    {
        Assert.AreEqual("FAST", ClassifyPingLatency(1));
    }

    [TestMethod]
    public void Should_ClassifyPing_When_InsideSlowRange()
    {
        Assert.AreEqual("SLOW", ClassifyPingLatency(250));
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/e/[Chakich]_[Mohamad]_clod_test_2026(1).cs.cs


Console.WriteLine(88);


string ClassifyPingLatecy(int pingMs)
{
    
         if (pingMs <= 0) 
        return "TIMEOUT";
    
    
         if (pingMs > 400) 
        return "CRITICAL";
    
    
         if (pingMs > 150 && pingMs <= 400) 
        return "SLOW";
    
      else;
      return "FAST";
      
      
    
    
   

}























#endif
