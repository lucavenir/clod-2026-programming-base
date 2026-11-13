#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 17 — NERI LEONARDO — Traccia E — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/e.cs.
// Fonte: test/consegne/e/Neri_Leonardo_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static Dictionary<string, List<string>> GroupIpsByCountry(List<(string Ip, string Country)> ipRecords)
    {
        Dictionary<string, List<string>> countriesIp = new Dictionary<string, List<string>>();
        foreach (var record in ipRecords)
        {
            if (!countriesIp.ContainsKey(record.Ip))
            {
                countriesIp.Add(record.Ip, []);
            }
            countriesIp[record.Ip].Add(record.Country);
        }
        return countriesIp;
    }
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

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/e/Neri_Leonardo_clod_test_2026.cs
//Excersice 1
Console.WriteLine("Excersise 1:");

Console.WriteLine("0 ping: " + ClassifyPingLatency(0));
Console.WriteLine("30 ping: " + ClassifyPingLatency(30));
Console.WriteLine("160 ping: " + ClassifyPingLatency(160));
Console.WriteLine("500 ping: " + ClassifyPingLatency(500));

string ClassifyPingLatency(int pingMs){
    if (pingMs <= 0){
        return "TIMEOUT";
    }else if(pingMs <= 150){
        return "FAST";
    }else if(pingMs <= 400){
        return "SLOW";
    }else{
        return "CRITICAL";
    }
}


//Excersice 2
Console.WriteLine("\nExcersise 2:");

List<String> logEvents = ["A", "B", "C", "D"];

Console.WriteLine("Logs: ["+String.Join(", ",logEvents)+"]");
Console.WriteLine("Reversed Logs: [" + String.Join(", ",ReverseLogEvents(logEvents))+"]");


List<string> ReverseLogEvents(List<string> logEvents){
    List<String> logRev = [];
    for(var i = logEvents.Count - 1; i >= 0; i--){
        logRev.Add(logEvents[i]);
    }
    return logRev;
}



// Excersice 3
Console.WriteLine("\nExcersise 3:");

List<(string,string)> ipRecords = [("IT","192.192.192.192"),("EN","238.123.93.241"),("CA","247.247.247.247"),("IT","30.86.10.2.1")];
Dictionary<string, List<string>> countriesIp = new Dictionary<string, List<string>>();
countriesIp = GroupIpsByCountry(ipRecords);

Console.Write("Ip records: ");
Console.Write("[");
for(var i=0;i<ipRecords.Count; i++){
    Console.Write("("+ipRecords[i].Item1+", "+ipRecords[i].Item2+")");
    if (i < ipRecords.Count - 1){
        Console.Write(", ");
    }
}
Console.WriteLine("]");

Console.WriteLine("Ip records organized:");
foreach(var element in countriesIp){
    Console.WriteLine(element.Key + ": ["+String.Join(" , ",element.Value) + "]");
}

Dictionary<string, List<string>> GroupIpsByCountry(List<(string Ip, string Country)> ipRecords){
    Dictionary<string, List<string>> countriesIp = new Dictionary<string, List<string>>();
    foreach(var record in ipRecords){
        if (!countriesIp.ContainsKey(record.Ip)){
            countriesIp.Add(record.Ip,[]);            
        }
        countriesIp[record.Ip].Add(record.Country);
    }
    return countriesIp;
}
#endif
