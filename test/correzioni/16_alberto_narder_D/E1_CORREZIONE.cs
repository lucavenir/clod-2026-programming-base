#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 16 — NARDER ALBERTO — Traccia D — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/d.cs.
// Fonte: test/consegne/d/narder_esercizio_1.cs
public static class ConsegnaStudente
{
    List<int> eventCode = [];


foreach(int n in eventCode)
{
    if(n <= 0)
        return "Invalid"; 
  
    if(n % 4 == 0 && n % 6 == 0)
        return "CRITICAL_SYS_APP";

    if(n % 4 == 0)
        return "SYS";
    
    if(n % 6 == 0)
        return "APP";
  
    else
  
        return "eventCode";
  }
}

[TestClass]
public class Esercizio1Tests
{
    [TestMethod]
    public void Should_ReturnInvalid_When_CodeIsZeroOrNegative()
    {
        Assert.AreEqual("INVALID", CategorizeEventCode(0),
            "Regola: codice <= 0 non è valido.");
    }

    [TestMethod]
    public void Should_ReturnCritical_When_DivisibleBy4And6()
    {
        Assert.AreEqual("CRITICAL_SYS_APP", CategorizeEventCode(12),
            "Regola: 12 è divisibile sia per 4 che per 6.");
    }

    [TestMethod]
    public void Should_ReturnSys_When_DivisibleOnlyBy4()
    {
        Assert.AreEqual("SYS", CategorizeEventCode(8),
            "Regola: 8 è divisibile per 4 ma non per 6.");
    }

    [TestMethod]
    public void Should_ReturnApp_When_DivisibleOnlyBy6()
    {
        Assert.AreEqual("APP", CategorizeEventCode(18),
            "Regola: 18 è divisibile per 6 ma non per 4.");
    }

    [TestMethod]
    public void Should_ReturnNumberAsString_When_NotDivisibleBy4Or6()
    {
        Assert.AreEqual("7", CategorizeEventCode(7),
            "Regola fallback: 7 non è divisibile né per 4 né per 6.");
    }

    [TestMethod]
    public void Should_CategorizeEvent_When_NegativeMultiple()
    {
        Assert.AreEqual("INVALID", CategorizeEventCode(-12));
    }

    [TestMethod]
    public void Should_CategorizeEvent_When_AnotherCommonMultiple()
    {
        Assert.AreEqual("CRITICAL_SYS_APP", CategorizeEventCode(24));
    }

    [TestMethod]
    public void Should_CategorizeEvent_When_OnlyFour()
    {
        Assert.AreEqual("SYS", CategorizeEventCode(4));
    }

    [TestMethod]
    public void Should_CategorizeEvent_When_OnlySix()
    {
        Assert.AreEqual("APP", CategorizeEventCode(6));
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/d/narder_esercizio_1.cs
List<int> eventCode = [];


foreach(int n in eventCode)
{
    if(n <= 0)
        return "Invalid"; 
  
    if(n % 4 == 0 && n % 6 == 0)
        return "CRITICAL_SYS_APP";

    if(n % 4 == 0)
        return "SYS";
    
    if(n % 6 == 0)
        return "APP";
  
    else
  
        return "eventCode";
  }



    
    

#endif
