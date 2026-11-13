#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 16 — NARDER ALBERTO — Traccia D — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/d.cs.
// Fonte: test/consegne/d/narder_esercizio_2.cs
public static class ConsegnaStudente
{
    List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];


foreach(int n in numbers)
{
    
if(i % 2 == 0)
    i = i +1;

else

int results = sum[i];


}
}

[TestClass]
public class Esercizio2Tests
{
    [TestMethod]
    public void Should_SumOnlyOddIndices()
    {
        Assert.AreEqual(60, SumOddIndexElements([10, 20, 30, 40, 50]),
            "Regola: deve sommare gli elementi agli indici 1 (20) e 3 (40).");
    }

    [TestMethod]
    public void Should_ReturnZero_When_NoOddIndicesExist()
    {
        Assert.AreEqual(0, SumOddIndexElements([100]),
            "Regola: lista con 1 solo elemento ha solo l'indice 0 (pari).");
    }

    [TestMethod]
    public void Should_ReturnZero_When_ListIsEmpty()
    {
        Assert.AreEqual(0, SumOddIndexElements([]),
            "Regola: lista vuota ha somma 0.");
    }

    [TestMethod]
    public void Should_SumOddPositions_When_TwoElements()
    {
        Assert.AreEqual(20, SumOddIndexElements([10, 20]));
    }

    [TestMethod]
    public void Should_SumOddPositions_When_EvenLength()
    {
        Assert.AreEqual(60, SumOddIndexElements([10, 20, 30, 40]));
    }

    [TestMethod]
    public void Should_SumOddPositions_When_OddValuesAtEvenIndices()
    {
        Assert.AreEqual(6, SumOddIndexElements([1, 2, 3, 4, 5]));
    }

    [TestMethod]
    public void Should_SumOddPositions_When_NegativeElements()
    {
        Assert.AreEqual(-60, SumOddIndexElements([10, -20, 30, -40]));
    }

    [TestMethod]
    public void Should_SumOddPositions_When_Zeros()
    {
        Assert.AreEqual(0, SumOddIndexElements([0, 0, 0, 0]));
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/d/narder_esercizio_2.cs
List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];


foreach(int n in numbers)
{
    
if(i % 2 == 0)
    i = i +1;

else

int results = sum[i];


}
#endif
