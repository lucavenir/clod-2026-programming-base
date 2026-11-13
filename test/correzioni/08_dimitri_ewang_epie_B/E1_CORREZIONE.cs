#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 08 — EPIE DIMITRI EWANG — Traccia B — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/b.cs.
// Fonte: test/consegne/b/epie_dimitriewang_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static double CalculateStorageCost(int gbUsed, bool hasPromotion)
    {
        double cost = 0.0;

        if (gbUsed < 0)
            cost = -1.0;

        if (gbUsed > 0 && gbUsed <= 10)
            cost = 0.0;

        if (gbUsed > 10 && gbUsed <= 50)
        {
            for (var i = 10; i <= gbUsed; i++)
                cost += 1.50;

        }
        if (gbUsed > 50)
        {
            cost = 60.0;
            for (var i = 10; i <= gbUsed; i++)
                cost += 1.0;
        }

        if (hasPromotion)
            cost = cost / 100 * 20;

        return cost;
    }
}

[TestClass]
public class Esercizio1Tests
{
    [TestMethod]
    public void Should_ReturnMinusOne_When_GbIsNegative()
    {
        Assert.AreEqual(-1.0, CalculateStorageCost(-1, false), 0.001,
            "Regola: GB negativi non sono ammessi.");
    }

    [TestMethod]
    public void Should_ReturnZero_When_GbIsUpTo10()
    {
        Assert.AreEqual(0.0, CalculateStorageCost(10, false), 0.001,
            "Regola: fino a 10 GB compresi il servizio è gratuito.");
    }

    [TestMethod]
    public void Should_Charge150PerGb_When_GbBetween11And50()
    {
        Assert.AreEqual(1.50, CalculateStorageCost(11, false), 0.001,
            "Regola: 11 GB = 1 GB eccedente a 1.50€.");
    }

    [TestMethod]
    public void Should_ChargeCorrectly_When_GbExceeds50()
    {
        Assert.AreEqual(61.0, CalculateStorageCost(51, false), 0.001,
            "Regola: 51 GB = 60€ (fascia 11-50) + 1.00€ (1 GB oltre 50).");
    }

    [TestMethod]
    public void Should_Apply20PercentDiscount_When_PromotionIsTrue()
    {
        Assert.AreEqual(48.0, CalculateStorageCost(50, true), 0.001,
            "Regola: 60€ con promozione -20% diventa 48€.");
    }

    [TestMethod]
    public void Should_CalculateStorage_When_NegativeWithPromotion()
    {
        Assert.AreEqual(-1.0, CalculateStorageCost(-1, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_Zero()
    {
        Assert.AreEqual(0.0, CalculateStorageCost(0, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_FreeWithPromotion()
    {
        Assert.AreEqual(0.0, CalculateStorageCost(10, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_Exactly50()
    {
        Assert.AreEqual(60.0, CalculateStorageCost(50, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_FarAbove50()
    {
        Assert.AreEqual(90.0, CalculateStorageCost(80, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_PromotionInMiddleRange()
    {
        Assert.AreEqual(1.2, CalculateStorageCost(11, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_PromotionAbove50()
    {
        Assert.AreEqual(48.8, CalculateStorageCost(51, true), 0.001);
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
