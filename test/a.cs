#:sdk MSTest.Sdk@4.5.2

using static A_AKI_KOMI;

public static class A_AKI_KOMI
{

}
public static class A_DE_MARCHI
{

}
public static class A_MANIAS
{

}
public static class A_PARO
{

}

[TestClass]
public class TrackATests
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