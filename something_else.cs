int result = SubtractAbsolute(4, 5);
Console.WriteLine(result);

int SubtractAbsolute(int a, int b)
{
    if (a > b)
        return a - b;
    else
        return b - a;
}

int SubtractAbsolute2(int a, int b)
{
    return Math.Abs(a - b);
}