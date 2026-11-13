#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 24 — TEGON MOIRA — Traccia F — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/f.cs.
// Fonte: test/consegne/f/tegon_moira_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static bool IsStrictlyIncreasing(List<int> values)
    {
        if (values.Count == 0 || values.Count == 1) return true;

        int i = 1;
        while (i < values.Count - 1)
        {
            if (values[i] < values[i - 1]) return false;
            i++;
        }
        return true;
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
