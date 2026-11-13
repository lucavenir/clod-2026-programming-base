List<(string, string)> list = [("1.1.1.1", "IT"), ("2.2.2.2", "IT"), ("8.8.8.8", "AU")];


var result = LoadBalancer(list);
foreach (var entry in result)
{
    Console.Write(entry.Key);
    Console.Write(" ");
    Console.WriteLine(String.Join(", ", entry.Value));
}


Dictionary<string, List<string>> LoadBalancer(List<(string, string)> requests)
{
    var result = new Dictionary<string, List<string>>();
    foreach (var (ip, country) in requests)
    {
        if (result.TryGetValue(country, out List<string>? value))
        {
            value.Add(ip);
        }
        else
        {
            result[country] = [ip];
        }
    }

    return result;
}