var acl = new Dictionary<string, string>();
acl["luca@piero.franco"] = "USER";
acl["mandi@ciao.hello"] = "ADMIN";
acl["monica@francesca.ilaria"] = "GUEST";

Console.WriteLine(Acl(acl, ("spina.matteo@itsaltoadriatico.it", "SUPERADMIN")));
Console.WriteLine(Acl(acl, ("luca@piero.franco", "ADMIN")));
Console.WriteLine(Acl(acl, ("monica@francesca.ilaria", "GUEST")));
Console.WriteLine(Acl(acl, ("mandi@ciao.hello", "USER")));


int Acl(Dictionary<string, string> map, (string id, string role) input)
{
    foreach (var entry in map)
    {
        // se sono presente nella ACL
        if (entry.Key == input.id)
        {
            // allora...
            // ... se ho anche il ruolo che era definito nell'ACL stessa...
            if (entry.Value == input.role)
            {   // ho vinto!
                return 200;
            }
            else
            {   // vuol dire che sono nella ACL, ma il ruolo è errato
                return 403;
            }
        }
    }

    return 401;
}
