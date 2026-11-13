#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 05 — CHAKICH MOHAMAD — Traccia E — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/e.cs.
// Esercizio assente dai sorgenti consegnati.
public static class ConsegnaStudente
{
#error Esercizio 3 non consegnato: nessuna implementazione presente.
}

[TestClass]
public class Esercizio3Tests
{
    [TestMethod]
    public void Should_ReturnEmptyDictionary_When_IpRecordsListIsEmpty()
    {
        var result = GroupIpsByCountry([]);
        Assert.AreEqual(0, result.Count,
            "Regola: lista vuota produce mappa vuota.");
    }

    [TestMethod]
    public void Should_GroupIpsByCountryCode()
    {
        var result = GroupIpsByCountry([("1.1.1.1", "IT"), ("8.8.8.8", "US"), ("2.2.2.2", "IT")]);

        Assert.AreEqual(2, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "1.1.1.1", "2.2.2.2" }, result["IT"]);
        CollectionAssert.AreEquivalent(new List<string> { "8.8.8.8" }, result["US"]);
    }

    [TestMethod]
    public void Should_GroupEveryIp_When_SingleIp()
    {
        var result = GroupIpsByCountry([("1.1.1.1", "IT")]);
        Assert.AreEqual(1, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "1.1.1.1" }, result["IT"]);
    }

    [TestMethod]
    public void Should_GroupEveryIp_When_OneCountry()
    {
        var result = GroupIpsByCountry([("1.1.1.1", "IT"), ("2.2.2.2", "IT")]);
        Assert.AreEqual(1, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "1.1.1.1", "2.2.2.2" }, result["IT"]);
    }

    [TestMethod]
    public void Should_GroupEveryIp_When_DifferentCountries()
    {
        var result = GroupIpsByCountry([("1.1.1.1", "IT"), ("8.8.8.8", "US"), ("9.9.9.9", "DE")]);
        Assert.AreEqual(3, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "1.1.1.1" }, result["IT"]);
        CollectionAssert.AreEquivalent(new List<string> { "8.8.8.8" }, result["US"]);
        CollectionAssert.AreEquivalent(new List<string> { "9.9.9.9" }, result["DE"]);
    }

    [TestMethod]
    public void Should_GroupEveryIp_When_InterleavedCountries()
    {
        var result = GroupIpsByCountry([("1.1.1.1", "IT"), ("8.8.8.8", "US"), ("2.2.2.2", "IT"), ("4.4.4.4", "US")]);
        Assert.AreEqual(2, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "1.1.1.1", "2.2.2.2" }, result["IT"]);
        CollectionAssert.AreEquivalent(new List<string> { "8.8.8.8", "4.4.4.4" }, result["US"]);
    }

    [TestMethod]
    public void Should_GroupEveryIp_When_DuplicateIps()
    {
        var result = GroupIpsByCountry([("1.1.1.1", "IT"), ("1.1.1.1", "IT")]);
        Assert.AreEqual(1, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "1.1.1.1", "1.1.1.1" }, result["IT"]);
    }

    [TestMethod]
    public void Should_GroupEveryIp_When_SameIpDifferentCountries()
    {
        var result = GroupIpsByCountry([("1.1.1.1", "IT"), ("1.1.1.1", "US")]);
        Assert.AreEqual(2, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "1.1.1.1" }, result["IT"]);
        CollectionAssert.AreEquivalent(new List<string> { "1.1.1.1" }, result["US"]);
    }
}
