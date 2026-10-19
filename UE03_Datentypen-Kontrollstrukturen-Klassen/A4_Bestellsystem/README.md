# A4 – Bestellsystem

## Aufgabe (in eigenen Worten)

Ein Konsolen-Bestellsystem für ein Take-Away-Restaurant mit drei festen Gerichten. Jedes Gericht
hat Name, Preis und Zubereitungszeit und ist ein Objekt einer vereinfachten Klasse. Der Kunde wird
begrüßt und sieht die Speisekarte. Er wählt dann Gerichte und gibt jeweils an, ob er einen
Sonderwunsch hat. Ein Sonderwunsch erhöht den Preis um **10 %** und die Zubereitungszeit um
**5 Minuten**. Mit `0` schließt er die Bestellung ab. Wie im Screenshot ist damit die Frage „weitere
Gerichte oder fertig?“ in die Menüwahl eingebaut. Am Ende folgt eine Zusammenfassung: alle
bestellten Gerichte (mit Sonderwunsch), der Gesamtpreis und die **längste** Zubereitungszeit, nicht
die Summe, weil die Küche parallel kocht. Auch die Bestellung ist eine eigene Klasse.

Speisekarte: Burger 5,99 € / 15 min, Pizza 7,99 € / 20 min, Salat 4,49 € / 10 min.

Das Gericht auf der Speisekarte darf durch einen Sonderwunsch **nicht** verändert werden. Klassen
sind Referenztypen: Wer eine Referenz auf das Burger-Objekt hat und dort den Preis ändert, ändert den
Burger für alle folgenden Bestellungen.

## Klassisch vs. Modern

| Aspekt | Klassisch | Modern |
|--------|-----------|--------|
| Klassen | `Gericht`, `Bestellposition`, `Bestellung` mit public Feldern | `record Gericht`, `record Bestellposition`, `class Bestellung` mit Kapselung |
| Geld | `double` (im Kommentar erklärt, warum `decimal` besser wäre) | `decimal` (`5.99m`) |
| Sonderwunsch | Werte in die Position **kopiert** und dort erhöht | Position verweist auf das unveränderliche Gericht, Preis/Zeit sind **berechnete** Properties |
| Speisekarte | drei Variablen + `switch` | Array per Collection-Expression `[ … ]` + Index |
| Liste der Positionen | `List<Bestellposition>` (Begründung im Kommentar: wächst automatisch, kein Zähler) | private `List<…>` + `IReadOnlyList` nach außen |
| Summe/Maximum | `for`-Schleife mit `+=` und Maximumsuche | LINQ `Sum` / `Max` |
| Ausgabe der Gerichte | `for` + Komma außer beim letzten Eintrag | `string.Join(",\n", …)` |
| Eingabe/EOF | `do-while` je Frage, `return` bei `null` | lokale Funktionen mit nullable Rückgabe, `is not int auswahl` |

## Starten

```powershell
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A4_Bestellsystem/Klassisch"
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A4_Bestellsystem/Modern"
```

## Beispiel-Ausgabe (Klassisch, identisch mit Modern)

Testlauf mit den Eingaben aus dem Screenshot: `1`, `ja`, `extra Käse`, `3`, `nein`, `0`. Weil die
Eingabe umgeleitet ist, erscheinen die eingegebenen Werte selbst nicht in der Ausgabe.

```text
Willkommen im Restaurant! Hier ist unsere Speisekarte:
1. Burger - 5,99 €
2. Pizza - 7,99 €
3. Salat - 4,49 €
Bitte wählen Sie ein Gericht (1-3) oder 0, um die Bestellung abzuschließen:
Haben Sie einen Sonderwunsch? (ja/nein):
Geben Sie Ihren Sonderwunsch ein:
Bitte wählen Sie ein Gericht (1-3) oder 0, um die Bestellung abzuschließen:
Haben Sie einen Sonderwunsch? (ja/nein):
Bitte wählen Sie ein Gericht (1-3) oder 0, um die Bestellung abzuschließen:
Ihre Bestellung:
Burger (extra Käse),
Salat

Gesamtpreis: 11,08 €
Maximale Zubereitungszeit: 20 Minuten
```

Kontrolle: 5,99 € · 1,10 + 4,49 € = 11,079 € → **11,08 €**. Längste Zeit: Burger 15 + 5 = **20
Minuten** (Salat 10).

## Abweichungen vom Screenshot

- Preise werden mit dem Währungsformat `C` der Ländereinstellung ausgegeben: auf einem deutschen
  System `5,99 €`, auf einem österreichischen `€ 5,99`. Im Screenshot steht auf der Speisekarte
  `5.99 EUR`, und das `€` beim Gesamtpreis erscheint als `?` (fehlende UTF-8-Ausgabe).
- Nach dem letzten Gericht der Zusammenfassung steht kein Komma mehr.
- Ungültige Eingaben (Text, Zahl außerhalb 0–3, andere Antwort als ja/nein, leerer Sonderwunsch)
  werden mit einer Meldung erneut abgefragt. Wird gleich `0` gewählt, meldet das Programm „Sie haben
  nichts bestellt“. Endet die Eingabe (EOF), wird die Bestellung mit einer Meldung abgebrochen.
