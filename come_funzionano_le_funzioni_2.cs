// "main": entry point / script / "dove inizia il programma"
List<string> example = ["ciao", "Piero", "no"];

var filtered = FilterByLength(example, 4);
var counted = MapToTheirLength(filtered);

Console.WriteLine(String.Join(" ", counted));


// --- function definitions

List<int> MapToTheirLength(List<string> list)
{
    List<int> result = [];
    foreach (var item in list)
    {
        result.Add(item.Length);
    }
    return result;
}

List<string> FilterByLength(List<string> list, int max)
{
    List<string> result = [];
    foreach (var item in list)
    {
        if (item.Length <= max)
        {
            result.Add(item);
        }
    }

    return result;
}
