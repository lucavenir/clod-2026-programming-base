#:sdk MSTest.Sdk@4.5.2

using static E_CHAKICH;

public static class E_CHAKICH
{

}
public static class E_GRIZZO
{

}
public static class E_NERI
{

}
public static class E_SPINA
{

}

[TestClass]
public class TrackETests
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