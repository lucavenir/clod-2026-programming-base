#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 11 — GRIZZO ROSSANA — Traccia E — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/e.cs.
// Fonte: test/consegne/e/grizzo_rossana_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static List<string> ReverseLogEvents(List<string> logEvents)
    {
        List<string> results = [];
        for (int i = logEvents.Count - 1; i >= 0; i--)
        {
            results.Add(logEvents[i]);
        }
        return results;
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
