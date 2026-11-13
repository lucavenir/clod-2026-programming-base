#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 06 — CILUFFO ALEX — Traccia F — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/f.cs.
// Nessun sorgente consegnato.
public static class ConsegnaStudente
{
#error Esercizio 1 non consegnato: nessuna implementazione presente.
}

[TestClass]
public class Esercizio1Tests
{
    [TestMethod]
    public void Should_ReturnZero_When_UserCountIsZeroOrNegative()
    {
        Assert.AreEqual(0.0, CalculateLicenseCost(0, false), 0.001,
            "Regola: 0 utenti costano 0€.");
    }

    [TestMethod]
    public void Should_Charge10PerUser_UpTo10Users()
    {
        Assert.AreEqual(100.0, CalculateLicenseCost(10, false), 0.001,
            "Regola: 10 utenti * 10€ = 100€.");
    }

    [TestMethod]
    public void Should_Charge8PerUser_Between11And50Users()
    {
        Assert.AreEqual(140.0, CalculateLicenseCost(15, false), 0.001,
            "Regola: 15 utenti = 100€ (primi 10) + 40€ (5 utenti * 8€).");
    }

    [TestMethod]
    public void Should_Apply50PercentDiscount_When_IsNonProfit()
    {
        Assert.AreEqual(70.0, CalculateLicenseCost(15, true), 0.001,
            "Regola: 140€ scontati del 50% diventano 70€.");
    }

    [TestMethod]
    public void Should_CalculateLicense_When_Negative()
    {
        Assert.AreEqual(0.0, CalculateLicenseCost(-1, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_NegativeWithDiscount()
    {
        Assert.AreEqual(0.0, CalculateLicenseCost(-1, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_ZeroWithDiscount()
    {
        Assert.AreEqual(0.0, CalculateLicenseCost(0, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_OneUser()
    {
        Assert.AreEqual(10.0, CalculateLicenseCost(1, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_ElevenUsers()
    {
        Assert.AreEqual(108.0, CalculateLicenseCost(11, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_FiftyUsers()
    {
        Assert.AreEqual(420.0, CalculateLicenseCost(50, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_FiftyOneUsers()
    {
        Assert.AreEqual(425.0, CalculateLicenseCost(51, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_ManyUsers()
    {
        Assert.AreEqual(470.0, CalculateLicenseCost(60, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_DiscountBelowTen()
    {
        Assert.AreEqual(25.0, CalculateLicenseCost(5, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateLicense_When_DiscountAboveFifty()
    {
        Assert.AreEqual(212.5, CalculateLicenseCost(51, true), 0.001);
    }
}
