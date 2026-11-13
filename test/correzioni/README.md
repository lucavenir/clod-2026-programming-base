# Correzioni

Una cartella per studente, con numero del registro, nome, cognome e traccia.
Ogni cartella contiene tre file iniziali autonomi: `E1_CORREZIONE.cs`, `E2_CORREZIONE.cs` e `E3_CORREZIONE.cs`.
I quattro precedenti file complessivi della traccia A sono stati sostituiti da questa struttura.

## Esecuzione

Dalla radice del repository, con .NET 10, eseguire un file alla volta:

```sh
dotnet run --file test/correzioni/13_luca_manias_A/E1_CORREZIONE.cs
dotnet run --file test/correzioni/13_luca_manias_A/E2_CORREZIONE.cs
```

Un errore di compilazione blocca soltanto il file in esecuzione.

## Contenuto dei file

La parte attiva contiene soltanto il codice dell’esercizio e i suoi test, copiati senza modifiche da `test/a.cs` … `test/f.cs`.
Per richiamare le funzioni sono stati aggiunti una classe contenitore e, dove mancavano, i modificatori `public static`.
Non sono stati corretti firme, nomi, sintassi o algoritmi degli studenti.
I frammenti malformati sono conservati; per un esercizio mancante è presente un `#error` esplicito.

In fondo a ciascun file i sorgenti originali di riferimento sono conservati integralmente sotto `#if false`, inclusi commenti e chiamate dimostrative. Non vengono compilati.
Le consegne in `test/consegne/` e i modelli dei test non sono stati modificati.

## Risultati

[ESITI.md](ESITI.md) contiene gli esiti dei 72 esercizi; [esiti.csv](esiti.csv) contiene il dettaglio importabile in un foglio di calcolo.
Questi due file descrivono la fase iniziale, senza voti né correzioni.

## Valutazione con malus

La valutazione successiva è in [valutazioni.csv](valutazioni.csv), con il dettaglio per esercizio in [valutazioni_dettaglio.csv](valutazioni_dettaglio.csv). Criteri, malus concordati e interventi sono descritti in [VALUTAZIONE.md](VALUTAZIONE.md).
Sono state aggiunte sei copie `E*_corretto.cs` per i piccoli errori recuperabili; i file iniziali sono conservati. Il CSV principale segue le 14 colonne del foglio del docente e comprende tutti i 24 studenti; Ciluffo Alex ha tutti zero. La colonna malus nome file è presente a zero perché non è stata valutata.

## Test rafforzati

I modelli delle sei tracce e tutte le copie dei test sono stati aggiornati a 177 casi. Esiti e copertura sono in [TEST_RAFFORZATI.md](TEST_RAFFORZATI.md). I CSV sono rimasti invariati su richiesta del docente e non riflettono queste nuove verifiche.

## CSV finali per esercizio

Importare [E1](valutazioni_E1.csv), [E2](valutazioni_E2.csv) ed [E3](valutazioni_E3.csv), aggiornati ai test rafforzati. Formato e calcolo sono descritti in [CSV_ESERCIZI.md](CSV_ESERCIZI.md). I CSV precedenti restano come storico.
