Console.WriteLine("Ciao mamma!");
List<int> ids = [1, 2, 3];

// invoke
PrintListElementByElement(ids);

// definition
void PrintListElementByElement(List<int> ids)
{
    foreach (var i in ids)
    {
        Console.WriteLine(i.ToString());
    }
}
