#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 06 — CILUFFO ALEX — Traccia F — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/f.cs.
// Nessun sorgente consegnato.
public static class ConsegnaStudente
{
#error Esercizio 2 non consegnato: nessuna implementazione presente.
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
