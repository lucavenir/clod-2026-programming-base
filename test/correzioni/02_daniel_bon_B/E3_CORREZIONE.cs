#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 02 — BON DANIEL — Traccia B — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/b.cs.
// Fonte: test/consegne/b/Bon_Daniel_cloud_test_2026.cs
public static class ConsegnaStudente
{
    public static Dictionary<string, List<string>> GroupUsersByRole(List<(string Name, string Role)> users)
    {
        Dictionary<string, List<string>> Final = new();

        foreach (var element in users)
        {
            if (!Final.ContainsKey(element.Role))
                Final[element.Role] = new List<string>();
            Final[element.Role].Add(element.Name);
        }

        return Final;
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
// Fonte: test/consegne/b/Bon_Daniel_cloud_test_2026.cs
using System.Linq.Expressions;

int gbUsed=60;

bool hasPromotion=false;

Console.WriteLine($"The final cost of your {gbUsed} GB is :{CalculateStorageCost(gbUsed,hasPromotion)} dollars");


double CalculateStorageCost(int gbUsed, bool hasPromotion){

    /*Se gbUsed < 0 → restituisce -1.0.
    Fino a 10 GB compresi → 0.0€.
    Da 11 a 50 GB compresi → i GB oltre i 10 costano 1.50€ al GB.
    Oltre i 50 GB → i primi 10 gratis, da 11 a 50 costano 1.50€/GB (totale 60€), e ogni GB oltre 50 costa 1.00€/GB.
    Se hasPromotion == true, viene applicato uno sconto del 20% sul totale finale calcolato.
    */
    
    double final_cost = 0;
    if(gbUsed<0)
            return -1;
        else if(gbUsed<=10)
            return 0;
            else if(gbUsed<=50)
                final_cost = ((gbUsed - 10)*1.5);
                else final_cost = (gbUsed +50);

    if(hasPromotion==true)
        final_cost*=0.2;

    return final_cost;
}

List<int> latencies = [10, 20, 80, 85];

Console.WriteLine($"The control of latency skies has returned: {HasLatencySpike(latencies)}");

bool HasLatencySpike(List<int> latencies){

    int preweus_element=0;

    if(latencies.Count<2)
        return false;
    
    foreach(var element in latencies){
        if(((element-preweus_element)>50)&&element!=latencies[0])
            return true;
        preweus_element=element;
    }
    return false;
}

List<(string Name, string Role)> users = [
    ("Nome","Ruolo"),
    ("AAAA","Ruolo"),
    ("BBBB","Si"),
];

foreach(var element in GroupUsersByRole(users))
{
    Console.WriteLine($"{element.Key}: {string.Join(", ",element.Value)}");
}

Dictionary<string, List<string>> GroupUsersByRole(List<(string Name, string Role)> users){
    Dictionary<string,List<string>> Final = new();

    foreach(var element in users){
        if (!Final.ContainsKey(element.Role))
            Final[element.Role]= new List<string>();
        Final[element.Role].Add(element.Name);
    } 

    return Final;
}

#endif
