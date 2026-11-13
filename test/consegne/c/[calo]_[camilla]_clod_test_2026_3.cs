Dictionary<int, int> CountHttpStatusCodeFrequency(List<int> statuscodes)
{
    Dictionary<int, int> result = [];
    for (var i = 0; i < statuscodes.Count; i++)
    {
        if (result.ContainsKey(statusCodes[i]))
        {
            result[statusCodes[i]] = + 1;
        }
        else
        {
            result.Add(statuscodes[i], 1);
        }
    }
    return result;


}