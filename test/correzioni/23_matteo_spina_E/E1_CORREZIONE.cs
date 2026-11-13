#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 23 — SPINA MATTEO — Traccia E — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/e.cs.
// Fonte: test/consegne/e/spina_matteo_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static string ClassifyPingLatency(int pingMs)
    {
        switch (pingMs)
        {
            // Se pingMs <= 0 → restituisce "TIMEOUT".
            case <= 0: return "TIMEOUT";
            // Se pingMs > 0 e ≤ 150 → restituisce "FAST".
            case <= 150: return "FAST";
            // Se pingMs > 150 (e ≤ 400) → restituisce "SLOW".
            case <= 400: return "SLOW";
            // Se pingMs > 400 → restituisce "CRITICAL".
            default: return "CRITICAL";
        }
    }
}

[TestClass]
public class Esercizio1Tests
{
    [TestMethod]
    public void Should_ReturnTimeout_When_PingIsZeroOrNegative()
    {
        Assert.AreEqual("TIMEOUT", ClassifyPingLatency(0),
            "Regola: latenza <= 0ms significa TIMEOUT.");
    }

    [TestMethod]
    public void Should_ReturnFast_When_PingIsUpTo150()
    {
        Assert.AreEqual("FAST", ClassifyPingLatency(150),
            "Regola di confine: 150ms è compreso in FAST.");
    }

    [TestMethod]
    public void Should_ReturnSlow_When_PingIsBetween151And400()
    {
        Assert.AreEqual("SLOW", ClassifyPingLatency(151),
            "Regola di confine: 151ms entra nella categoria SLOW.");
    }

    [TestMethod]
    public void Should_ReturnSlow_When_PingIsExactly400()
    {
        Assert.AreEqual("SLOW", ClassifyPingLatency(400),
            "Regola di confine: 400ms è l'ultimo valore compreso in SLOW.");
    }

    [TestMethod]
    public void Should_ReturnCritical_When_PingExceeds400()
    {
        Assert.AreEqual("CRITICAL", ClassifyPingLatency(401),
            "Regola: ping > 400ms è CRITICAL.");
    }

    [TestMethod]
    public void Should_ClassifyPing_When_Negative()
    {
        Assert.AreEqual("TIMEOUT", ClassifyPingLatency(-1));
    }

    [TestMethod]
    public void Should_ClassifyPing_When_MinimumPositive()
    {
        Assert.AreEqual("FAST", ClassifyPingLatency(1));
    }

    [TestMethod]
    public void Should_ClassifyPing_When_InsideSlowRange()
    {
        Assert.AreEqual("SLOW", ClassifyPingLatency(250));
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/e/spina_matteo_clod_test_2026.cs
// traccia E, file: "spina_matteo_clod_test_2026.cs"

// Esercizio 1
string ClassifyPingLatency(int pingMs)
{
    switch (pingMs)
    {
        // Se pingMs <= 0 → restituisce "TIMEOUT".
        case <= 0: return "TIMEOUT";
        // Se pingMs > 0 e ≤ 150 → restituisce "FAST".
        case <= 150: return "FAST";
        // Se pingMs > 150 (e ≤ 400) → restituisce "SLOW".
        case <= 400: return "SLOW";
        // Se pingMs > 400 → restituisce "CRITICAL".
        default: return "CRITICAL";
    }
}

// test 
Console.WriteLine("== EX 1 ==");
List<int> testPings = [12, 430, 0, 10, 150, -1, 400];
foreach (var ping in testPings)
{
    Console.WriteLine($"{ping} --> {ClassifyPingLatency(ping)}");
}

// ===========
// Esercizio 2
List<string> ReverseLogEvents(List<string> logEvents)
{
    List<string> reversed = [];
    for (int i = logEvents.Count - 1; i >= 0; i--)
    {
        reversed.Add(logEvents[i]);
    }
    return reversed;
}

//test
List<string> testLogEvents = ["A", "B", "C", "D", "", "F"];
Console.WriteLine("== EX 2 ==");
Console.WriteLine($"{string.Join(",", ReverseLogEvents(testLogEvents))}");

// ===========
// Esercizio 3
Dictionary<string, List<string>> GroupIpsByCountry(List<(string Ip, string Country)> ipRecords)
{
    Dictionary<string, List<string>> countryGroups = new();
    foreach (var record in ipRecords)
    {
        // note: check case so "IT" and "it" are the same key
        if (!countryGroups.ContainsKey(record.Country.ToUpper()))
        {
            // key is not present so add the key and associate it to an empty list
            // add the upper case version
            countryGroups.Add(record.Country.ToUpper(), []);
        }
        countryGroups[record.Country.ToUpper()].Add(record.Ip);
    }
    return countryGroups;
}

//test
Console.WriteLine("== EX 3 ==");

List<(string Ip, string Country)> testIpRecords =
[("1.1.1.1", "US"), ("2.2.2.2", "DE"), ("3.3.3.3", "IT"), ("4.4.4.4", "IT"), ("2.2.2.3", "DE"), ("4.4.4.3", "it")];
Dictionary<string, List<string>> testGroups = GroupIpsByCountry(testIpRecords);
foreach (var item in testGroups)
{
    var ipStrings = string.Join(", ", item.Value);
    Console.WriteLine($"{item.Key} : {ipStrings}");
}
#endif
