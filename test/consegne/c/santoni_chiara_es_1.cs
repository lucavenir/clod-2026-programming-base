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


