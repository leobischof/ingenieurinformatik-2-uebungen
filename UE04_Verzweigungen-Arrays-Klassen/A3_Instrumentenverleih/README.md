# A3 – Instrumentenverleih

## Aufgabe (zusammengefasst)

Simuliert wird ein Verleih von Musikinstrumenten:

- Eine Klasse **`Instrument`** hat Seriennummer, Name und Verleihstatus. Der Status ist ein enum mit den Werten **`ReadyToRent`** und **`RentedOut`**. Der Konstruktor setzt Name und Seriennummer aus Parametern und den Status auf `ReadyToRent`.
- In `Main` wird zuerst ein Array mit vier Instrumenten direkt befüllt. Danach wird der User begrüßt und bekommt das Inventar samt Status angezeigt.
- Der User leiht ein Instrument aus, indem er dessen Seriennummer eingibt. Der Status wechselt dann auf `RentedOut`. Die Eingabe muss geprüft werden. Nach jedem erfolgreichen Verleih wird das Inventar erneut angezeigt.
- Ausleihen geht so lange, bis nichts mehr verfügbar ist oder der User das Programm beendet (`e`).

## Umsetzung und Entscheidungen

- **Seriennummer als `string`**: Mit Seriennummern rechnet man nicht. Führende Nullen blieben bei `int` nicht erhalten, und echte Seriennummern enthalten oft Buchstaben. Da alle Nummern dieses Verleihs numerisch sind, wird die Eingabe trotzdem auf „nur Ziffern“ geprüft.
- **Status nur über `Verleihen()` änderbar**: Es gibt keinen öffentlichen Setter. So prüft die Klasse selbst, dass nichts doppelt verliehen wird.
- Geprüfte Fehlerfälle: keine Zahl (auch leere Eingabe), unbekannte Seriennummer, bereits verliehen. `e` bzw. `E` beendet das Programm. Sind alle Instrumente verliehen, endet es automatisch. Bei Eingabeende (EOF) endet es ebenfalls sauber.

## Klassisch vs. Modern

| Thema | Klassisch | Modern |
|-------|-----------|--------|
| Klasse | `private readonly` Felder + `GetName()`, `GetSeriennummer()`, `GetStatus()` | Primary Constructor, `{ get; }` bzw. `Status { get; private set; }` |
| Verfügbarkeit | Methode `IstVerfuegbar()` | berechnete Property `IstVerfuegbar` |
| Suche | `foreach` + `break` | `FirstOrDefault` + Pattern `is not { } instrument` |
| „Nur Ziffern“ | `foreach` über die Zeichen, Vergleich mit `'0'`/`'9'` | `All(char.IsAsciiDigit)` |
| Noch etwas verfügbar? | `foreach` mit frühem `return` | `Any(...)` |
| Tabellenausgabe | `PadRight` | Interpolation mit Alignment `{name,-30}` |

## Starten

```bash
dotnet run --project UE04_Verzweigungen-Arrays-Klassen/A3_Instrumentenverleih/Klassisch
dotnet run --project UE04_Verzweigungen-Arrays-Klassen/A3_Instrumentenverleih/Modern
```

## Beispiel-Ausgabe (echter Testlauf, beide Versionen identisch)

Eingabe: `324385`, `abc`, `999`, `324385` (doppelt), `e`

```text
Willkommen beim Instrumentenverleih!

Hier sind unsere verfügbaren Instrumente. Bitte geben Sie die Seriennummer des Instruments an, das Sie entlehnen möchten.
Wenn Sie das Programm beenden möchten, drücken Sie e.

Bezeichnung                   Seriennummer  Status

Yamaha YCL Klarinette         | 494773      | ReadyToRent
Olds Recording Trompete       | 324385      | ReadyToRent
Stradivari Geige              | 654435      | ReadyToRent
Pearl Roadshow Schlagzeug     | 847473      | ReadyToRent

324385
Sie haben Olds Recording Trompete ausgeliehen. Vielen Dank.

Hier sind unsere verfügbaren Instrumente. Bitte geben Sie die Seriennummer des Instruments an, das Sie entlehnen möchten.
Wenn Sie das Programm beenden möchten, drücken Sie e.

Bezeichnung                   Seriennummer  Status

Yamaha YCL Klarinette         | 494773      | ReadyToRent
Olds Recording Trompete       | 324385      | RentedOut
Stradivari Geige              | 654435      | ReadyToRent
Pearl Roadshow Schlagzeug     | 847473      | ReadyToRent

abc
Ungültige Eingabe: Bitte geben Sie eine Seriennummer (nur Ziffern) oder e ein.
999
Es gibt kein Instrument mit der Seriennummer 999.
324385
Das Instrument Olds Recording Trompete (324385) ist bereits verliehen. Bitte wählen Sie ein anderes Instrument.
e
Sie haben das Programm beendet.
```

Wenn alle vier Instrumente verliehen sind (Eingabe `494773`, `324385`, `654435`, `847473`), endet das Programm von selbst:

```text
Yamaha YCL Klarinette         | 494773      | RentedOut
Olds Recording Trompete       | 324385      | RentedOut
Stradivari Geige              | 654435      | RentedOut
Pearl Roadshow Schlagzeug     | 847473      | RentedOut

Alle Instrumente sind verliehen. Das Programm wird automatisch beendet.
```
