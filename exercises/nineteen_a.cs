int SumDigitsOf(int number)
{
    var digit = number % 10;
    var rest = number / 10;

    if (rest == 0) return digit;

    return digit + SumDigitsOf(rest);
}
