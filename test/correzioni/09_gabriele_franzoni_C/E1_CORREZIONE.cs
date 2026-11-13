#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 09 — FRANZONI GABRIELE — Traccia C — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/c.cs.
// Fonte: test/consegne/c/Franzoni_Gabriele_clod_test_2026.cs
public static class ConsegnaStudente
{
    public static string EvaluateFirewallRule(int port, bool isInternal, string protocol)
    {
        if (port == 22 && isInternal == false)
            return "BLOCK_SSH_RISK";

        if (protocol == "HTTP")
            return "REDIRECT_HTTPS";

        if (port == 443 || isInternal == true)
            return "ALLOW";

        else
            return "DENY";


    }
}

[TestClass]
public class Esercizio1Tests
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
    public void Should_AllowPort443_When_ProtocolIsTcp()
    {
        Assert.AreEqual("ALLOW", EvaluateFirewallRule(443, false, "TCP"));
    }
}

#if false // Sorgente originale integrale, escluso dalla compilazione dei test.
// Fonte: test/consegne/c/Franzoni_Gabriele_clod_test_2026.cs
//ESERCIZIO 1
string EvaluateFirewallRule(int port, bool isInternal, string protocol)
{
    if (port == 22 && isInternal == false)
    return "BLOCK_SSH_RISK";

    if (protocol == "HTTP")
    return "REDIRECT_HTTPS";

    if (port == 443 || isInternal == true)
    return "ALLOW";

    else 
    return "DENY";


}


//ESERCIZIO 2
List<string> AnonymizeUserIds(List<int> userIds)
{
    for (int i = 0; i<userIds.Count; i++)
    {
        if (userIds[i] >= 5000)
        {
            return "ANONYMUS";
        }
        else 
        return userIds[i];

    }

}






//ESERCIZIO 3
Dictionary<int, int> CountHttpStatusCodeFrequency(List <int> input)
{


Dictionary<int, int> Result = new();

for (int i = 0; i < input.Count; i++)
{

    int frequenza = 0;

    if (Result.ContainsKey)
    {
        Result [input[i]].Add (frequenza =+ 1);


    }

    else
        {
         Result.Add [input[i]];
         Result [input[i]].Add (frequenza + 1);

        }


}

return Result;

}


 
#endif
