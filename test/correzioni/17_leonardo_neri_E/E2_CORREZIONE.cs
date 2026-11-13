#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 17 — NERI LEONARDO — Traccia E — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/e.cs.
// Fonte: test/consegne/e/Neri_Leonardo_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static List<string> ReverseLogEvents(List<string> logEvents)
    {
        List<String> logRev = [];
        for (var i = logEvents.Count - 1; i >= 0; i--)
        {
            logRev.Add(logEvents[i]);
        }
        return logRev;
    }
}

[TestClass]
public class Esercizio2Tests
{
    [TestMethod]
    public void Should_ReturnEmptyList_When_LogEventsListIsEmpty()
    {
        var result = ReverseLogEvents([]);
        Assert.AreEqual(0, result.Count,
            "Regola: lista vuota produce lista vuota.");
    }

    [TestMethod]
    public void Should_ReverseListOrder()
    {
        var result = ReverseLogEvents(["BOOT", "LOGIN", "ERROR"]);
        CollectionAssert.AreEqual(new List<string> { "ERROR", "LOGIN", "BOOT" }, result,
            "Regola: gli elementi devono essere specchiati dall'ultimo al primo.");
    }

    [TestMethod]
    public void Should_ReverseEveryEvent_When_SingleEvent()
    {
        var result = ReverseLogEvents(["BOOT"]);
        CollectionAssert.AreEqual(new List<string> { "BOOT" }, result);
    }

    [TestMethod]
    public void Should_ReverseEveryEvent_When_TwoEvents()
    {
        var result = ReverseLogEvents(["A", "B"]);
        CollectionAssert.AreEqual(new List<string> { "B", "A" }, result);
    }

    [TestMethod]
    public void Should_ReverseEveryEvent_When_EvenLength()
    {
        var result = ReverseLogEvents(["A", "B", "C", "D"]);
        CollectionAssert.AreEqual(new List<string> { "D", "C", "B", "A" }, result);
    }

    [TestMethod]
    public void Should_ReverseEveryEvent_When_DuplicateEvents()
    {
        var result = ReverseLogEvents(["BOOT", "ERROR", "BOOT", "LOGIN"]);
        CollectionAssert.AreEqual(new List<string> { "LOGIN", "BOOT", "ERROR", "BOOT" }, result);
    }

    [TestMethod]
    public void Should_ReverseEveryEvent_When_EmptyEvent()
    {
        var result = ReverseLogEvents(["A", "", "B"]);
        CollectionAssert.AreEqual(new List<string> { "B", "", "A" }, result);
    }

    [TestMethod]
    public void Should_ReverseEveryEvent_When_IdenticalEvents()
    {
        var result = ReverseLogEvents(["A", "A"]);
        CollectionAssert.AreEqual(new List<string> { "A", "A" }, result);
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
