using System.Linq.Expressions;

int gbUsed=60;

bool hasPromotion=false;

Console.WriteLine($"The final cost of your {gbUsed} GB is :{CalculateStorageCost(gbUsed,hasPromotion)} dollars");


double CalculateStorageCost(int gbUsed, bool hasPromotion){

    /*Se gbUsed < 0 → restituisce -1.0.
    Fino a 10 GB compresi → 0.0€.
    Da 11 a 50 GB compresi → i GB oltre i 10 costano 1.50€ al GB.
    Oltre i 50 GB → i primi 10 gratis, da 11 a 50 costano 1.50€/GB (totale 60€), e ogni GB oltre 50 costa 1.00€/GB.
    Se hasPromotion == true, viene applicato uno sconto del 20% sul totale finale calcolato.
    */
    
    double final_cost = 0;
    if(gbUsed<0)
            return -1;
        else if(gbUsed<=10)
            return 0;
            else if(gbUsed<=50)
                final_cost = ((gbUsed - 10)*1.5);
                else final_cost = (gbUsed +50);

    if(hasPromotion==true)
        final_cost*=0.2;

    return final_cost;
}

List<int> latencies = [10, 20, 80, 85];

Console.WriteLine($"The control of latency skies has returned: {HasLatencySpike(latencies)}");

bool HasLatencySpike(List<int> latencies){

    int preweus_element=0;

    if(latencies.Count<2)
        return false;
    
    foreach(var element in latencies){
        if(((element-preweus_element)>50)&&element!=latencies[0])
            return true;
        preweus_element=element;
    }
    return false;
}

List<(string Name, string Role)> users = [
    ("Nome","Ruolo"),
    ("AAAA","Ruolo"),
    ("BBBB","Si"),
];

foreach(var element in GroupUsersByRole(users))
{
    Console.WriteLine($"{element.Key}: {string.Join(", ",element.Value)}");
}

Dictionary<string, List<string>> GroupUsersByRole(List<(string Name, string Role)> users){
    Dictionary<string,List<string>> Final = new();

    foreach(var element in users){
        if (!Final.ContainsKey(element.Role))
            Final[element.Role]= new List<string>();
        Final[element.Role].Add(element.Name);
    } 

    return Final;
}
