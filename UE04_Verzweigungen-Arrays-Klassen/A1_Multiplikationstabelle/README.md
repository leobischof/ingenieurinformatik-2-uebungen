# A1 – Multiplikationstabelle

## Aufgabe (zusammengefasst)

Das kleine Einmaleins für die Zahlen 1 bis 10 soll in einem **zweidimensionalen Array** gespeichert werden. Eine Kopfzeile oder Kopfspalte gibt es nicht, nur die Produkte. Danach wird der Inhalt des Arrays übersichtlich, also rechtsbündig in Spalten, auf der Konsole ausgegeben (Tipp aus der Angabe: `ToString().PadLeft(...)`).

Konzepte: verschachtelte Schleifen, ein- und zweidimensionale Arrays.

## Klassisch vs. Modern

| Thema | Klassisch | Modern |
|-------|-----------|--------|
| Programmgerüst | `namespace { class Program { static void Main } }` | Top-Level-Statements |
| Hilfsmethoden | `static` Methoden der Klasse `Program` | `static` lokale Funktionen |
| Speicher | `int[,]` (laut Angabe) | `int[,]` (laut Angabe) |
| Befüllen | verschachtelte `for`-Schleifen | verschachtelte `for`-Schleifen (LINQ kann kein `int[,]` erzeugen) |
| Ausgabe einer Zeile | innere `for`-Schleife + `PadLeft` | `Enumerable.Range` + `Select` + `string.Concat`, Alignment `$"{wert,4}"` |

## Starten

```bash
dotnet run --project UE04_Verzweigungen-Arrays-Klassen/A1_Multiplikationstabelle/Klassisch
dotnet run --project UE04_Verzweigungen-Arrays-Klassen/A1_Multiplikationstabelle/Modern
```

## Beispiel-Ausgabe (echter Testlauf, beide Versionen identisch)

```text
Multiplikationstabelle von 1 bis 10:

   1   2   3   4   5   6   7   8   9  10
   2   4   6   8  10  12  14  16  18  20
   3   6   9  12  15  18  21  24  27  30
   4   8  12  16  20  24  28  32  36  40
   5  10  15  20  25  30  35  40  45  50
   6  12  18  24  30  36  42  48  54  60
   7  14  21  28  35  42  49  56  63  70
   8  16  24  32  40  48  56  64  72  80
   9  18  27  36  45  54  63  72  81  90
  10  20  30  40  50  60  70  80  90 100
```
