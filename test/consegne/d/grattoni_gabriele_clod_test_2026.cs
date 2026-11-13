//es 1
System.Console.WriteLine("ES_1");
System.Console.WriteLine(CategorizeEventCode(-6)); //invalid
System.Console.WriteLine(CategorizeEventCode(12)); //CRITICAL_SYS_APP
System.Console.WriteLine(CategorizeEventCode(8));  //SYS
System.Console.WriteLine(CategorizeEventCode(18)); //APP
System.Console.WriteLine(CategorizeEventCode(7));  //"7"

//es 2
System.Console.WriteLine("\nES_2");
List<int> data = [10, 20, 30, 40, 50];
System.Console.WriteLine(SumOddIndexElements(data).ToString()); //20 + 40 = 60

//es 3
Dictionary<string, string> apiData = new();
apiData.Add("marco", "polo");
apiData.Add("quattro", "cinque");
apiData.Add("otto", "nove");

System.Console.WriteLine("\nES_3");
System.Console.WriteLine(ValidateApiKeyAccess(apiData, "gabriele", "grattoni")); //false, false => false
System.Console.WriteLine(ValidateApiKeyAccess(apiData, "marco", "pala")); //true, false => false
System.Console.WriteLine(ValidateApiKeyAccess(apiData, "quattro", "cinque")); //true, true => true


String CategorizeEventCode(int eventCode)
{
    if (eventCode <= 0)
        return ("INVALID");

    if (eventCode % 4 == 0 && eventCode % 6 == 0)
        return ("CRITICAL_SYS_APP");
    else
    {

        if (eventCode % 4 == 0)
            return ("SYS");

        if (eventCode % 6 == 0)
            return ("APP");

    }

    return (eventCode.ToString());

}

int SumOddIndexElements(List<int> numbers)
{
    int sum = 0;

    for (var i = 0; i < numbers.Count; i++)

        if (!(i % 2 == 0))
            sum += numbers[i];

    return sum;

}


bool ValidateApiKeyAccess(Dictionary<string, string> apiKeyMap, string apiKey, string requiredRole)
{

    if (apiKeyMap.ContainsKey(apiKey))

        if (apiKeyMap[apiKey] == requiredRole)

            return true;

    return false;

}

