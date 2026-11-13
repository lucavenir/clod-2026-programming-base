#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 11 — GRIZZO ROSSANA — Traccia E — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/e.cs.
// Fonte: test/consegne/e/grizzo_rossana_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static Dictionary<string, List<string>> GroupIpsByCountry(List<(string Ip, string Country)> ipRecords)
    {
        Dictionary<string, List<string>> ipsGroupedByCountry = new Dictionary<string, List<string>>();
        foreach (var entry in ipRecords)
        {
            if (!ipsGroupedByCountry.ContainsKey(entry.Country))
            {
                ipsGroupedByCountry[entry.Country] = [entry.Ip];
            }
            else
            {
                ipsGroupedByCountry[entry.Country].Add(entry.Ip);
            }
        }
        return ipsGroupedByCountry;
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
// Fonte: test/consegne/e/grizzo_rossana_clod_test_2026.cs
Console.WriteLine("---------------------------------");
Console.WriteLine("ESERCIZIO 1");
Console.WriteLine("*****************");
Console.WriteLine("test 1: ");
Console.WriteLine("input: "+0);
Console.WriteLine("output: "+ClassifyPingLatency(0));
Console.WriteLine("*****************");
Console.WriteLine("");
Console.WriteLine("*****************");
Console.WriteLine("test 2: ");
Console.WriteLine("input: "+90);
Console.WriteLine("output: "+ClassifyPingLatency(90));
Console.WriteLine("*****************");
Console.WriteLine("");
Console.WriteLine("*****************");
Console.WriteLine("test 3: ");
Console.WriteLine("input: "+350);
Console.WriteLine("output: "+ClassifyPingLatency(350));
Console.WriteLine("*****************");
Console.WriteLine("");
Console.WriteLine("*****************");
Console.WriteLine("test 4: ");
Console.WriteLine("input: "+500);
Console.WriteLine("output: "+ClassifyPingLatency(500));
Console.WriteLine("*****************");
Console.WriteLine("---------------------------------");

string ClassifyPingLatency(int pingMs){
    
 if(pingMs<=0){
    return "TIMEOUT";
 }
 else if(pingMs <=150){
    return "FAST";
 }
 else if(pingMs<=400){
    return "SLOW";
 }
 else{
    return "CRITICAL";
 }
}
List<string> logs=["A", "B", "C"] ;
List<string> reversedLogs=ReverseLogEvents(logs);
Console.WriteLine("ESERCIZIO 2");
Console.WriteLine("test1: ");
Console.WriteLine("input: "+String.Join(",",logs));
Console.WriteLine("output: "+String.Join(",",reversedLogs));
Console.WriteLine("---------------------------------");
List<string> ReverseLogEvents(List<string> logEvents)
{
    List<string> results = [];
    for(int i= logEvents.Count-1;i>=0; i--)
    {
        results.Add(logEvents[i]);
    }
    return results;
}


List<(string,string)> ipRecords=[("127.0.0.1","IT"),("12.12.12.12","US"),("13.16.17.19","IT"),("16.19.02.03","DE"),("45.89.56.127","DE")];

Dictionary<string,List<string>> results=GroupIpsByCountry(ipRecords);
Console.WriteLine("ESERCIZIO 3");
Console.WriteLine("test 1: ");
Console.WriteLine(" input: "+String.Join(",",ipRecords) );
Console.WriteLine(" output: " );
Console.WriteLine("{");
foreach(var element in results)
{
    Console.Write("   ");
    Console.Write(element.Key);
    Console.Write(" ");
    Console.Write("[");
    Console.Write(String.Join(",",element.Value));
    Console.WriteLine("]");

}
Console.WriteLine("}");
Console.WriteLine("---------------------------------");
Dictionary<string,List<string>> GroupIpsByCountry(List<(string Ip,string Country)> ipRecords)
{
    Dictionary<string,List<string>> ipsGroupedByCountry = new Dictionary<string, List<string>>();
    foreach(var entry in ipRecords )
    {
        if (!ipsGroupedByCountry.ContainsKey(entry.Country))
        {
            ipsGroupedByCountry[entry.Country]= [entry.Ip];
        }
        else
        {
            ipsGroupedByCountry[entry.Country].Add(entry.Ip);
        }
    }
    return ipsGroupedByCountry;
}



#endif
