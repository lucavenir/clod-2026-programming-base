//accetta una lista di codici HTTP e restituisce l'indice dell'ultimo codice relativo ad un errore
//se non è presente alcun errore nella lista deve restituire -1
//gli errori del server sono dal 500 in su
//devo usare un list lenght

int FindLastServerErrorIndex(List<int> statusCodes)
{
for (i = 0, i < statusCodes.LongCount, i++)
    {
        if (statusCodes[i] >= 500)
            return i;
    }

    return -1;
}

