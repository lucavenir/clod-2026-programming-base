#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 14 — MASTRO CLAUDIO — Traccia B — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/b.cs.
// Fonte: test/consegne/b/mastro_claudio_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static Dictionary<string, List<string>> GroupUsersByRole(List<(string Name, string Role)> users)
    {
        var result = new Dictionary<string, List<string>>();

        foreach (var user in users)
        {
            if (!result.ContainsKey(user.Role))
                result.Add(user.Role, []);

            result[user.Role].Add(user.Name);
        }

        return result;
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
// Fonte: test/consegne/b/mastro_claudio_clod_test_2026.cs
Dictionary<string, List<string>> GroupUsersByRole(List<(string Name, string Role)> users)
{
   var result = new Dictionary<string, List<string>>();

    foreach (var user in users)
    {
        if (!result.ContainsKey(user.Role))
            result.Add(user.Role, []);

        result[user.Role].Add(user.Name);
    }

    return result;
}


bool HasLatencySpike(List<int> latencies)
{

    if (latencies.Count() < 2)
        return false;

    for(var i=1; i<latencies.Count()-1; i++)
    {
        if (latencies[i] > latencies[i-1])
        {
            if (latencies[i] - latencies[i-1] >= 50)
                return true;
        }
            
    }

    return false;
}

double CalculateStorageCost(int gbUsed, bool hasPromotion)
{
    double price = 0;

    if (gbUsed<0)
        price = -1;

        else if (gbUsed<=10 && gbUsed>0)
            price = 0.0;

            else if (gbUsed>10 && gbUsed<=50)
                price = (gbUsed-10)*1.5;
            
                else if(gbUsed > 50)
                    price = 10 + gbUsed;   //* 10 perchè alla fine se da 0 a 50 sono 60$ e devo sottrarre
                                            //* i 50 giga che non calcolo nel prezzo il risultato è quello

    if (hasPromotion)
         price = price * 0.8;

        return price;
} 


#endif
