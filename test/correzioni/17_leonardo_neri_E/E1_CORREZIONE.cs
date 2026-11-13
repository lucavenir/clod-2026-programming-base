#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 17 — NERI LEONARDO — Traccia E — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/e.cs.
// Fonte: test/consegne/e/Neri_Leonardo_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static string ClassifyPingLatency(int pingMs)
    {
        if (pingMs <= 0)
        {
            return "TIMEOUT";
        }
        else if (pingMs <= 150)
        {
            return "FAST";
        }
        else if (pingMs <= 400)
        {
            return "SLOW";
        }
        else
        {
            return "CRITICAL";
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
