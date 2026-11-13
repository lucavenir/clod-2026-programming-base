#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 24 — TEGON MOIRA — Traccia F — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/f.cs.
// Fonte: test/consegne/f/tegon_moira_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static double CalculateLicenseCost(int userCount, bool isNonProfit)
    {
        if (userCount <= 0) return 0.0;

        double cost = 0;

        if (userCount <= 10)
        {
            cost = 10.0 * userCount;
            if (isNonProfit)
            {
                cost = cost * 50.0 / 100.0;
            }
            return cost;
        }


        if (userCount <= 50)
        {
            for (int i = 1; i <= userCount; i++)
            {
                if (i <= 10) cost += 10.0;
                if (i >= 11) cost += 8.0;
            }
            if (isNonProfit)
            {
                cost = cost * 50.0 / 100.0;
            }
            return cost;
        }

        if (userCount > 50)
        {
            for (int i = 1; i <= userCount; i++)
            {
                if (i <= 10) cost += 10.0;
                if (i >= 11 && i <= 50) cost += 8.0;
                if (i > 50) cost += 5.0;
            }
            if (isNonProfit)
            {
                cost = cost * 50.0 / 100.0;
                return cost;
            }
        }
        return cost;
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
// Fonte: test/consegne/f/tegon_moira_clod_test_2026.cs
/* Esercizio 1 (30 Punti) - Calcolo Licenza Software

La funzione accetta il numero di utenti ed un flag no-profit, restituendo il costo mensile totale in Euro (double):
Se userCount <= 0 → restituisce 0.0.
Per i primi 10 utenti → 10.00€ ciascuno.
Da 11 a 50 utenti → primi 10 a 10.00€/cad, utenti da 11 a 50 a 8.00€/cad.
Oltre 50 utenti → primi 10 a 10.00€, da 11 a 50 a 8.00€, oltre 50 a 5.00€/cad.
Se isNonProfit == true, si applica uno sconto del 50% sul costo totale.
*/

// ### TESTS ###

Console.WriteLine(CalculateLicenseCost(-4, false)); // 0 OK
Console.WriteLine(CalculateLicenseCost(5, false));  // 50 OK
Console.WriteLine(CalculateLicenseCost(5, true));   // 25 OK
Console.WriteLine(CalculateLicenseCost(10, false)); // 100 OK
Console.WriteLine(CalculateLicenseCost(10, true));  // 50 OK
Console.WriteLine(CalculateLicenseCost(15, false)); // 
Console.WriteLine(CalculateLicenseCost(15, true));  //
Console.WriteLine(CalculateLicenseCost(48, false));
Console.WriteLine(CalculateLicenseCost(48, true));
Console.WriteLine(CalculateLicenseCost(60, false));
Console.WriteLine(CalculateLicenseCost(60, true));

// ### IMPLEMENTATION ###

double CalculateLicenseCost(int userCount, bool isNonProfit)
{
    if (userCount <= 0) return 0.0;

    double cost = 0;

    if (userCount <= 10)
    {
        cost = 10.0 * userCount;
        if (isNonProfit)
        {
            cost = cost * 50.0 / 100.0;
        }
        return cost;
    }


    if (userCount <= 50)
    {
        for(int i = 1; i <= userCount; i++)
        {
            if (i <= 10) cost += 10.0;
            if (i >= 11) cost += 8.0; 
        }
        if (isNonProfit)
        {
            cost = cost * 50.0 / 100.0;
        }
        return cost;
    }

    if (userCount > 50)
    {
        for(int i = 1; i <= userCount; i++)
        {
            if (i <= 10) cost += 10.0;
            if (i >= 11 && i <= 50) cost += 8.0;
            if (i > 50) cost += 5.0;
        }
        if (isNonProfit)
        {
            cost = cost * 50.0 / 100.0;
            return cost;
        }
    }
    return cost;
}

/*
Esercizio 2 (35 Punti) - Verifica Sequenza Strettamente Crescente
Scrivi la funzione:
bool IsStrictlyIncreasing(List<int> values)

La funzione accetta una lista di interi e restituisce true se ogni elemento è strettamente
 maggiore del precedente (values[i] > values[i-1]), false altrimenti. 
 Una lista vuota o di 1 solo elemento è considerata crescente (true).

*/

// ### TESTS ### 

Console.WriteLine(IsStrictlyIncreasing([0,1,2,3,4,5,6,7,8])); // True
Console.WriteLine(IsStrictlyIncreasing([8,7,6,5,4,3,2,1,0])); // False
Console.WriteLine(IsStrictlyIncreasing([]));                  // True
Console.WriteLine(IsStrictlyIncreasing([4]));                 // True


// ### IMPLEMENTATION ### 

bool IsStrictlyIncreasing(List<int> values)
{
    if (values.Count == 0 || values.Count == 1) return true;

    int i = 1;
    while (i < values.Count - 1)
    {
       if ( values[i] < values[i-1] ) return false;
       i++;
    }
    return true;
}


/*
Esercizio 3 (35 Punti) - Conteggio Frequenza Parole (Case-Insensitive)
Scrivi la funzione:
Dictionary<string, int> CountWordFrequencies(List<string> words)

La funzione accetta una lista di parole e restituisce una mappa 
con la frequenza di ciascuna parola convertita interamente in minuscolo 
(es. "Cloud" e "cloud" devono essere conteggiate insieme sotto la chiave "cloud").

*/

// ### TESTS ###

Dictionary<string,int> test0 = CountWordFrequencies(["Ciao", "ciao", "mappa", "Mappa", "mappa", "pc"]);
foreach(var (key,value) in test0)
{
    Console.WriteLine($"{key} : {value}");
}

Dictionary<string,int> test1 = CountWordFrequencies([""]);
foreach(var (key,value) in test1)
{
    Console.WriteLine($"{key} : {value}");
}

Dictionary<string,int> test2 = CountWordFrequencies(["Ciao", "ciao", "ciao", "Mappa", "", "pc"]);
foreach(var (key,value) in test2)
{
    Console.WriteLine($"{key} : {value}");
}


// ### IMPLEMENTATION ### 

Dictionary<string,int> CountWordFrequencies(List<string> words)
{
    if (words.Count == 0) return new();

    Dictionary<string,int> map = new();
    foreach(var word in words)
    {
        if (!String.IsNullOrEmpty(word)){
            if (map.ContainsKey(word.ToLower()))
            {
                map[word.ToLower()]++;
            }
            else
            {
                map.Add(word.ToLower(), 1);
            }
        }
    }

    return map;

}
#endif
