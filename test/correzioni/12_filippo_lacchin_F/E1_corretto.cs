#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 12 — LACCHIN FILIPPO — Traccia F — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Copia corretta: interventi minimi documentati qui sotto. Nessuna modifica algoritmica. Test invariati da test/f.cs.
// Fonte: test/consegne/f/lacchin_es1.cs
// Interventi: Aggiunto = a result / 2 per rendere valida l’istruzione. result è una variabile locale mai restituita: calcolo dei prezzi e condizioni invariati.
public static class ConsegnaStudente
{
    public static double CalculateLicenseCost(int userCount, bool isNonProfit)
    {


        var result = 0;
        double isNotProfit = 0;

        {
            {
                if (userCount == isNotProfit)
                    result /= 2;

                if (userCount <= 0)
                    return 0.0;

                if (userCount <= 10)
                    return 10.00;

                if (userCount >= 11 || userCount <= 50)
                    return 8.00;

                else
                    return 5.00;
            }

        }
    }
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

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/f/lacchin_es1.cs

CalculateLicenseCost(1, 18, 33, 49, 66, 90, 55, 3, 44);

double CalculateLicenseCost(int userCount, bool isNonProfit)
{


    var result = 0;
    double isNotProfit = 0;

    {
        {
            if (userCount == isNotProfit)
                result / 2;

            if (userCount <= 0)
                return 0.0;

            if (userCount <= 10)
                return 10.00;

            if (userCount >= 11 || userCount <= 50)
                return 8.00;

            else
                return 5.00;
        }

    }
}
#endif
