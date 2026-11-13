//ESERCIZIO 1
string EvaluateServerStatus(int cpu, int ram, int temperature)
{
    if (cpu < 0 || cpu > 100 || ram < 0 || ram > 100)
    {
        return "INVALID DATA";
    }
    else if (temperature > 85 || (cpu > 90 && ram > 90))
    {
        return "CRITICAL";
    }
    else if (cpu > 70 || ram > 70)
    {
        return "WARNING";
    }
    else
    {
        return "OK";
    }
}

Console.WriteLine(EvaluateServerStatus(92, 92, 87));


//ESERCIZIO 2
List<int> codes =[200, 500, 404, 503, 200];

int FindLastServerErrorIndex(List<int> statusCodes)
{
    int position=-1;
    for (int i=0; i<statusCodes.Count; i++)
    { 
        if (statusCodes.Count < 0)
        {
            position=-1;
            return position;
        }
        else if (statusCodes[i] >= 500)
        {
            position+=2;
            
        }
    }
    return position;
}
Console.WriteLine(FindLastServerErrorIndex(codes));


//ESERCIZIO 3
List<string> etiquettes = ["INFO", "ERROR", "INFO", "WARN"];
Dictionary<string, int> CountLogLevels(List<string> logLevels)
{
    Dictionary<string, int> results = [];
    foreach(string element in logLevels)
    {
        if (!results.ContainsKey(element))
        {
            results.Add[element.item1];
        }
        else
        {
            results.Add[results.Values];
        }
    }
    return results;
}

Console.WriteLine(CountLogLevels(etiquettes));