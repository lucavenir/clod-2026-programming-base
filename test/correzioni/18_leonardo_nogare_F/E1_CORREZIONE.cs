#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 18 — NOGARÈ LEONARDO — Traccia F — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/f.cs.
// Fonte: test/consegne/f/nogarè_leonardo_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static double CalculateLicenseCost(int userCount, bool isNonProfit) //funzione che calcola il costo delle chiavi in base al numero di utenti e agli eventuali sconti
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
