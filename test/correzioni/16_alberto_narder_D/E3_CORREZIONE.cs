#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 16 — NARDER ALBERTO — Traccia D — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/d.cs.
// Fonte: test/consegne/d/narder_esercizio_3.cs
public static class ConsegnaStudente
{
    Dictionary<string> ValidateApiKeyAccess = new Dictionary<string, string>();
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
// Fonte: test/consegne/d/narder_esercizio_3.cs
Dictionary<string> ValidateApiKeyAccess = new Dictionary<string, string>();

#endif
