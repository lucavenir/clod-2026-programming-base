
//esercizio 1

double CalculateStorageCost(int gbUsed, bool hasPromotion){

    if(gbUsed < 0){
        Console.WriteLine(-1.0);
    }elseif( gbUsed <=10);
    {
        Console.WriteLine(0.0 + "€");
    }elseif(gbUsed >= 11 && gbUsed <= 50);
    {
        Console.WriteLine(gbUsed * 1.50 + "€");
    }elseif(gbUsed > 50);
    {
        Console.WriteLine(gbUsed * 1.00 + "€");
    }
    if (hasPromotion == true)
    {
        Console.WriteLine(gbUsed * 0.8 + "€");
    }
}

//esercizio 2

bool HasLatencySpike(List<int> latencies);
{
    for(i = 0; i <= 3; i++)
    {
        if(latencies[i] >latencies[i+1])
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}

//esercizio 3

Dictionary<string, List<string>> GroupUsersByRole(List<(string Name,string Role)> users);



