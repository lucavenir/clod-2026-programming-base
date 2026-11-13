# Verifica dei test rafforzati

I modelli `test/a.cs` … `test/f.cs` e tutte le 78 copie negli esercizi degli studenti sono stati sincronizzati. I corpi delle funzioni, gli interventi minimi già effettuati e i sorgenti originali archiviati sono rimasti invariati. Non sono state ricostruite altre soluzioni.

**I CSV precedenti non sono stati aggiornati.** I nuovi `valutazioni_E1.csv`, `valutazioni_E2.csv` e `valutazioni_E3.csv` usano questi esiti. `valutazioni.csv`, `valutazioni_dettaglio.csv`, `esiti.csv` e i precedenti resoconti descrivono le verifiche precedenti; non rappresentano i risultati qui sotto.

## Copertura

| Traccia | E1 | E2 | E3 | Totale |
| --- | --- | --- | --- | --- |
| A | 19 | 10 | 8 | 37 |
| B | 12 | 11 | 8 | 31 |
| C | 11 | 8 | 8 | 27 |
| D | 9 | 8 | 8 | 25 |
| E | 8 | 8 | 8 | 24 |
| F | 14 | 11 | 8 | 33 |

Totale: **177 test**, rispetto ai 63 precedenti. I metodi preesistenti sono conservati, con controlli più completi dove prima verificavano solo parte del risultato.

- E1: casi di confine, priorità fra regole sovrapposte, fasce di prezzo e sconti in fasce diverse.
- E2: liste vuote, un elemento, due elementi e liste più lunghe; duplicati, ultima posizione e conservazione dell’ordine quando richiesta. Per la latenza anche salto di 50 ms dentro una lista lunga e picco che ripete il primo valore.
- E3: tutte le chiavi e i valori attesi, cardinalità della mappa, frequenze diverse, duplicati e gruppi intercalati. I raggruppamenti verificano i contenuti, senza imporre l’ordine dei gruppi o degli elementi del gruppo. Le stringhe vuote sono contate/conservate: le specifiche non prevedono di filtrare gli elementi ricevuti.
- Nessuna nuova precondizione su null, mutabilità degli input o ordine delle chiavi. Non vengono introdotte regole di normalizzazione dei ruoli, dei Paesi o dei protocolli non specificate; per le frequenze delle parole si verifica il minuscolo richiesto dalla traccia F.

## Validazione

Tutti i 177 test passano su 18 implementazioni di riferimento temporanee, una per esercizio di ciascuna traccia, verificate prima di usare i risultati delle consegne. La validazione verifica che i casi attesi siano coerenti con le regole; non dimostra una copertura esaustiva di ogni input possibile.
Le stesse definizioni dei test sono presenti in ogni copia della stessa traccia/esercizio, sia nei file iniziali sia nelle sei copie `_corretto.cs`.

Su 72 esercizi: 29 con tutti i test superati, 17 con test falliti, 22 non compilabili e 4 mancanti. Non sono stati ricalcolati voti o malus.

## Esiti delle consegne

Le frazioni indicano test superati / test previsti. Per i sei esercizi già corretti è eseguita la relativa copia `_corretto.cs`; negli altri casi è eseguito `E*_CORREZIONE.cs`.

| # | Studente | Traccia | E1 | E2 | E3 |
| --- | --- | --- | --- | --- | --- |
| 1 | AKI KOMI SYLVAIN | A | Non compila | Non compila | Non compila |
| 2 | BON DANIEL | B | 7/12 | 10/11 | 8/8 |
| 3 | CALÒ CAMILLA | C | 7/11 | 4/8 | 3/8 |
| 4 | CECHET DEVIS | D | 9/9 | 8/8 | 8/8 |
| 5 | CHAKICH MOHAMAD | E | 8/8 | Non compila | Mancante |
| 6 | CILUFFO ALEX | F | Mancante | Mancante | Mancante |
| 7 | DE MARCHI NICOLA MARIO | A | 19/19 | 10/10 | 8/8 |
| 8 | EPIE DIMITRI EWANG | B | 4/12 | 7/11 | Non compila |
| 9 | FRANZONI GABRIELE | C | 11/11 | Non compila | Non compila |
| 10 | GRATTONI GABRIELE | D | 9/9 | 8/8 | 8/8 |
| 11 | GRIZZO ROSSANA | E | 8/8 | 8/8 | 8/8 |
| 12 | LACCHIN FILIPPO | F | 5/14 | Non compila | Non compila |
| 13 | MANIAS LUCA | A | 19/19 | 7/10 | Non compila |
| 14 | MASTRO CLAUDIO | B | 11/12 | 7/11 | 8/8 |
| 15 | MEHNI NOUFAL | C | Non compila | Non compila | Non compila |
| 16 | NARDER ALBERTO | D | Non compila | Non compila | Non compila |
| 17 | NERI LEONARDO | E | 8/8 | 8/8 | 1/8 |
| 18 | NOGARÈ LEONARDO | F | 14/14 | 11/11 | 8/8 |
| 19 | PARO GIOVANNI | A | 13/19 | 5/10 | Non compila |
| 20 | PINATO EDDY | B | Non compila | Non compila | Non compila |
| 21 | SANTONI CHIARA | C | 7/11 | Non compila | Non compila |
| 22 | SOLONYSHYN MAKSYM | D | 9/9 | 8/8 | 8/8 |
| 23 | SPINA MATTEO | E | 8/8 | 8/8 | 8/8 |
| 24 | TEGON MOIRA | F | 14/14 | 6/11 | 7/8 |

L’output completo delle verifiche è in [VERIFICA_TEST_RAFFORZATI.log](VERIFICA_TEST_RAFFORZATI.log).
