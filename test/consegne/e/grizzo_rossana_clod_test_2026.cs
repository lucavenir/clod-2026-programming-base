Console.WriteLine("---------------------------------");
Console.WriteLine("ESERCIZIO 1");
Console.WriteLine("*****************");
Console.WriteLine("test 1: ");
Console.WriteLine("input: "+0);
Console.WriteLine("output: "+ClassifyPingLatency(0));
Console.WriteLine("*****************");
Console.WriteLine("");
Console.WriteLine("*****************");
Console.WriteLine("test 2: ");
Console.WriteLine("input: "+90);
Console.WriteLine("output: "+ClassifyPingLatency(90));
Console.WriteLine("*****************");
Console.WriteLine("");
Console.WriteLine("*****************");
Console.WriteLine("test 3: ");
Console.WriteLine("input: "+350);
Console.WriteLine("output: "+ClassifyPingLatency(350));
Console.WriteLine("*****************");
Console.WriteLine("");
Console.WriteLine("*****************");
Console.WriteLine("test 4: ");
Console.WriteLine("input: "+500);
Console.WriteLine("output: "+ClassifyPingLatency(500));
Console.WriteLine("*****************");
Console.WriteLine("---------------------------------");

string ClassifyPingLatency(int pingMs){
    
 if(pingMs<=0){
    return "TIMEOUT";
 }
 else if(pingMs <=150){
    return "FAST";
 }
 else if(pingMs<=400){
    return "SLOW";
 }
 else{
    return "CRITICAL";
 }
}
List<string> logs=["A", "B", "C"] ;
List<string> reversedLogs=ReverseLogEvents(logs);
Console.WriteLine("ESERCIZIO 2");
Console.WriteLine("test1: ");
Console.WriteLine("input: "+String.Join(",",logs));
Console.WriteLine("output: "+String.Join(",",reversedLogs));
Console.WriteLine("---------------------------------");
List<string> ReverseLogEvents(List<string> logEvents)
{
    List<string> results = [];
    for(int i= logEvents.Count-1;i>=0; i--)
    {
        results.Add(logEvents[i]);
    }
    return results;
}


List<(string,string)> ipRecords=[("127.0.0.1","IT"),("12.12.12.12","US"),("13.16.17.19","IT"),("16.19.02.03","DE"),("45.89.56.127","DE")];

Dictionary<string,List<string>> results=GroupIpsByCountry(ipRecords);
Console.WriteLine("ESERCIZIO 3");
Console.WriteLine("test 1: ");
Console.WriteLine(" input: "+String.Join(",",ipRecords) );
Console.WriteLine(" output: " );
Console.WriteLine("{");
foreach(var element in results)
{
    Console.Write("   ");
    Console.Write(element.Key);
    Console.Write(" ");
    Console.Write("[");
    Console.Write(String.Join(",",element.Value));
    Console.WriteLine("]");

}
Console.WriteLine("}");
Console.WriteLine("---------------------------------");
Dictionary<string,List<string>> GroupIpsByCountry(List<(string Ip,string Country)> ipRecords)
{
    Dictionary<string,List<string>> ipsGroupedByCountry = new Dictionary<string, List<string>>();
    foreach(var entry in ipRecords )
    {
        if (!ipsGroupedByCountry.ContainsKey(entry.Country))
        {
            ipsGroupedByCountry[entry.Country]= [entry.Ip];
        }
        else
        {
            ipsGroupedByCountry[entry.Country].Add(entry.Ip);
        }
    }
    return ipsGroupedByCountry;
}


