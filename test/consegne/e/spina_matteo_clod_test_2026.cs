// traccia E, file: "spina_matteo_clod_test_2026.cs"

// Esercizio 1
string ClassifyPingLatency(int pingMs)
{
    switch (pingMs)
    {
        // Se pingMs <= 0 → restituisce "TIMEOUT".
        case <= 0: return "TIMEOUT";
        // Se pingMs > 0 e ≤ 150 → restituisce "FAST".
        case <= 150: return "FAST";
        // Se pingMs > 150 (e ≤ 400) → restituisce "SLOW".
        case <= 400: return "SLOW";
        // Se pingMs > 400 → restituisce "CRITICAL".
        default: return "CRITICAL";
    }
}

// test 
Console.WriteLine("== EX 1 ==");
List<int> testPings = [12, 430, 0, 10, 150, -1, 400];
foreach (var ping in testPings)
{
    Console.WriteLine($"{ping} --> {ClassifyPingLatency(ping)}");
}

// ===========
// Esercizio 2
List<string> ReverseLogEvents(List<string> logEvents)
{
    List<string> reversed = [];
    for (int i = logEvents.Count - 1; i >= 0; i--)
    {
        reversed.Add(logEvents[i]);
    }
    return reversed;
}

//test
List<string> testLogEvents = ["A", "B", "C", "D", "", "F"];
Console.WriteLine("== EX 2 ==");
Console.WriteLine($"{string.Join(",", ReverseLogEvents(testLogEvents))}");

// ===========
// Esercizio 3
Dictionary<string, List<string>> GroupIpsByCountry(List<(string Ip, string Country)> ipRecords)
{
    Dictionary<string, List<string>> countryGroups = new();
    foreach (var record in ipRecords)
    {
        // note: check case so "IT" and "it" are the same key
        if (!countryGroups.ContainsKey(record.Country.ToUpper()))
        {
            // key is not present so add the key and associate it to an empty list
            // add the upper case version
            countryGroups.Add(record.Country.ToUpper(), []);
        }
        countryGroups[record.Country.ToUpper()].Add(record.Ip);
    }
    return countryGroups;
}

//test
Console.WriteLine("== EX 3 ==");

List<(string Ip, string Country)> testIpRecords =
[("1.1.1.1", "US"), ("2.2.2.2", "DE"), ("3.3.3.3", "IT"), ("4.4.4.4", "IT"), ("2.2.2.3", "DE"), ("4.4.4.3", "it")];
Dictionary<string, List<string>> testGroups = GroupIpsByCountry(testIpRecords);
foreach (var item in testGroups)
{
    var ipStrings = string.Join(", ", item.Value);
    Console.WriteLine($"{item.Key} : {ipStrings}");
}