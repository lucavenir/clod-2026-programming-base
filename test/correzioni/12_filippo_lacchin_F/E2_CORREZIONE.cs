#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 12 — LACCHIN FILIPPO — Traccia F — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/f.cs.
// Fonte: test/consegne/f/lacchin_es2.cs
public static class ConsegnaStudente
{
    public static bool IsStrictlyIncreasing(List<int> values)
    {

        bool result;

        foreach (var i in values)
        {
            if (values = [] || values = [1])
                return true;

            if (values[i] > values[i - 1])
                return true;

            else
                return false;
        }

    }
}

[TestClass]
public class Esercizio2Tests
{
    [TestMethod]
    public void Should_ReturnTrue_When_SequenceIsStrictlyIncreasing()
    {
        Assert.IsTrue(IsStrictlyIncreasing([1, 3, 5, 10]),
            "Regola: ogni elemento è maggiore del precedente.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_AdjacentElementsAreEqual()
    {
        Assert.IsFalse(IsStrictlyIncreasing([1, 3, 3, 5]),
            "Regola: 3 == 3 non è 'STRETTAMENTE' crescente.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_SequenceDecreases()
    {
        Assert.IsFalse(IsStrictlyIncreasing([5, 2, 8]),
            "Regola: un calo rende la sequenza non crescente.");
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_Empty()
    {
        Assert.AreEqual(true, IsStrictlyIncreasing([]));
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_Single()
    {
        Assert.AreEqual(true, IsStrictlyIncreasing([5]));
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_TwoIncreasing()
    {
        Assert.AreEqual(true, IsStrictlyIncreasing([1, 2]));
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_TwoEqual()
    {
        Assert.AreEqual(false, IsStrictlyIncreasing([3, 3]));
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_TwoDecreasing()
    {
        Assert.AreEqual(false, IsStrictlyIncreasing([5, 2]));
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_OnlyLastPairDecreases()
    {
        Assert.AreEqual(false, IsStrictlyIncreasing([1, 3, 2]));
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_OnlyLastPairIsEqual()
    {
        Assert.AreEqual(false, IsStrictlyIncreasing([1, 2, 2]));
    }

    [TestMethod]
    public void Should_CheckEveryPair_When_IncludesNegativeValues()
    {
        Assert.AreEqual(true, IsStrictlyIncreasing([-5, -2, 0, 3]));
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/f/lacchin_es2.cs
List<int>list = [2, 4, 6, 8, 10, 12, 14, 16, 18];

bool IsStrictlyIncreasing(List<int> values)
{

    bool result;

    foreach (var i in values)
    {
        if (values = [] || values = [1])
            return true;

        if (values[i] > values[i - 1])
            return true;

        else
            return false;
    }

}
#endif
