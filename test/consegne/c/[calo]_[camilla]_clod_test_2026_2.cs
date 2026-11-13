List<string> AnonymizeUserIds(List<int> userIds)
{
    List<string> result = [];
    for(var i=0; i<userIds.Count; i++)
    {
        if(userIds[i] < 5000)
        {
            result = [userIds[i].ToString()];
        }
        if(userIds[i] >= 5000)
        {
            result = ["ANONYMOUS"];
        }
    }
    return result;
}
