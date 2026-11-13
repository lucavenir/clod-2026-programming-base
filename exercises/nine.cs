List<string> serverLogs = [
    "09:00 - Server Boot",
    "09:01 - User Login",
    "09:05 - Out of Memory"
];

Console.WriteLine("PRIMA");
Console.WriteLine(String.Join("\n", serverLogs));
Console.WriteLine("DOPO");
Console.WriteLine(String.Join("\n", ReverseLog(serverLogs)));

List<string> ReverseLog(List<string> logs)
{
    List<string> reversed = [];
    for (var i = logs.Count - 1; i >= 0; i--)
    {
        reversed.Add(logs[i]);
    }

    return reversed;
}
