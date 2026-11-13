#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 20 — PINATO EDDY — Traccia B — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/b.cs.
// Fonte: test/consegne/b/PINATO_EDDY_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static Dictionary<string, List<string>> GroupUsersByRole(List<(string Name, string Role)> users);
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
// Fonte: test/consegne/b/PINATO_EDDY_clod_test_2026.cs

//esercizio 1

double CalculateStorageCost(int gbUsed, bool hasPromotion){

    if(gbUsed < 0){
        Console.WriteLine(-1.0);
    }elseif( gbUsed <=10);
    {
        Console.WriteLine(0.0 + "€");
    }elseif(gbUsed >= 11 && gbUsed <= 50);
    {
        Console.WriteLine(gbUsed * 1.50 + "€");
    }elseif(gbUsed > 50);
    {
        Console.WriteLine(gbUsed * 1.00 + "€");
    }
    if (hasPromotion == true)
    {
        Console.WriteLine(gbUsed * 0.8 + "€");
    }
}

//esercizio 2

bool HasLatencySpike(List<int> latencies);
{
    for(i = 0; i <= 3; i++)
    {
        if(latencies[i] >latencies[i+1])
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}

//esercizio 3

Dictionary<string, List<string>> GroupUsersByRole(List<(string Name,string Role)> users);




#endif
