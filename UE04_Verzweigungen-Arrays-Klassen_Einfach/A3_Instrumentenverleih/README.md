# UE04 – Aufgabe 3: Instrumentenverleih

## Was macht das Programm?

Es simuliert einen Instrumentenverleih mit vier Instrumenten. Zuerst siehst du eine Tabelle mit
Bezeichnung, Seriennummer und Status (`ReadyToRent` = frei, `RentedOut` = verliehen). Du gibst die
Seriennummer eines Instruments ein, es wird ausgeliehen, und die Tabelle erscheint neu. Falsche
Eingaben (Buchstaben, unbekannte Seriennummer, schon verliehenes Instrument) werden mit einer
Meldung abgefangen. Das Programm endet bei Eingabe von `e` oder von selbst, sobald alles verliehen ist.

## So zeigst du den Code

1. `Verleihstatus.cs`: Das **enum** mit den zwei Zuständen `ReadyToRent` und `RentedOut`.
2. `Instrument.cs`: Die Klasse mit drei `private` Feldern (Seriennummer, Name, Status), dem
   **Konstruktor** (setzt den Status auf `ReadyToRent`), den Get-Methoden und `Ausleihen()`.
3. `Program.cs`, `Main` oben: Das Array mit den vier Instrumenten, jedes `new Instrument(...)`
   ist ein Objekt.
4. `Main`, die `while (true)`-Schleife: Zuerst die Prüfung „alles verliehen?" (→ `break`), dann
   Eingabe lesen, bei `e` → `break`, dann `TryParse`, dann suchen und die zwei Fehlerfälle prüfen.
5. Die Hilfsmethoden `ZeigeInventar` (Tabelle mit `PadRight`), `SucheInstrument` (mit `break`)
   und `SindAlleVerliehen`.
6. Vorführen: `324385`, dann `abc`, `999`, nochmal `324385` (schon verliehen), dann `e`.

## Wahrscheinliche Fragen

- **Was ist ein enum?** Ein eigener Datentyp mit einer festen Liste erlaubter Werte. Der Status kann
  nur `ReadyToRent` oder `RentedOut` sein, ein Tippfehler wie `"verliehn"` wäre gar nicht möglich
  (bei einem String schon).
- **Was ist der Unterschied zwischen Klasse und Objekt?** Die Klasse `Instrument` ist der Bauplan,
  ein Objekt ist ein konkretes Instrument, das mit `new` daraus gebaut wird. Wir haben vier
  Objekte der einen Klasse. In Python: `class Instrument` und `Instrument(...)`.
- **Warum sind die Felder `private`?** Von außen soll niemand den Status einfach auf einen
  beliebigen Wert setzen können. Lesen geht über `GetStatus()`, ändern nur über `Ausleihen()`.
  Name und Seriennummer ändern sich nie, deshalb gibt es dafür nur Getter und keinen Setter.
- **Was macht der Konstruktor?** Er läuft automatisch bei `new Instrument(...)`. Er setzt Name und
  Seriennummer aus den Parametern und den Status auf `ReadyToRent`. In Python wäre das `__init__`.
- **Was macht `break`?** Es beendet sofort die Schleife, in der es steht. In `Main` verlässt es die
  `while (true)`-Schleife (bei `e` oder wenn alles verliehen ist), in `SucheInstrument` die
  `foreach`-Schleife, sobald das Instrument gefunden ist. Genau wie `break` in Python.
- **Und `continue`?** Es beendet nur den aktuellen Durchlauf und springt gleich zum nächsten. Bei
  einer Eingabe ohne Ziffern wird so nicht gesucht, sondern sofort neu gelesen. Auch wie in Python.
- **Was macht `int.TryParse`?** Es versucht, den Text in eine Zahl umzuwandeln, und liefert `true`,
  wenn das klappt. Die Zahl landet in `seriennummer` (das macht `out`). Bei `abc` gibt es `false`
  und damit die Fehlermeldung.

## Starten

```bash
dotnet run --project "UE04_Verzweigungen-Arrays-Klassen_Einfach/A3_Instrumentenverleih"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken.
