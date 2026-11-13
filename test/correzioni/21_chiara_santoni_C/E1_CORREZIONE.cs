#:sdk MSTest.Sdk@4.5.2

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsegnaStudente;

// 21 — SANTONI CHIARA — Traccia C — Esercizio 1
// Adattamento: estrazione del solo esercizio, classe contenitore, public static.
// Nessuna correzione sintattica o logica. Test invariati da test/c.cs.
// Fonte: test/consegne/c/santoni_chiara_es_1.cs
public static class ConsegnaStudente
{
    public static String EvaluateFirewallRule(int port, bool inInternal, string protocol);

if(port==22 && isInternal==false)
{
    Console.WriteLine("");
return "BLOCK_SSH_RISK";
}
if (protocol == "HTTP")
{
    Console.WriteLine("");
    return "REDIRECT_HHTPS";
}
if (port == 443 || isInternal == true)
{
    Console.WriteLine("");
    return "ALLOW";
}
else
{
    Console.WriteLine("");
    return "DENY";
}
// Le ho provate tutte, ma, mi da in qualunque caso errore
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
// Fonte: test/consegne/c/santoni_chiara_es_1.cs
String EvaluateFirewallRule(int port, bool inInternal, string protocol);

if(port==22 && isInternal==false)
{
    Console.WriteLine("");
return "BLOCK_SSH_RISK";
}
if(protocol=="HTTP")
{
    Console.WriteLine("");
return "REDIRECT_HHTPS";
}
if(port==443 || isInternal==true)
{
    Console.WriteLine("");
return "ALLOW";
}
else
{
    Console.WriteLine("");
return "DENY";
}
// Le ho provate tutte, ma, mi da in qualunque caso errore



#endif
