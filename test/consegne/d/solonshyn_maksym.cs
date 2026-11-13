namespace FundamentsOfPrograming;

public static class test1
{
    public static string CategorizeEventCode(int eventCode)
    {
        if (eventCode <= 0) return "INVALID";
        else if (eventCode % 4 == 0)
        {
            if (eventCode % 6 == 0) return "CRITICAL_SYS_APP";
            return "SYS";
        }
        else if (eventCode % 6 == 0) return "APP";
        return eventCode.ToString();
    }

    public static int SumOddIndexElements(List<int> numbers)
    {
        int sum = 0;
        for (int i = 1; i < numbers.Count; i += 2)
        {
            sum += numbers[i];
        }
        return sum;
    }

    public static bool ValidateApiKeyAccess(Dictionary<string, string> apiKeyMap, string apiKey, string requiredRole)
    {
        return (apiKeyMap.ContainsKey(apiKey) && apiKeyMap[apiKey] == requiredRole);
    }
}