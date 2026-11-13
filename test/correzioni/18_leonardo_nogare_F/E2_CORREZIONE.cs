#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 18 — NOGARÈ LEONARDO — Traccia F — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/f.cs.
// Fonte: test/consegne/f/nogarè_leonardo_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static bool IsStrictlyIncreasing(List<int> values) //funzione che data una lista di interi mi dice se i valori sono strettamente crescenti o meno
    {
        if (values.Count() <= 1)  //se ho zero valori o uno solo
        {
            return true; //ritorno vero da indicazione
        }

        for (int i = 1; i < values.Count(); i++) //scandisco tutti i valori della lista a partire dal secondo in quanto ciascuno lo confronto con quello prima (altrimenti se partissi da 0 cercherei di confrontarlo con l'elemento -1, che non esiste logicamente)
        {
            if (!(values[i - 1] < values[i])) //se il valore in posizione i NON è strettamente maggiore del precedente (quindi maggiore o uguale)
            {
                return false; //ritorno falso e termino la funzione
            }
        }
        return true; //se sono arrivato fino a qui vuol dire che gli elementi erano tutti strettamente maggiori del precedente, quindi posso ritornare true
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
// Fonte: test/consegne/f/nogarè_leonardo_clod_test_2026.cs
/*
//TEST PER FUNZIONE CalculateLicenseCost
Console.WriteLine(CalculateLicenseCost(0, false));
Console.WriteLine(CalculateLicenseCost(0, true));
Console.WriteLine(CalculateLicenseCost(1, false));
Console.WriteLine(CalculateLicenseCost(1, true));
Console.WriteLine(CalculateLicenseCost(10, false));
Console.WriteLine(CalculateLicenseCost(10, true));
Console.WriteLine(CalculateLicenseCost(11, false));
Console.WriteLine(CalculateLicenseCost(11, true));
Console.WriteLine(CalculateLicenseCost(50, false));
Console.WriteLine(CalculateLicenseCost(50, true));
Console.WriteLine(CalculateLicenseCost(51, false));
Console.WriteLine(CalculateLicenseCost(51, true));
Console.WriteLine(CalculateLicenseCost(100, false));
Console.WriteLine(CalculateLicenseCost(100, true));
*/

/*
//TEST PER FUNZIONE IsStrictlyIncreasing
List <int> input = [];
Console.WriteLine(IsStrictlyIncreasing(input));
input = [1];
Console.WriteLine(IsStrictlyIncreasing(input));
input = [1,2,3];
Console.WriteLine(IsStrictlyIncreasing(input));
input = [1,2,2,3];
Console.WriteLine(IsStrictlyIncreasing(input));
input = [1,0,2,1];
Console.WriteLine(IsStrictlyIncreasing(input));
*/


//TEST PER FUNZIONE CountWordFrequencies
/*
Console.WriteLine();

List <string> input = [];
Dictionary <string, int> output = CountWordFrequencies (input);
Console.WriteLine("Computazione elementi presenti nella lista: " + String.Join(", ", input));
foreach(KeyValuePair <string, int> element in output)
{
    Console.WriteLine("La parola: " + element.Key + " è presente nella lista " + element.Value + " volte!");
}
Console.WriteLine();

input = ["ciao", "ciao"];
output = CountWordFrequencies (input);
Console.WriteLine("Computazione elementi presenti nella lista: " + String.Join(", ", input));
foreach(KeyValuePair <string, int> element in output)
{
    Console.WriteLine("La parola: " + element.Key + " è presente nella lista " + element.Value + " volte!");
}
Console.WriteLine();

input = ["cIao", "CiaO"];
output = CountWordFrequencies (input);
Console.WriteLine("Computazione elementi presenti nella lista: " + String.Join(", ", input));
foreach(KeyValuePair <string, int> element in output)
{
    Console.WriteLine("La parola: " + element.Key + " è presente nella lista " + element.Value + " volte!");
}
Console.WriteLine();

input = ["ciao", "ciao", "CIao", "ei", "eI", "Ei", "hello", "HelLO"];
output = CountWordFrequencies (input);
Console.WriteLine("Computazione elementi presenti nella lista: " + String.Join(", ", input));
foreach(KeyValuePair <string, int> element in output)
{
    Console.WriteLine("La parola: " + element.Key + " è presente nella lista " + element.Value + " volte!");
}
Console.WriteLine();
*/

double CalculateLicenseCost(int userCount, bool isNonProfit) //funzione che calcola il costo delle chiavi in base al numero di utenti e agli eventuali sconti
{
    double price = 0.0; //inizializzo il prezzo a 0

    if (userCount <= 0) //se il numero di utenti è minore o uguale a 0
    {
        return price; //ritorno price che è ancora a 0
    }

    if (userCount <= 10) //se il numero di utenti è minore o uguale a 10
    {
        price = userCount * 10; //calcolo il prezzo moltiplicando il numero di utenti per 10
    }

    if (11 <= userCount && userCount <= 50) //se il numero di utenti è tra 11 e 50
    {
        price = (10 * 10) + (userCount - 10) * 8;  //calcolo il prezzo con le prime 10 licenze che costano 10 cadauna e quelle oltre le 10 che costano 8 cadauna
    }

    if (userCount > 50) //se il numero di utenti è maggiore di 50
    {
        price = (10 * 10) + (40 * 8) + (userCount - 50) * 5; //calcolo il prezzo con le prime 10 licenze a 10 cadauna, quelle oltre la decima e prima della cinquantesima a 8 cadauna e le rimanenti oltre 50 a 5 cadauna
    }

    if (isNonProfit) //se è una non profit
    {
            price *= 0.5; //ha lo sconto 50% su quanto calcolato prima
    }

    return price; //ritorno price
}


bool IsStrictlyIncreasing(List<int> values) //funzione che data una lista di interi mi dice se i valori sono strettamente crescenti o meno
{
    if(values.Count() <= 1)  //se ho zero valori o uno solo
    {
        return true; //ritorno vero da indicazione
    }

    for (int i = 1; i < values.Count(); i++) //scandisco tutti i valori della lista a partire dal secondo in quanto ciascuno lo confronto con quello prima (altrimenti se partissi da 0 cercherei di confrontarlo con l'elemento -1, che non esiste logicamente)
    {
        if (!(values[i - 1] < values[i])) //se il valore in posizione i NON è strettamente maggiore del precedente (quindi maggiore o uguale)
        {
            return false; //ritorno falso e termino la funzione
        }
    }
    return true; //se sono arrivato fino a qui vuol dire che gli elementi erano tutti strettamente maggiori del precedente, quindi posso ritornare true
}


Dictionary<string, int> CountWordFrequencies(List<string> words) //funzione che calcola la ricorrenza delle parole presenti in una lista, case insensitive
{
    var frequencies = new Dictionary<string, int>();//inizializzo una mappa di chiavi stringhe e valori interi

    if (words.Count() <= 0) //se ho come input una lista vuota
    {
        Console.WriteLine("Lista vuota!!"); //stampo avviso
        return frequencies; //ritorno mappa vuota
    }

    foreach(string word in words) //per ogni stringa word presente nella lista di stringhe words
    {
        if (!frequencies.ContainsKey(word.ToLower())) //se l'elemento word tutto in minuscolo NON è presente come chiave nella mappa
        {
            frequencies [word.ToLower()] = 1; //setto il valore a 1 in quanto è la prima volta che leggo tale stringa
        }
        else //altrimenti
        {
            frequencies [word.ToLower()]++; //aumento di uno il valore presente
        }
    }
    return frequencies; //ritorno al chiamante la mappa compilata
}
#endif
