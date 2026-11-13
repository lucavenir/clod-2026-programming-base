#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 08 — EPIE DIMITRI EWANG — Traccia B — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/b.cs.
// Fonte: test/consegne/b/epie_dimitriewang_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static Dictionary<string, List<string>> GroupUsersByRole(List<(string Name, string Role)> users)

    {
        Dictionary<string, List<string>> RoleAndUsers;

        List<string> ListOfNames = [];
        ListOfNames.Add(users.Name);
        RoleAndUsers.Add(users.Role, ListOfNames);
        foreach (var e in RoleAndUsers)
        {
            if (e.containsKey(users.Role))
            {
                return e;
            }
        }

        return RoleAndUsers;

    }
}

[TestClass]
public class Esercizio3Tests
{
    [TestMethod]
    public void Should_ReturnEmptyDictionary_When_UserListIsEmpty()
    {
        var result = GroupUsersByRole([]);
        Assert.AreEqual(0, result.Count,
            "Regola: lista vuota produce mappa vuota.");
    }

    [TestMethod]
    public void Should_GroupUsersCorrectly_ByRole()
    {
        var result = GroupUsersByRole([("Luca", "ADMIN"), ("Anna", "USER"), ("Marco", "ADMIN")]);

        Assert.AreEqual(2, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "Luca", "Marco" }, result["ADMIN"]);
        CollectionAssert.AreEquivalent(new List<string> { "Anna" }, result["USER"]);
    }

    [TestMethod]
    public void Should_GroupAllUsers_When_SingleUser()
    {
        var result = GroupUsersByRole([("Luca", "ADMIN")]);
        Assert.AreEqual(1, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "Luca" }, result["ADMIN"]);
    }

    [TestMethod]
    public void Should_GroupAllUsers_When_OneRole()
    {
        var result = GroupUsersByRole([("Anna", "USER"), ("Marco", "USER"), ("Sara", "USER")]);
        Assert.AreEqual(1, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "Anna", "Marco", "Sara" }, result["USER"]);
    }

    [TestMethod]
    public void Should_GroupAllUsers_When_AllRolesDiffer()
    {
        var result = GroupUsersByRole([("A", "ADMIN"), ("B", "USER"), ("C", "GUEST")]);
        Assert.AreEqual(3, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "A" }, result["ADMIN"]);
        CollectionAssert.AreEquivalent(new List<string> { "B" }, result["USER"]);
        CollectionAssert.AreEquivalent(new List<string> { "C" }, result["GUEST"]);
    }

    [TestMethod]
    public void Should_GroupAllUsers_When_RolesAreInterleaved()
    {
        var result = GroupUsersByRole([("A", "USER"), ("B", "ADMIN"), ("C", "USER"), ("D", "ADMIN")]);
        Assert.AreEqual(2, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "A", "C" }, result["USER"]);
        CollectionAssert.AreEquivalent(new List<string> { "B", "D" }, result["ADMIN"]);
    }

    [TestMethod]
    public void Should_GroupAllUsers_When_DuplicateUsers()
    {
        var result = GroupUsersByRole([("Luca", "ADMIN"), ("Luca", "ADMIN")]);
        Assert.AreEqual(1, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "Luca", "Luca" }, result["ADMIN"]);
    }

    [TestMethod]
    public void Should_GroupAllUsers_When_UnknownRole()
    {
        var result = GroupUsersByRole([("Bot", "SERVICE")]);
        Assert.AreEqual(1, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "Bot" }, result["SERVICE"]);
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
