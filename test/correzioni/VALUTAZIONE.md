# Valutazione dopo gli interventi minimi

> Resoconto precedente al rafforzamento dei test. I CSV e i punteggi qui documentati non sono stati aggiornati, su richiesta del docente. Per la verifica attuale vedere [TEST_RAFFORZATI.md](TEST_RAFFORZATI.md).

Il file da importare in Google Sheets è [valutazioni.csv](valutazioni.csv): 24 righe, una per studente, nelle 14 colonne e nello stesso ordine del foglio del docente. Ciluffo Alex è incluso con tutti i punteggi, malus e totale a zero. Le annotazioni dei tre esercizi e gli interventi sono riuniti nella colonna NOTE. Il codice di Aki Komi è allineato ai valori già presenti nel foglio: E1 2, E2 0, E3 0, totale 2; questi valori sostituiscono la precedente proposta e non hanno sottopunteggi specificati dal docente.

Formato: UTF-8 con BOM, separatore punto e virgola, virgola decimale. Importare con impostazioni locali Italia e separatore `;` (oppure rilevamento automatico). Nelle note e nel dettaglio gli esiti sono scritti come «3 su 4» per evitare che il foglio li interpreti come date.

[valutazioni_dettaglio.csv](valutazioni_dettaglio.csv) contiene 72 righe, una per esercizio, con i tre sottopunteggi del codice, i test, gli interventi e il percorso esatto del file eseguito.

## Correttezza e totale

- E1: massimo 18; E2: massimo 23; E3: massimo 23.
- Punti = massimo dell’esercizio × test superati / test previsti. Ogni metodo di test ha lo stesso peso all’interno dell’esercizio. Arrotondamento a due decimali, metà verso l’alto.
- Tutti i test superati = massimo della correttezza, senza ulteriori riduzioni manuali per errori logici notati leggendo il codice.
- Non compilabile o non consegnato = 0 punti di correttezza. È una convenzione di assegnazione: i test non sono stati eseguiti e non sono riportati come falliti. I relativi conteggi restano vuoti nel dettaglio.
- Piccoli errori corretti: −2 punti per esercizio, indipendentemente dal numero di refusi locali.
- Nome della funzione corretto: −1 punto per esercizio. I nomi dei parametri o delle variabili rientrano nei piccoli errori, non nei nomi delle funzioni.
- La colonna MALUS: NOME FILE (-1) è presente e impostata a zero per tutti: questa penalità non è stata valutata né applicata; non è stato definito un criterio sui nomi delle consegne.
- I malus applicati sono colonne negative, sommate ai sei punteggi. Nessun malus per interventi non effettuati o per il solo adattamento al contenitore di test.
- Totale = somma dei sei punteggi + i tre malus, con minimo zero. Massimo 100.

## Codice: 12 punti per esercizio

Valutazione manuale del codice originale, indipendente dal numero di test superati:

| Voce | Punti | Criterio |
| --- | --- | --- |
| Leggibilità | 0–4 | Nomi comprensibili, rientri, comprensibilità di condizioni e passaggi. |
| Ordine | 0–4 | Organizzazione dei blocchi, assenza di variabili inutili, duplicazioni e passaggi superflui. |
| Sensatezza della struttura | 0–4 | Uso coerente di tipi e strutture dati, accumulo o costruzione del risultato, collegamento fra ciclo, indici e obiettivo. |

Scala comune: 0 assente; 1 frammentario o fortemente incoerente; 2 discontinuo; 3 buono con limiti identificabili; 4 chiaro e coerente.
La somma delle tre voci è la colonna codice. Le annotazioni motivano sinteticamente i punti non assegnati o gli aspetti positivi.
Una firma senza implementazione vale 0; un tentativo incompleto può ricevere punti per ciò che è leggibile e riconoscibile.
I semplici refusi già coperti dal malus non comportano un’ulteriore sottrazione automatica alla qualità. La voce sensatezza riguarda la struttura: può diminuire anche se i test non coprono il problema osservato. È una valutazione proposta, soggettiva e rivedibile dal docente, non un risultato dei test.

## Confine degli interventi

Sono state prodotte sei copie `E*_corretto.cs`, conservando intatti i file `E*_CORREZIONE.cs` e tutte le consegne:

| Studente | Esercizio | Intervento | Test dopo la modifica | Malus |
| --- | --- | --- | --- | --- |
| Calò Camilla | E3 | Uniformato il maiuscolo/minuscolo di statuscodes. Conservata l’assegnazione = + 1. | 1 su 2 | −2 codice |
| Chakich Mohamad | E1 | ClassifyPingLatecy → ClassifyPingLatency. Conservato else; che genera solo un warning. | 5 su 5 | −1 nome |
| Epie Dimitri Ewang | E2 | Corretta l’unica chiamata Console.WriteLine incompatibile con due interi. | 3 su 4 | −2 codice |
| Lacchin Filippo | E1 | result / 2; → result /= 2;. La variabile non è mai restituita; formule e condizioni conservate. | 1 su 4 | −2 codice |
| Manias Luca | E2 | Dichiarazione int, separatori ; e proprietà Count nel for. Conservato il ritorno sul primo errore. | 3 su 4 | −2 codice |
| Santoni Chiara | E1 | Ripristinate le parentesi graffe della funzione e uniformato inInternal/isInternal. Conservato REDIRECT_HHTPS. | 4 su 5 | −2 codice |

Non sono stati modificati confronti, soglie, prezzi, stringhe dei risultati, aggregazioni o strategie algoritmiche per aumentare i test superati. Non sono state aggiunte implementazioni mancanti. I casi con tipi o strutture incoerenti che richiederebbero ricostruire il procedimento restano non compilabili. Il confine fra piccolo refuso e riscrittura è una scelta di correzione esplicitata qui, non una proprietà misurata dai test.

## Verifica e limiti

Sono stati verificati 69 esercizi: 46 hanno eseguito i test (33 con tutti i test superati, 13 con fallimenti), 22 non compilano, 1 non è consegnato. Malus totali: −10 per piccoli errori, −1 per nomi di funzioni.
I test sono quelli originali di `test/a.cs` … `test/f.cs`; le sei copie corrette mantengono integralmente gli stessi test del rispettivo file iniziale.

I test rendono riproducibile il punteggio sui casi presenti, ma non dimostrano la correttezza su tutti gli input. Per esempio E2 di Calò conserva soltanto l’ultimo elemento della lista, ma ottiene comunque 23/23 perché i tre test attuali provano solo la lista vuota e liste di un elemento. E3 della traccia F ha un solo test. Questi limiti sono conservati deliberatamente secondo la regola del docente; i test non sono stati ampliati durante la valutazione.

`ESITI.md` ed `esiti.csv` documentano la fase iniziale, prima di questi interventi; per questa valutazione usare i due nuovi CSV.

Per ripetere una verifica, eseguire singolarmente il percorso indicato nella colonna «File valutato» del dettaglio:

```sh
dotnet run --file test/correzioni/13_luca_manias_A/E2_corretto.cs
```

Il dettaglio comprende anche i tre esercizi mancanti di Ciluffo, senza nuove esecuzioni. I risultati delle 69 verifiche e tutti i file di codice rimangono invariati.
