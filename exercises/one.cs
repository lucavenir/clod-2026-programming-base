List<int> list = [11, -2, 63, 14, 0];

var sum = 0;
for (var i = 0; i < 5; i++)
{
    Console.WriteLine("iterazione i: " + i);
    Console.WriteLine("elemento: " + list[i]);
    Console.WriteLine("somma prima: " + sum);
    sum = sum + list[i];
    Console.WriteLine("somma dopo: " + sum);
}

Console.WriteLine("somma finale: " + sum);
