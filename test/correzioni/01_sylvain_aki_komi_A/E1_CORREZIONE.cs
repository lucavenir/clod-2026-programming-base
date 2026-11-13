#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 01 — AKI KOMI SYLVAIN — Traccia A — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/a.cs.
// Fonte: test/consegne/a/Ayi_sylvain_komi_clod_test_2026.cs
public static class ConsegnaStudente
{
  public static string EvaluateServerStatus(int cpu, int ram, int temperature)
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
}

[TestClass]
public class Esercizio1Tests
{
    [TestMethod]
    public void Should_ReturnInvalidData_When_CpuIsNegative()
    {
        Assert.AreEqual("INVALID_DATA", EvaluateServerStatus(-1, 50, 70),
            "Regola: percentuali sotto lo 0% non sono valide.");
    }

    [TestMethod]
    public void Should_ReturnInvalidData_When_CpuIsAbove100()
    {
        Assert.AreEqual("INVALID_DATA", EvaluateServerStatus(101, 50, 70),
            "Regola: percentuali sopra il 100% non sono valide.");
    }

    [TestMethod]
    public void Should_ReturnInvalidData_When_RamIsNegative()
    {
        Assert.AreEqual("INVALID_DATA", EvaluateServerStatus(50, -5, 70),
            "Regola: RAM sotto lo 0% deve invalidare i dati.");
    }

    [TestMethod]
    public void Should_ReturnCritical_When_TemperatureExceeds85()
    {
        Assert.AreEqual("CRITICAL", EvaluateServerStatus(0, 0, 86),
            "Regola: temperatura > 85°C fa scattare CRITICAL a prescindere da CPU/RAM.");
    }

    [TestMethod]
    public void Should_ReturnOk_When_TemperatureIsExactly85()
    {
        Assert.AreEqual("OK", EvaluateServerStatus(50, 50, 85),
            "Regola di confine: 85°C è l'ultimo valore tollerato, non è ancora CRITICAL (> 85).");
    }

    [TestMethod]
    public void Should_ReturnWarning_When_CpuAndRamAreExactly90()
    {
        Assert.AreEqual("WARNING", EvaluateServerStatus(90, 90, 50),
            "Regola di confine: CPU e RAM a 90 non bastano per CRITICAL (servono entrambe > 90).");
    }

    [TestMethod]
    public void Should_ReturnCritical_When_CpuAndRamBothExceed90()
    {
        Assert.AreEqual("CRITICAL", EvaluateServerStatus(91, 91, 50),
            "Regola: sia CPU che RAM > 90 fanno scattare CRITICAL.");
    }

    [TestMethod]
    public void Should_ReturnWarning_When_CpuExceeds70()
    {
        Assert.AreEqual("WARNING", EvaluateServerStatus(71, 50, 50),
            "Regola: CPU > 70 fa scattare WARNING.");
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_RamIsAbove100()
    {
        Assert.AreEqual("INVALID_DATA", EvaluateServerStatus(50, 101, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_InvalidCpuTakesPriorityOverCriticalTemperature()
    {
        Assert.AreEqual("INVALID_DATA", EvaluateServerStatus(-1, 50, 100));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_InvalidRamTakesPriorityOverHighLoad()
    {
        Assert.AreEqual("INVALID_DATA", EvaluateServerStatus(95, 101, 90));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_CpuAndRamAreZero()
    {
        Assert.AreEqual("OK", EvaluateServerStatus(0, 0, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_CpuAndRamAre100()
    {
        Assert.AreEqual("CRITICAL", EvaluateServerStatus(100, 100, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_CpuAndRamAreExactly70()
    {
        Assert.AreEqual("OK", EvaluateServerStatus(70, 70, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_OnlyRamExceeds70()
    {
        Assert.AreEqual("WARNING", EvaluateServerStatus(50, 71, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_OnlyCpuExceeds90()
    {
        Assert.AreEqual("WARNING", EvaluateServerStatus(91, 50, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_OnlyRamExceeds90()
    {
        Assert.AreEqual("WARNING", EvaluateServerStatus(50, 91, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_CpuIs90AndRamExceeds90()
    {
        Assert.AreEqual("WARNING", EvaluateServerStatus(90, 91, 50));
    }

    [TestMethod]
    public void Should_RespectStatusRule_When_RamIs90AndCpuExceeds90()
    {
        Assert.AreEqual("WARNING", EvaluateServerStatus(91, 90, 50));
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
