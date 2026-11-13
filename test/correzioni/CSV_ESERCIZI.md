# CSV per esercizio

Importare in Google Sheets con separatore `;`, impostazioni locali Italia. File UTF-8 con BOM, virgola decimale, 24 studenti in ordine di registro.

- `valutazioni_E1.csv`: correttezza 18 + qualità 12 = 30 punti.
- `valutazioni_E2.csv`: correttezza 23 + qualità 12 = 35 punti.
- `valutazioni_E3.csv`: correttezza 23 + qualità 12 = 35 punti.

Questi tre file usano gli ultimi 177 test di `test/a.cs` … `test/f.cs`, con gli esiti documentati in `TEST_RAFFORZATI.md` e nel relativo log. Sostituiscono, per l’importazione dei voti attuali, i CSV precedenti, che sono conservati senza modifiche.

Correttezza = massimo × test superati / test previsti, arrotondata a due decimali. Qualità e malus restano quelli già valutati: −1 per nome funzione corretto, −2 per esercizio con piccoli errori corretti. Totale esercizio = somma delle due valutazioni e dei due malus negativi, con minimo zero.

La colonna «# test passati» è numerica; nei commenti è indicato anche il rapporto sui test previsti. Zero per un esercizio non compilabile o mancante non significa che i test siano stati eseguiti: il commento distingue questi casi. Aki Komi ha zero test superati in tutti gli esercizi; resta la qualità 2/0/0 indicata dal docente. Ciluffo ha tutti zero. Non sono state effettuate altre correzioni al codice.

I commenti riportano problemi riscontrati, significato dei test falliti e dettagli di leggibilità pertinenti, senza penalità aggiuntive implicite.
