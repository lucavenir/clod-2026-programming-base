#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 21 — SANTONI CHIARA — Traccia C — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/c.cs.
// Fonte: test/consegne/c/santoni_chiara_es_2.cs
public static class ConsegnaStudente
{

    public static List<(string, int)> AnonymizeUserIds(List<int> userIds, int n);
    int n = 0;
foreach(var n in userIds)
{
    if (n< 5000)
    {
        return n;
    }
    else
{
    return (Console.WriteLine("ANONYMOUS"));
}
}
//Mi da errore, ma non riesco a capire come migliorarlo.
// L'errore (12,15) non lo capisco (Non è possibile convertire in modo implicito il tipo 'void' in 'int') :')
}

[TestClass]
public class Esercizio2Tests
{
    [TestMethod]
    public void Should_ReturnEmptyList_When_UserIdsListIsEmpty()
    {
        var result = AnonymizeUserIds([]);
        Assert.AreEqual(0, result.Count,
            "Regola: lista vuota produce lista vuota.");
    }

    [TestMethod]
    public void Should_KeepId_When_LessThan5000()
    {
        var result = AnonymizeUserIds([4999]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("4999", result[0],
            "Regola di confine: ID 4999 (< 5000) non va anonimizzato.");
    }

    [TestMethod]
    public void Should_Anonymize_When_5000OrGreater()
    {
        var result = AnonymizeUserIds([5000]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("ANONYMOUS", result[0],
            "Regola di confine: ID 5000 (>= 5000) deve diventare 'ANONYMOUS'.");
    }

    [TestMethod]
    public void Should_PreserveIdsAndOrder_When_TwoVisibleIds()
    {
        var result = AnonymizeUserIds([100, 200]);
        CollectionAssert.AreEqual(new List<string> { "100", "200" }, result);
    }

    [TestMethod]
    public void Should_PreserveIdsAndOrder_When_MixedBoundaryIds()
    {
        var result = AnonymizeUserIds([4999, 5000, 5001]);
        CollectionAssert.AreEqual(new List<string> { "4999", "ANONYMOUS", "ANONYMOUS" }, result);
    }

    [TestMethod]
    public void Should_PreserveIdsAndOrder_When_HiddenThenVisible()
    {
        var result = AnonymizeUserIds([7000, 42]);
        CollectionAssert.AreEqual(new List<string> { "ANONYMOUS", "42" }, result);
    }

    [TestMethod]
    public void Should_PreserveIdsAndOrder_When_RepeatedIds()
    {
        var result = AnonymizeUserIds([12, 12, 5000, 5000]);
        CollectionAssert.AreEqual(new List<string> { "12", "12", "ANONYMOUS", "ANONYMOUS" }, result);
    }

    [TestMethod]
    public void Should_PreserveIdsAndOrder_When_ZeroId()
    {
        var result = AnonymizeUserIds([0]);
        CollectionAssert.AreEqual(new List<string> { "0" }, result);
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/c/santoni_chiara_es_2.cs

List<(string, int)> AnonymizeUserIds(List<int>userIds, int n);
int n=0;
foreach(var n in userIds)
{
    if (n < 5000)
    {
        return n;
    }
    else
    {
       return(Console.WriteLine("ANONYMOUS"));
    }
}
//Mi da errore, ma non riesco a capire come migliorarlo.
// L'errore (12,15) non lo capisco (Non è possibile convertire in modo implicito il tipo 'void' in 'int') :')

#endif
