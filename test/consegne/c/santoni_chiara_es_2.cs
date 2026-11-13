
List<(string, int)> AnonymizeUserIds(List<int>userIds, int n);
int n=0;
foreach(var n in userIds)
{
    if (n < 5000)
    {
        return n;
    }
    else
    {
       return(Console.WriteLine("ANONYMOUS"));
    }
}
//Mi da errore, ma non riesco a capire come migliorarlo.
// L'errore (12,15) non lo capisco (Non è possibile convertire in modo implicito il tipo 'void' in 'int') :')
