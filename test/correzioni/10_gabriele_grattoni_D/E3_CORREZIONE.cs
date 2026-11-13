#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 10 — GRATTONI GABRIELE — Traccia D — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/d.cs.
// Fonte: test/consegne/d/grattoni_gabriele_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static bool ValidateApiKeyAccess(Dictionary<string, string> apiKeyMap, string apiKey, string requiredRole)
    {

        if (apiKeyMap.ContainsKey(apiKey))

            if (apiKeyMap[apiKey] == requiredRole)

                return true;

        return false;

    }
}

[TestClass]
public class Esercizio3Tests
{
    [TestMethod]
    public void Should_ReturnTrue_When_KeyAndRoleMatch()
    {
        var db = new Dictionary<string, string> { { "key123", "ADMIN" } };
        Assert.IsTrue(ValidateApiKeyAccess(db, "key123", "ADMIN"),
            "Regola: chiave presente e ruolo corrispondente.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_RoleDoesNotMatch()
    {
        var db = new Dictionary<string, string> { { "key123", "ADMIN" } };
        Assert.IsFalse(ValidateApiKeyAccess(db, "key123", "USER"),
            "Regola: chiave presente ma ruolo differente.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_KeyDoesNotExist()
    {
        Assert.IsFalse(ValidateApiKeyAccess([], "key999", "ADMIN"),
            "Regola: chiave non presente in mappa.");
    }

    [TestMethod]
    public void Should_CheckExactAccess_When_MatchingKeyIsNotFirst()
    {
        var db = new Dictionary<string, string> { { "other", "USER" }, { "target", "ADMIN" } };
        Assert.AreEqual(true, ValidateApiKeyAccess(db, "target", "ADMIN"));
    }

    [TestMethod]
    public void Should_CheckExactAccess_When_WrongKeyHasRequiredRole()
    {
        var db = new Dictionary<string, string> { { "other", "ADMIN" }, { "target", "USER" } };
        Assert.AreEqual(false, ValidateApiKeyAccess(db, "target", "ADMIN"));
    }

    [TestMethod]
    public void Should_CheckExactAccess_When_MissingKeyInNonEmptyMap()
    {
        var db = new Dictionary<string, string> { { "other", "ADMIN" } };
        Assert.AreEqual(false, ValidateApiKeyAccess(db, "missing", "ADMIN"));
    }

    [TestMethod]
    public void Should_CheckExactAccess_When_MatchingNonAdminRole()
    {
        var db = new Dictionary<string, string> { { "target", "EDITOR" } };
        Assert.AreEqual(true, ValidateApiKeyAccess(db, "target", "EDITOR"));
    }

    [TestMethod]
    public void Should_CheckExactAccess_When_MatchingKeyIsFirstAmongSeveral()
    {
        var db = new Dictionary<string, string> { { "target", "ADMIN" }, { "other", "USER" } };
        Assert.AreEqual(true, ValidateApiKeyAccess(db, "target", "ADMIN"));
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/d/grattoni_gabriele_clod_test_2026.cs
//es 1
System.Console.WriteLine("ES_1");
System.Console.WriteLine(CategorizeEventCode(-6)); //invalid
System.Console.WriteLine(CategorizeEventCode(12)); //CRITICAL_SYS_APP
System.Console.WriteLine(CategorizeEventCode(8));  //SYS
System.Console.WriteLine(CategorizeEventCode(18)); //APP
System.Console.WriteLine(CategorizeEventCode(7));  //"7"

//es 2
System.Console.WriteLine("\nES_2");
List<int> data = [10, 20, 30, 40, 50];
System.Console.WriteLine(SumOddIndexElements(data).ToString()); //20 + 40 = 60

//es 3
Dictionary<string, string> apiData = new();
apiData.Add("marco", "polo");
apiData.Add("quattro", "cinque");
apiData.Add("otto", "nove");

System.Console.WriteLine("\nES_3");
System.Console.WriteLine(ValidateApiKeyAccess(apiData, "gabriele", "grattoni")); //false, false => false
System.Console.WriteLine(ValidateApiKeyAccess(apiData, "marco", "pala")); //true, false => false
System.Console.WriteLine(ValidateApiKeyAccess(apiData, "quattro", "cinque")); //true, true => true


String CategorizeEventCode(int eventCode)
{
    if (eventCode <= 0)
        return ("INVALID");

    if (eventCode % 4 == 0 && eventCode % 6 == 0)
        return ("CRITICAL_SYS_APP");
    else
    {

        if (eventCode % 4 == 0)
            return ("SYS");

        if (eventCode % 6 == 0)
            return ("APP");

    }

    return (eventCode.ToString());

}

int SumOddIndexElements(List<int> numbers)
{
    int sum = 0;

    for (var i = 0; i < numbers.Count; i++)

        if (!(i % 2 == 0))
            sum += numbers[i];

    return sum;

}


bool ValidateApiKeyAccess(Dictionary<string, string> apiKeyMap, string apiKey, string requiredRole)
{

    if (apiKeyMap.ContainsKey(apiKey))

        if (apiKeyMap[apiKey] == requiredRole)

            return true;

    return false;

}


#endif
