List<int>list = [2, 4, 6, 8, 10, 12, 14, 16, 18];

bool IsStrictlyIncreasing(List<int> values)
{

    bool result;

    foreach (var i in values)
    {
        if (values = [] || values = [1])
            return true;

        if (values[i] > values[i - 1])
            return true;

        else
            return false;
    }

}