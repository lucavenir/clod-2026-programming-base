#:sdk MSTest.Sdk@4.5.2

using static C_CALÒ;

public static class C_CALÒ
{

}
public static class C_FRANZONI
{

}
public static class C_MEHNI
{

}
public static class C_SANTONI
{

}

[TestClass]
public class TrackCTests
{
    [TestMethod]
    public void Should_BlockSsh_When_ExternalConnection()
    {
        Assert.AreEqual("BLOCK_SSH_RISK", EvaluateFirewallRule(22, false, "TCP"),
            "Regola di massima priorità: SSH (22) da rete esterna va sempre bloccato.");
    }

    [TestMethod]
    public void Should_AllowSsh_When_InternalConnection()
    {
        Assert.AreEqual("ALLOW", EvaluateFirewallRule(22, true, "TCP"),
            "Regola: SSH (22) da rete interna deve essere consentito.");
    }

    [TestMethod]
    public void Should_RedirectHttps_When_ProtocolIsHttp()
    {
        Assert.AreEqual("REDIRECT_HTTPS", EvaluateFirewallRule(80, true, "HTTP"),
            "Regola: il protocollo HTTP ha precedenza su rete interna e richiede reindirizzamento HTTPS.");
    }

    [TestMethod]
    public void Should_Allow_When_HttpsPort443()
    {
        Assert.AreEqual("ALLOW", EvaluateFirewallRule(443, false, "HTTPS"),
            "Regola: la porta 443 è consentita anche da rete esterna.");
    }

    [TestMethod]
    public void Should_Deny_When_NoRulesMatch()
    {
        Assert.AreEqual("DENY", EvaluateFirewallRule(21, false, "FTP"),
            "Regola di fallback: traffico non specificato va negato.");
    }

    [TestMethod]
    public void Should_ReturnEmptyList_When_UserIdsListIsEmpty()
    {
        var result = AnonymizeUserIds([]);
        Assert.AreEqual(0, result.Count,
            "Regola: lista vuota produce lista vuota.");
    }

    [TestMethod]
    public void Should_KeepId_When_LessThan5000()
    {
        var result = AnonymizeUserIds([4999]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("4999", result[0],
            "Regola di confine: ID 4999 (< 5000) non va anonimizzato.");
    }

    [TestMethod]
    public void Should_Anonymize_When_5000OrGreater()
    {
        var result = AnonymizeUserIds([5000]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("ANONYMOUS", result[0],
            "Regola di confine: ID 5000 (>= 5000) deve diventare 'ANONYMOUS'.");
    }

    [TestMethod]
    public void Should_ReturnEmptyDictionary_When_StatusCodesListIsEmpty()
    {
        var result = CountHttpStatusCodeFrequency([]);
        Assert.AreEqual(0, result.Count,
            "Regola: lista vuota produce mappa vuota.");
    }

    [TestMethod]
    public void Should_CountHttpFrequenciesCorrectly()
    {
        var result = CountHttpStatusCodeFrequency([200, 404, 200]);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(2, result[200]);
        Assert.AreEqual(1, result[404]);
    }


    [TestMethod]
    public void Should_RespectFirewallPriority_When_ExternalSshUsesHttp()
    {
        Assert.AreEqual("BLOCK_SSH_RISK", EvaluateFirewallRule(22, false, "HTTP"));
    }

    [TestMethod]
    public void Should_RespectFirewallPriority_When_HttpsPortUsesHttp()
    {
        Assert.AreEqual("REDIRECT_HTTPS", EvaluateFirewallRule(443, false, "HTTP"));
    }

    [TestMethod]
    public void Should_RespectFirewallPriority_When_InternalSshUsesHttp()
    {
        Assert.AreEqual("REDIRECT_HTTPS", EvaluateFirewallRule(22, true, "HTTP"));
    }

    [TestMethod]
    public void Should_RespectFirewallPriority_When_ExternalHttp()
    {
        Assert.AreEqual("REDIRECT_HTTPS", EvaluateFirewallRule(80, false, "HTTP"));
    }

    [TestMethod]
    public void Should_RespectFirewallPriority_When_InternalNonStandardPort()
    {
        Assert.AreEqual("ALLOW", EvaluateFirewallRule(1234, true, "TCP"));
    }

    [TestMethod]
    public void Should_PreserveIdsAndOrder_When_TwoVisibleIds()
    {
        var result = AnonymizeUserIds([100, 200]);
        CollectionAssert.AreEqual(new List<string> { "100", "200" }, result);
    }

    [TestMethod]
    public void Should_PreserveIdsAndOrder_When_MixedBoundaryIds()
    {
        var result = AnonymizeUserIds([4999, 5000, 5001]);
        CollectionAssert.AreEqual(new List<string> { "4999", "ANONYMOUS", "ANONYMOUS" }, result);
    }

    [TestMethod]
    public void Should_PreserveIdsAndOrder_When_HiddenThenVisible()
    {
        var result = AnonymizeUserIds([7000, 42]);
        CollectionAssert.AreEqual(new List<string> { "ANONYMOUS", "42" }, result);
    }

    [TestMethod]
    public void Should_PreserveIdsAndOrder_When_RepeatedIds()
    {
        var result = AnonymizeUserIds([12, 12, 5000, 5000]);
        CollectionAssert.AreEqual(new List<string> { "12", "12", "ANONYMOUS", "ANONYMOUS" }, result);
    }

    [TestMethod]
    public void Should_PreserveIdsAndOrder_When_ZeroId()
    {
        var result = AnonymizeUserIds([0]);
        CollectionAssert.AreEqual(new List<string> { "0" }, result);
    }

    [TestMethod]
    public void Should_CountAllHttpCodes_When_SingleCode()
    {
        var result = CountHttpStatusCodeFrequency([201]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(1, result[201]);
    }

    [TestMethod]
    public void Should_CountAllHttpCodes_When_RepeatedCode()
    {
        var result = CountHttpStatusCodeFrequency([503, 503, 503]);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(3, result[503]);
    }

    [TestMethod]
    public void Should_CountAllHttpCodes_When_DifferentCodes()
    {
        var result = CountHttpStatusCodeFrequency([200, 404, 500]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(1, result[200]);
        Assert.AreEqual(1, result[404]);
        Assert.AreEqual(1, result[500]);
    }

    [TestMethod]
    public void Should_CountAllHttpCodes_When_DifferentFrequencies()
    {
        var result = CountHttpStatusCodeFrequency([404, 200, 404, 500, 500, 500]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(2, result[404]);
        Assert.AreEqual(1, result[200]);
        Assert.AreEqual(3, result[500]);
    }

    [TestMethod]
    public void Should_CountAllHttpCodes_When_ClientAndServerCodes()
    {
        var result = CountHttpStatusCodeFrequency([200, 499, 500, 200]);
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(2, result[200]);
        Assert.AreEqual(1, result[499]);
        Assert.AreEqual(1, result[500]);
    }

    [TestMethod]
    public void Should_CountAllHttpCodes_When_SameCodeAtBothEnds()
    {
        var result = CountHttpStatusCodeFrequency([200, 404, 200]);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(2, result[200]);
        Assert.AreEqual(1, result[404]);
    }

    [TestMethod]
    public void Should_AllowPort443_When_ProtocolIsTcp()
    {
        Assert.AreEqual("ALLOW", EvaluateFirewallRule(443, false, "TCP"));
    }
}
