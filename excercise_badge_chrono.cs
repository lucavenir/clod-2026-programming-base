Console.WriteLine("ciaooo");

Console.WriteLine(computeWorker(2));
Console.WriteLine(computeWorker(3));
Console.WriteLine(computeWorker(20));

Console.WriteLine(9);

Console.WriteLine(computeChrono(3661));


// funzione che ritorna se sei A o B, e se sei capoturno o no
(string, bool) computeWorker(int badge)
{
    var shift = badge % 2 == 0 ? "A" : "B";
    var isBoss = badge % 10 == 0;
    return (shift, isBoss);
}

// funzione che accetta solo i secondi di un cronometro
// che non è in grado di misurare anche minuti e ore
// ... e deve ritornare una tripletta che rappresenta ore, minuti e i secondi
(int, int, int) computeChrono(int seconds)
{
    var hours = seconds / 3600;
    var minutes = (seconds % 3600) / 60;
    var s = seconds % 60;

    return (hours, minutes, s);
}