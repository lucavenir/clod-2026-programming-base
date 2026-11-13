#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 01 — AKI KOMI SYLVAIN — Traccia A — Esercizio 3
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/a.cs.
// Fonte: test/consegne/a/Ayi_sylvain_komi_clod_test_2026.cs
// Usata la consegna complessiva; il file aggiuntivo sovrapposto è conservato fra i sorgenti originali qui sotto.
public static class ConsegnaStudente
{
  ESERcizio 3
  Scrivi la funzione:
//Dictionary<string, int> CountLogLevels(List<string> logLevels)

//La funzione accetta una lista di etichette di log (es. ["INFO", "ERROR", "INFO", "WARN"])
//  e restituisce una mappa che ad ogni livello di log associa il numero di occorrenze rilevate.



  List<(string, string)> list = ["INFO", "ERROR", "INFO", "WARN"]

  public static Dictionary<string, int> CountLogLevels(List<string> logLevels))
{
    var result = new Dictionary<string, List<string>>();
foreach (var (log, logLevels) in requests)
{
  if
}

[TestClass]
public class Esercizio3Tests
{
    [TestMethod]
    public void Should_ReturnEmptyDictionary_When_LogListIsEmpty()
    {
        var result = CountLogLevels([]);
        Assert.AreEqual(0, result.Count,
            "Regola: lista vuota produce mappa vuota.");
    }

    [TestMethod]
    public void Should_CountLogOccurrencesCorrectly()
    {
        var result = CountLogLevels(["INFO", "ERROR", "INFO", "WARN"]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(2, result["INFO"]);
        Assert.AreEqual(1, result["ERROR"]);
        Assert.AreEqual(1, result["WARN"]);
    }

    [TestMethod]
    public void Should_CountAllLevels_When_SingleLevel()
    {
        var result = CountLogLevels(["ERROR"]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(1, result["ERROR"]);
        CollectionAssert.AreEquivalent(new List<string> { "ERROR" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountAllLevels_When_AllLevelsRepeat()
    {
        var result = CountLogLevels(["INFO", "INFO", "INFO"]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(3, result["INFO"]);
        CollectionAssert.AreEquivalent(new List<string> { "INFO" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountAllLevels_When_AllLevelsDiffer()
    {
        var result = CountLogLevels(["INFO", "WARN", "ERROR"]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(1, result["INFO"]);
        Assert.AreEqual(1, result["WARN"]);
        Assert.AreEqual(1, result["ERROR"]);
        CollectionAssert.AreEquivalent(new List<string> { "INFO", "WARN", "ERROR" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountAllLevels_When_DifferentFrequencies()
    {
        var result = CountLogLevels(["WARN", "ERROR", "WARN", "INFO", "ERROR", "ERROR"]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(2, result["WARN"]);
        Assert.AreEqual(3, result["ERROR"]);
        Assert.AreEqual(1, result["INFO"]);
        CollectionAssert.AreEquivalent(new List<string> { "WARN", "ERROR", "INFO" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountAllLevels_When_UnknownLabels()
    {
        var result = CountLogLevels(["DEBUG", "TRACE", "DEBUG"]);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(2, result["DEBUG"]);
        Assert.AreEqual(1, result["TRACE"]);
        CollectionAssert.AreEquivalent(new List<string> { "DEBUG", "TRACE" }, new List<string>(result.Keys));
    }

    [TestMethod]
    public void Should_CountAllLevels_When_EmptyLabel()
    {
        var result = CountLogLevels(["", "INFO", ""]);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(2, result[""]);
        Assert.AreEqual(1, result["INFO"]);
        CollectionAssert.AreEquivalent(new List<string> { "", "INFO" }, new List<string>(result.Keys));
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/a/Ayi_sylvain_komi_clod_test_2026.cs
string EvaluateServerStatus(int cpu, int ram, int temperature)
{
  var temperatura <= 100
    {
    if (cpu < 0 and cpu > 100 )
    
     {
      return "INVALID_DATA";
    }


     else if (temperatura > 80 and cpu<90 and ram > 90)
     {
      return "critical"
     }

     else if (cpu > 70 and ram > 70 )
    
     {
      return "WARNING";
    }


     else
    {
      return ok
     }

  }
}] 


//Scrivi la funzione:
//int FindLastServerErrorIndex(List<int> statusCodes)

//La funzione accetta una lista di codici di risposta HTTP e restituisce l'indice dell'ultimo codice relativo ad un errore server (ovvero un codice ≥ 500).
//  Se nella lista non è presente alcun errore server, la funzione deve restituire -1.
//Esempio: [200, 500, 404, 503, 200] → restituisce 3 (l'ultimo codice ≥ 500 è 503 all'indice 3).




int[200, 500, 404, 503, 200]
List<int> FindLastServerErrorIndex(List<int> statusCodes);
int statuscodes = 0;
{
  for (i = -1; countCodice >= 500; i--)
  {

  }
  return
}








ESERcizio 3
  Scrivi la funzione:
//Dictionary<string, int> CountLogLevels(List<string> logLevels)

//La funzione accetta una lista di etichette di log (es. ["INFO", "ERROR", "INFO", "WARN"])
//  e restituisce una mappa che ad ogni livello di log associa il numero di occorrenze rilevate.



  List<(string, string)> list = ["INFO", "ERROR", "INFO", "WARN"]

  Dictionary<string, int> CountLogLevels(List<string> logLevels))
{
    var result = new Dictionary<string, List<string>>();
foreach (var (log, logLevels) in requests)
{
  if

  
#endif

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/a/Ayi_sylvain_komi_cloud_test_2026_2.cs
//Scrivi la funzione:
//int FindLastServerErrorIndex(List<int> statusCodes)

//La funzione accetta una lista di codici di risposta HTTP e restituisce l'indice dell'ultimo codice relativo ad un errore server (ovvero un codice ≥ 500).
//  Se nella lista non è presente alcun errore server, la funzione deve restituire -1.
//Esempio: [200, 500, 404, 503, 200] → restituisce 3 (l'ultimo codice ≥ 500 è 503 all'indice 3).




int [200, 500, 404, 503, 200] 
List<int> FindLastServerErrorIndex(List<int> statusCodes);
  int statuscodes =0;
{
    for(i=-1; countCodice>=500 ;i--)
    {
      
    }
    return 
}
  







  ESERcizio 3
  Scrivi la funzione:
//Dictionary<string, int> CountLogLevels(List<string> logLevels)

//La funzione accetta una lista di etichette di log (es. ["INFO", "ERROR", "INFO", "WARN"])
//  e restituisce una mappa che ad ogni livello di log associa il numero di occorrenze rilevate.



  List<(string, string)> list =  ["INFO", "ERROR", "INFO", "WARN"]

  Dictionary<string, int> CountLogLevels(List<string> logLevels))
{
    var result = new Dictionary<string, List<string>>();
    foreach (var (log , logLevels) in requests)
    {
        if 
#endif
