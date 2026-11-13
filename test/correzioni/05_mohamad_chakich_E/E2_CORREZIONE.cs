#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 05 — CHAKICH MOHAMAD — Traccia E — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/e.cs.
// Fonte: test/consegne/e/[Chakich]_[Mohamad]_clod_test_2026.(2)cs.cs
public static class ConsegnaStudente
{
    //["A", "B", "C"] -------> ["C", "B", "A"]




    public static List<string> ReverseLogEvents(List<string> logEvents);

    public static string Invers(int Elements);
{

for (int i = length - 1; i >= 0 ; i--)

















}
}

[TestClass]
public class Esercizio2Tests
{
    [TestMethod]
    public void Should_ReturnEmptyList_When_LogEventsListIsEmpty()
    {
        var result = ReverseLogEvents([]);
        Assert.AreEqual(0, result.Count,
            "Regola: lista vuota produce lista vuota.");
    }

    [TestMethod]
    public void Should_ReverseListOrder()
    {
        var result = ReverseLogEvents(["BOOT", "LOGIN", "ERROR"]);
        CollectionAssert.AreEqual(new List<string> { "ERROR", "LOGIN", "BOOT" }, result,
            "Regola: gli elementi devono essere specchiati dall'ultimo al primo.");
    }

    [TestMethod]
    public void Should_ReverseEveryEvent_When_SingleEvent()
    {
        var result = ReverseLogEvents(["BOOT"]);
        CollectionAssert.AreEqual(new List<string> { "BOOT" }, result);
    }

    [TestMethod]
    public void Should_ReverseEveryEvent_When_TwoEvents()
    {
        var result = ReverseLogEvents(["A", "B"]);
        CollectionAssert.AreEqual(new List<string> { "B", "A" }, result);
    }

    [TestMethod]
    public void Should_ReverseEveryEvent_When_EvenLength()
    {
        var result = ReverseLogEvents(["A", "B", "C", "D"]);
        CollectionAssert.AreEqual(new List<string> { "D", "C", "B", "A" }, result);
    }

    [TestMethod]
    public void Should_ReverseEveryEvent_When_DuplicateEvents()
    {
        var result = ReverseLogEvents(["BOOT", "ERROR", "BOOT", "LOGIN"]);
        CollectionAssert.AreEqual(new List<string> { "LOGIN", "BOOT", "ERROR", "BOOT" }, result);
    }

    [TestMethod]
    public void Should_ReverseEveryEvent_When_EmptyEvent()
    {
        var result = ReverseLogEvents(["A", "", "B"]);
        CollectionAssert.AreEqual(new List<string> { "B", "", "A" }, result);
    }

    [TestMethod]
    public void Should_ReverseEveryEvent_When_IdenticalEvents()
    {
        var result = ReverseLogEvents(["A", "A"]);
        CollectionAssert.AreEqual(new List<string> { "A", "A" }, result);
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/e/[Chakich]_[Mohamad]_clod_test_2026.(2)cs.cs
//["A", "B", "C"] -------> ["C", "B", "A"]




List<string> ReverseLogEvents(List<string> logEvents);

string Invers(int Elements);
{

for (int i = length - 1; i >= 0 ; i--)

















}




#endif
