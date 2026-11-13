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


 