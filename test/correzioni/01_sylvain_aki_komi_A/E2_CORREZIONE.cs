#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 01 — AKI KOMI SYLVAIN — Traccia A — Esercizio 2
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/a.cs.
// Fonte: test/consegne/a/Ayi_sylvain_komi_clod_test_2026.cs
// Usata la consegna complessiva; il file aggiuntivo sovrapposto è conservato fra i sorgenti originali qui sotto.
public static class ConsegnaStudente
{
  //Scrivi la funzione:
  //int FindLastServerErrorIndex(List<int> statusCodes)

  //La funzione accetta una lista di codici di risposta HTTP e restituisce l'indice dell'ultimo codice relativo ad un errore server (ovvero un codice ≥ 500).
  //  Se nella lista non è presente alcun errore server, la funzione deve restituire -1.
  //Esempio: [200, 500, 404, 503, 200] → restituisce 3 (l'ultimo codice ≥ 500 è 503 all'indice 3).




  int[200, 500, 404, 503, 200]
public static List<int> FindLastServerErrorIndex(List<int> statusCodes);
  int statuscodes = 0;
{
  for (i = -1; countCodice >= 500; i--)
  {

  }
  return
}
}

[TestClass]
public class Esercizio2Tests
{
    [TestMethod]
    public void Should_ReturnMinusOne_When_ListIsEmpty()
    {
        Assert.AreEqual(-1, FindLastServerErrorIndex([]),
            "Regola: lista vuota deve restituire -1.");
    }

    [TestMethod]
    public void Should_ReturnMinusOne_When_NoServerErrorExists()
    {
        Assert.AreEqual(-1, FindLastServerErrorIndex([200, 201, 404, 499]),
            "Regola: nessun codice >= 500 presente.");
    }

    [TestMethod]
    public void Should_ReturnZero_When_ServerErrorIsAtFirstPosition()
    {
        Assert.AreEqual(0, FindLastServerErrorIndex([500, 200, 200]),
            "Regola: unico errore all'indice 0.");
    }

    [TestMethod]
    public void Should_ReturnLastIndex_When_MultipleServerErrorsExist()
    {
        Assert.AreEqual(3, FindLastServerErrorIndex([500, 200, 404, 502, 200]),
            "Regola: deve trovare l'ULTIMO errore nella lista (indice 3), non il primo.");
    }

    [TestMethod]
    public void Should_FindLastError_When_OnlySuccess()
    {
        Assert.AreEqual(-1, FindLastServerErrorIndex([200]));
    }

    [TestMethod]
    public void Should_FindLastError_When_Only499()
    {
        Assert.AreEqual(-1, FindLastServerErrorIndex([499]));
    }

    [TestMethod]
    public void Should_FindLastError_When_Only500()
    {
        Assert.AreEqual(0, FindLastServerErrorIndex([500]));
    }

    [TestMethod]
    public void Should_FindLastError_When_ErrorIsAtLastPosition()
    {
        Assert.AreEqual(2, FindLastServerErrorIndex([200, 404, 500]));
    }

    [TestMethod]
    public void Should_FindLastError_When_AllCodesAreErrors()
    {
        Assert.AreEqual(2, FindLastServerErrorIndex([500, 503, 502]));
    }

    [TestMethod]
    public void Should_FindLastError_When_ErrorsHaveIrregularPositions()
    {
        Assert.AreEqual(4, FindLastServerErrorIndex([200, 500, 200, 200, 503, 200]));
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
