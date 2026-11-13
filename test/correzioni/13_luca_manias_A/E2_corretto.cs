#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 13 — MANIAS LUCA — Traccia A — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Copia corretta: interventi minimi documentati qui sotto. Nessuna modifica algoritmica. Test invariati da test/a.cs.
// Fonte: test/consegne/a/Manias_Luca_clod_test_2026_Esercizio 2.cs
// Interventi: for: aggiunti int e separatori ; al posto di ,; LongCount sostituito con Count. Conservato il ritorno sul primo errore.
public static class ConsegnaStudente
{
    public static int FindLastServerErrorIndex(List<int> statusCodes)
    {
        for (int i = 0; i < statusCodes.Count; i++)
        {
            if (statusCodes[i] >= 500)
                return i;
        }

        return -1;
    }
}

[TestClass]
public class Esercizio2Tests
{
    [TestMethod]
    public void Should_ReturnMinusOne_When_ListIsEmpty()
    {
        Assert.AreEqual(-1, FindLastServerErrorIndex([]),
            "Regola: lista vuota deve restituire -1.");
    }

    [TestMethod]
    public void Should_ReturnMinusOne_When_NoServerErrorExists()
    {
        Assert.AreEqual(-1, FindLastServerErrorIndex([200, 201, 404, 499]),
            "Regola: nessun codice >= 500 presente.");
    }

    [TestMethod]
    public void Should_ReturnZero_When_ServerErrorIsAtFirstPosition()
    {
        Assert.AreEqual(0, FindLastServerErrorIndex([500, 200, 200]),
            "Regola: unico errore all'indice 0.");
    }

    [TestMethod]
    public void Should_ReturnLastIndex_When_MultipleServerErrorsExist()
    {
        Assert.AreEqual(3, FindLastServerErrorIndex([500, 200, 404, 502, 200]),
            "Regola: deve trovare l'ULTIMO errore nella lista (indice 3), non il primo.");
    }

    [TestMethod]
    public void Should_FindLastError_When_OnlySuccess()
    {
        Assert.AreEqual(-1, FindLastServerErrorIndex([200]));
    }

    [TestMethod]
    public void Should_FindLastError_When_Only499()
    {
        Assert.AreEqual(-1, FindLastServerErrorIndex([499]));
    }

    [TestMethod]
    public void Should_FindLastError_When_Only500()
    {
        Assert.AreEqual(0, FindLastServerErrorIndex([500]));
    }

    [TestMethod]
    public void Should_FindLastError_When_ErrorIsAtLastPosition()
    {
        Assert.AreEqual(2, FindLastServerErrorIndex([200, 404, 500]));
    }

    [TestMethod]
    public void Should_FindLastError_When_AllCodesAreErrors()
    {
        Assert.AreEqual(2, FindLastServerErrorIndex([500, 503, 502]));
    }

    [TestMethod]
    public void Should_FindLastError_When_ErrorsHaveIrregularPositions()
    {
        Assert.AreEqual(4, FindLastServerErrorIndex([200, 500, 200, 200, 503, 200]));
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/a/Manias_Luca_clod_test_2026_Esercizio 2.cs
//accetta una lista di codici HTTP e restituisce l'indice dell'ultimo codice relativo ad un errore
//se non è presente alcun errore nella lista deve restituire -1
//gli errori del server sono dal 500 in su
//devo usare un list lenght

int FindLastServerErrorIndex(List<int> statusCodes)
{
for (i = 0, i < statusCodes.LongCount, i++)
    {
        if (statusCodes[i] >= 500)
            return i;
    }

    return -1;
}


#endif
