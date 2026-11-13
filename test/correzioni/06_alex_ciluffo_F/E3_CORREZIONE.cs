#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 06 — CILUFFO ALEX — Traccia F — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/f.cs.
// Nessun sorgente consegnato.
public static class ConsegnaStudente
{
#error Esercizio 3 non consegnato: nessuna implementazione presente.
}

[TestClass]
public class Esercizio3Tests
{
    [TestMethod]
    public void Should_CountFrequencies_CaseInsensitively()
    {
        var result = CountWordFrequencies(["Cloud", "cloud", "NET", "CLOUD"]);

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(3, result["cloud"]);
        Assert.AreEqual(1, result["net"]);
        CollectionAssert.AreEquivalent(new List<string> { "cloud", "net" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountEveryWord_When_EmptyList()
    {
        var result = CountWordFrequencies([]);
        Assert.AreEqual(0, result.Count);
        CollectionAssert.AreEquivalent(new List<string> {  }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountEveryWord_When_SingleWord()
    {
        var result = CountWordFrequencies(["Cloud"]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(1, result["cloud"]);
        CollectionAssert.AreEquivalent(new List<string> { "cloud" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountEveryWord_When_AllWordsDiffer()
    {
        var result = CountWordFrequencies(["Cat", "DOG", "bird"]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(1, result["cat"]);
        Assert.AreEqual(1, result["dog"]);
        Assert.AreEqual(1, result["bird"]);
        CollectionAssert.AreEquivalent(new List<string> { "cat", "dog", "bird" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountEveryWord_When_RepeatedWord()
    {
        var result = CountWordFrequencies(["Net", "NET", "net"]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(3, result["net"]);
        CollectionAssert.AreEquivalent(new List<string> { "net" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountEveryWord_When_DifferentFrequencies()
    {
        var result = CountWordFrequencies(["A", "b", "a", "C", "B", "c", "C"]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(2, result["a"]);
        Assert.AreEqual(2, result["b"]);
        Assert.AreEqual(3, result["c"]);
        CollectionAssert.AreEquivalent(new List<string> { "a", "b", "c" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountEveryWord_When_EmptyWord()
    {
        var result = CountWordFrequencies(["", "Cloud", ""]);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(2, result[""]);
        Assert.AreEqual(1, result["cloud"]);
        CollectionAssert.AreEquivalent(new List<string> { "", "cloud" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountEveryWord_When_SpacesInsideWords()
    {
        var result = CountWordFrequencies(["Hello World", "HELLO WORLD", "Hello"]);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(2, result["hello world"]);
        Assert.AreEqual(1, result["hello"]);
        CollectionAssert.AreEquivalent(new List<string> { "hello world", "hello" }, new List<string>(result.Keys));
    }
}
