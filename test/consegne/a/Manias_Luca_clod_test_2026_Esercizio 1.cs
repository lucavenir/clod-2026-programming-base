//devo restituire una funzione che se la cpu<0 o cpu>100 OPPURE la ram<0 o ram>100 dice: "INVALID_DATA"
//se la temperatura>85 OPPURE sia cpu che ram>90 restituisce: "CRITICAL"
//se invece cpu o ram>70 dice: "WARNING"
//altrimenti in tutti gli altri casi dice: "OK"


string EvaluateServerStatus(int cpu, int ram, int temperature)
{
    if (cpu < 0 || cpu > 100 || ram < 0 || ram > 100) 
    
    return "INVALID_DATA";

    if (temperature > 85 || cpu > 90 && ram > 90)

    return "CRITICAL";

    if (cpu > 70 || ram > 70)

    return "WARNING";

    else

    return "OK";
}