Dictionary<string, List<string>> GroupUsersByRole(List<(string Name, string Role)> users)
{
   var result = new Dictionary<string, List<string>>();

    foreach (var user in users)
    {
        if (!result.ContainsKey(user.Role))
            result.Add(user.Role, []);

        result[user.Role].Add(user.Name);
    }

    return result;
}


bool HasLatencySpike(List<int> latencies)
{

    if (latencies.Count() < 2)
        return false;

    for(var i=1; i<latencies.Count()-1; i++)
    {
        if (latencies[i] > latencies[i-1])
        {
            if (latencies[i] - latencies[i-1] >= 50)
                return true;
        }
            
    }

    return false;
}

double CalculateStorageCost(int gbUsed, bool hasPromotion)
{
    double price = 0;

    if (gbUsed<0)
        price = -1;

        else if (gbUsed<=10 && gbUsed>0)
            price = 0.0;

            else if (gbUsed>10 && gbUsed<=50)
                price = (gbUsed-10)*1.5;
            
                else if(gbUsed > 50)
                    price = 10 + gbUsed;   //* 10 perchè alla fine se da 0 a 50 sono 60$ e devo sottrarre
                                            //* i 50 giga che non calcolo nel prezzo il risultato è quello

    if (hasPromotion)
         price = price * 0.8;

        return price;
} 

