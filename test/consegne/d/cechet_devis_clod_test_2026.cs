//ESERCIZIO 1 - Categorizzazione Eventi di Sistema

string CategorizeEventCode(int eventCode)
{
    if (eventCode <= 0)
    {
        return "INVALID";
    }

    if (eventCode % 4 == 0 && eventCode % 6 == 0)
    {
        return "CRITICAL_SYS_APP";
    } else if (eventCode % 4 == 0 && eventCode % 6 != 0)
    {
        return "SYS";
    } else if (eventCode % 6 == 0 && eventCode % 4 != 0)
    {
        return "APP";
    }

    return eventCode.ToString();
}

//ESERCIZIO 2 - Somma Elementi di Indice Dispari

int SumOddIndexElements(List<int> numbers)
{
    var sum = 0;

    for (int i = 0; i < numbers.Count; i++)
    {
        if (i % 2 != 0)
        {
            sum += numbers[i];
        }
    }

    return sum;
}

//ESERCIZIO 3 - Verifica Permessi API Key

bool ValidateApiKeyAccess(Dictionary<string, string> apiKeyMap, string apiKey, string requiredRole)
{
    foreach (var element in apiKeyMap)
    {
        if (element.Key == apiKey)
        {
            if (element.Value == requiredRole)
            {
                return true;
            }
        }
    }

    return false;
}