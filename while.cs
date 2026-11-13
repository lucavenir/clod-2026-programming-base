List<int> list = [1, 2, 3, 4, 5];

var i = 0;
while (i < list.Count)
{
    Console.WriteLine(list[i] * 2);
    i++;
}

//

for (var i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i] * 2);
}

// ALGORITMO DI EUCLIDE

int Mcd(int a, int b)
{
    while (b > 0)
    {
        var r = a % b;
        a = b;
        b = r;
    }

    return a;
}
