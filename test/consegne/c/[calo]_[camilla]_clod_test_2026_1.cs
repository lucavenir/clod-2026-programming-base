string EvaluateFirewallRule(int port, bool isInternal, string protocol)
{
    var result = "DENY";
    if (port == 22 && isInternal == false)
    {
        result = "BLOCK_SSH_RISK";
    }
    if (protocol == "HTTP")
    {
        result = "REDIRECT_HTTPS";
    }
    if (port == 443 || isInternal == true)
    {
        result = "ALLOW";
    }
    return result;
}

