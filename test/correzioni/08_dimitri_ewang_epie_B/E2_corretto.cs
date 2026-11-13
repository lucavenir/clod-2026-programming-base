#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 08 — EPIE DIMITRI EWANG — Traccia B — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Copia corretta: interventi minimi documentati qui sotto. Nessuna modifica algoritmica. Test invariati da test/b.cs.
// Fonte: test/consegne/b/epie_dimitriewang_clod_test_2026.cs
// Interventi: Corretta solo la stampa di due interi usando interpolazione. Algoritmo invariato.
public static class ConsegnaStudente
{
    public static bool HasLatencySpike(List<int> latencies)
    {
        bool ItHasLatencies = true;
        if (latencies.Count < 2 || ItHasLatencies)
            return !ItHasLatencies;

        for (var i = 0; i < latencies.Count; i++)
        {
            if (latencies[i + 1] / 50 == 0)
            {
                Console.WriteLine($"{latencies[i]}, {latencies[i + 1]}");
                ItHasLatencies = true;
            }

        }
        return ItHasLatencies;
    }
}

[TestClass]
public class Esercizio2Tests
{
    [TestMethod]
    public void Should_ReturnFalse_When_ListHasLessThanTwoElements()
    {
        Assert.IsFalse(HasLatencySpike([100]),
            "Regola: servono almeno 2 misurazioni per calcolare un salto.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_JumpIsExactly50Ms()
    {
        Assert.IsFalse(HasLatencySpike([10, 60]),
            "Regola di confine: incremento di 50 ms non basta, deve essere STRETTAMENTE > 50 ms.");
    }

    [TestMethod]
    public void Should_ReturnTrue_When_JumpExceeds50Ms()
    {
        Assert.IsTrue(HasLatencySpike([10, 61]),
            "Regola: incremento di 51 ms deve far scattare lo spike.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_LatencyDecreases()
    {
        Assert.IsFalse(HasLatencySpike([100, 20]),
            "Regola: un calo improvviso di latenza non è uno spike.");
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_Empty()
    {
        Assert.AreEqual(false, HasLatencySpike([]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_JumpAtLastPair()
    {
        Assert.AreEqual(true, HasLatencySpike([10, 20, 80]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_JumpAtFirstPair()
    {
        Assert.AreEqual(true, HasLatencySpike([10, 80, 85]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_EqualMeasurements()
    {
        Assert.AreEqual(false, HasLatencySpike([100, 100, 100]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_AllJumpsBelowThreshold()
    {
        Assert.AreEqual(false, HasLatencySpike([10, 20, 30, 40]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_PeakEqualsFirstMeasurement()
    {
        Assert.AreEqual(true, HasLatencySpike([100, 10, 100]));
    }

    [TestMethod]
    public void Should_RejectExactly50MsJump_InsideLongerList()
    {
        Assert.IsFalse(HasLatencySpike([10, 60, 70]));
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/b/epie_dimitriewang_clod_test_2026.cs
/*
    Esercizio 1 (30 Punti) - Calcolo Costo Storage Cloud
Scrivi la funzione:
double CalculateStorageCost(int gbUsed, bool hasPromotion)

La funzione accetta i GigaByte utilizzati e un booleano per l'applicazione di una promozione, restituendo il costo totale in Euro (double):
Se gbUsed < 0 → restituisce -1.0.
Fino a 10 GB compresi → 0.0€.
Da 11 a 50 GB compresi → i GB oltre i 10 costano 1.50€ al GB.
Oltre i 50 GB → i primi 10 gratis, da 11 a 50 costano 1.50€/GB (totale 60€), e ogni GB oltre 50 costa 1.00€/GB.
Se hasPromotion == true, viene applicato uno sconto del 20% sul totale finale calcolato.

*/

using System.Reflection.Metadata;

double CalculateStorageCost(int gbUsed, bool hasPromotion)
{
    double cost = 0.0;

    if(gbUsed < 0)
        cost = -1.0;
        
    if(gbUsed > 0 && gbUsed <= 10)
        cost = 0.0;
        
    if(gbUsed > 10 && gbUsed <= 50)
        {
            for(var i = 10; i<=gbUsed; i++)
                cost += 1.50;
            
        }
    if(gbUsed > 50)
        {
        cost = 60.0;
        for(var i = 10; i<=gbUsed; i++)
                cost += 1.0;
        }

    if (hasPromotion)
        cost = cost/100*20;

    return cost;
}

/*Esercizio 2 (35 Punti) - Rilevamento Spike di Latenza
Scrivi la funzione:
bool HasLatencySpike(List<int> latencies)

La funzione accetta una lista di misurazioni di latenza in ms e restituisce true se esiste almeno un salto tra due elementi 
consecutivi (latencies[i] e latencies[i+1]) dove il secondo supera il primo di oltre 50 ms.
Se la lista ha meno di 2 elementi o non rileva picchi, restituisce false.

Esempio: [10, 20, 80, 85] → restituisce true (da 20 a 80 c'è un salto di 60 ms).
*/

bool HasLatencySpike(List<int> latencies)
{
    bool ItHasLatencies = true;
    if(latencies.Count < 2 || ItHasLatencies)
        return !ItHasLatencies;

    for(var i = 0; i<latencies.Count; i++)
    {
        if(latencies[i+1]/50 == 0)
        {
            Console.WriteLine(latencies[i], latencies[i+1]);
            ItHasLatencies = true;
        }
            
    }
    return ItHasLatencies;
}

/*Esercizio 3 (35 Punti) - Raggruppamento Utenti per Ruolo
Scrivi la funzione:
Dictionary<string, List<string>> GroupUsersByRole(List<(string Name, string Role)> users)

La funzione accetta una lista di tuple (Name, Role) e restituisce una mappa dove ogni Ruolo (chiave)
è associato alla lista dei Nomi degli utenti che possiedono quel ruolo.
*/

Dictionary<string, List<string>> GroupUsersByRole(List<(string Name, string Role)> users)

{
    Dictionary<string, List<string>> RoleAndUsers;

    List<string> ListOfNames = [];
    ListOfNames.Add(users.Name);
    RoleAndUsers.Add(users.Role, ListOfNames);
    foreach(var e in RoleAndUsers)
    {
        if(e.containsKey(users.Role))
        {
            return e;
        }
    }
    
    return RoleAndUsers;

}



#endif
