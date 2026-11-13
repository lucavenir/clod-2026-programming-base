Console.WriteLine("FUNC EVALUATESERVERSTATUS");
Console.WriteLine(EvaluateServerStatus(101,100,100));
Console.WriteLine(EvaluateServerStatus(10,10,86));
Console.WriteLine(EvaluateServerStatus(10,71,32));
Console.WriteLine(EvaluateServerStatus(10,10,10));

Console.WriteLine();

Console.WriteLine("FUNC FINDLASTSERVERERRORINDEX");
List<int> statusCodes =  [200, 500, 404, 503, 200];
Console.WriteLine(FindLastServerErrorIndex(statusCodes));

Console.WriteLine();

Console.WriteLine("FUNC COUNTLOGLEVELS");
List<string> list = ["INFO", "ERROR", "INFO", "WARN"];
Dictionary<string,int> result = CountLogLevels(list);

foreach(var element in result)
{
    Console.WriteLine($"{element.Key} : {element.Value}");
}


string EvaluateServerStatus(int cpu, int ram, int temperature){
    if(cpu<0 || cpu>100 || ram <0 || ram>100){
        return "INVALID_DATA";
    }else if(temperature>85 || cpu>90 && ram>90){
        return "CRITICAL";
    }else if(cpu>70 || ram>70){
        return "WARNING";
    }
    
    return "OK";
}


int FindLastServerErrorIndex(List<int> statusCodes)
{
    int result = -1;
    for(int i = 0 ; i<statusCodes.Count ; i++)
    {
        if(statusCodes[i] >= 500)
        {
            result = i;
        }
    }

    return result;
}

Dictionary<string, int> CountLogLevels(List<string> logLevels)
{
    var result = new Dictionary<string , int> ();

    foreach(var log in logLevels)
    {
        if (result.ContainsKey(log))
        {
            result[log] += 1;
        }
        else
        {
            result[log] = 1;
        }
    }

    return result;
}