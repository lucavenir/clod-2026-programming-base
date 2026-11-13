#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 04 — CECHET DEVIS — Traccia D — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/d.cs.
// Fonte: test/consegne/d/cechet_devis_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static bool ValidateApiKeyAccess(Dictionary<string, string> apiKeyMap, string apiKey, string requiredRole)
    {
        foreach (var element in apiKeyMap)
        {
            if (element.Key == apiKey)
            {
                if (element.Value == requiredRole)
                {
                    return true;
                }
            }
        }

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
// Fonte: test/consegne/d/cechet_devis_clod_test_2026.cs
//ESERCIZIO 1 - Categorizzazione Eventi di Sistema

string CategorizeEventCode(int eventCode)
{
    if (eventCode <= 0)
    {
        return "INVALID";
    }

    if (eventCode % 4 == 0 && eventCode % 6 == 0)
    {
        return "CRITICAL_SYS_APP";
    } else if (eventCode % 4 == 0 && eventCode % 6 != 0)
    {
        return "SYS";
    } else if (eventCode % 6 == 0 && eventCode % 4 != 0)
    {
        return "APP";
    }

    return eventCode.ToString();
}

//ESERCIZIO 2 - Somma Elementi di Indice Dispari

int SumOddIndexElements(List<int> numbers)
{
    var sum = 0;

    for (int i = 0; i < numbers.Count; i++)
    {
        if (i % 2 != 0)
        {
            sum += numbers[i];
        }
    }

    return sum;
}

//ESERCIZIO 3 - Verifica Permessi API Key

bool ValidateApiKeyAccess(Dictionary<string, string> apiKeyMap, string apiKey, string requiredRole)
{
    foreach (var element in apiKeyMap)
    {
        if (element.Key == apiKey)
        {
            if (element.Value == requiredRole)
            {
                return true;
            }
        }
    }

    return false;
}
#endif
