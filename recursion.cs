fattoriale(3);

int fattoriale(int n)
{
    if (n == 1)
    {
        return 1;
    }

    return n * fattoriale(n - 1);
}
