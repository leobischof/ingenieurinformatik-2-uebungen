# A2 – Multi-Massenkonverter

## Aufgabe (in eigenen Worten)

Der Benutzer wählt eine Einheit (Kilogramm, Pfund oder Stone) und gibt eine Masse ein. Das Programm
rechnet sie in die beiden **anderen** Einheiten um. Einheiten-Abkürzungen und Umrechnungsfaktoren
sind Konstanten. Ungültige Eingaben werden so lange erneut abgefragt, bis sie stimmen: eine
Menüwahl außerhalb von 1–3, ein Text statt einer Zahl oder eine negative Masse. Nach jeder
Umrechnung fragt das Programm, ob eine weitere folgen soll (Ja/Nein).

Umrechnungsfaktoren: **1 kg = 2,20462 lbs**, **1 st = 6,35029 kg** (= 14 lbs). Gerechnet wird immer
über Kilogramm als Basiseinheit, deshalb reichen zwei Faktoren.

## Klassisch vs. Modern

| Aspekt | Klassisch | Modern |
|--------|-----------|--------|
| Programmrahmen | `class Program` + `Main`, alles in `Main` | Top-Level-Statements + lokale Funktionen |
| Konstanten | `const` in `Program`, GROSSBUCHSTABEN, Menünummern als `const int` | `const` in eigener Klasse `Massenumrechnung` (PascalCase) |
| Einheiten | Menünummern 1/2/3 als Konstanten | `enum Masseneinheit` (eigene Datei) |
| Massenprüfung | **bewusst geschachtelte Verzweigung** (`if TryParse { if negativ … }`) | Guard Clauses mit `continue` |
| Umrechnung | `switch`-Anweisung + drei `if (auswahl != …)` | Switch-Ausdrücke, `Enum.GetValues<T>().Where(...)` (LINQ) |
| Ja/Nein | `if`/`else if` mit `||` | Switch-Ausdruck mit `or`-Mustern |
| Ausgabeformat | Platzhalter `{0:F2}` | Interpolation `$"{wert:F2}"` |

## Starten

```powershell
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A2_Multi-Massenkonverter/Klassisch"
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A2_Multi-Massenkonverter/Modern"
```

## Beispiel-Ausgabe (Klassisch, identisch mit Modern)

Testlauf mit den Eingaben aus der Angabe: `1`, `20`, `Ja`, `3`, `10`, `Nein`. Weil die Eingabe
umgeleitet ist, erscheinen die eingegebenen Werte selbst nicht in der Ausgabe.

```text
Willkommen zum Masseneinheitenkonverter!
Wählen Sie eine Masseneinheit aus:
1. Kilogramm (kg)
2. Pfund (lbs)
3. Stone (st)

Ihre Auswahl: Geben Sie die Masse in der ausgewählten Einheit ein: 
Die Masse in den anderen Einheiten:
Pfund: 44,09 lbs
Stone: 3,15 st

Möchten Sie eine weitere Umrechnung durchführen? (Ja/Nein): 
Wählen Sie eine Masseneinheit aus:
1. Kilogramm (kg)
2. Pfund (lbs)
3. Stone (st)

Ihre Auswahl: Geben Sie die Masse in der ausgewählten Einheit ein: 
Die Masse in den anderen Einheiten:
Kilogramm: 63,50 kg
Pfund: 140,00 lbs

Möchten Sie eine weitere Umrechnung durchführen? (Ja/Nein): Das Programm wird beendet.
```

Die Werte stimmen mit dem Screenshot der Angabe überein (44,09 lbs / 3,15 st bzw. 63,50 kg /
140,00 lbs).

## Hinweise

- Eingaben folgen der Ländereinstellung. Auf einem deutschen System gibt man `2,5` ein. `2.5` wird
  dort als `25` gelesen, weil der Punkt als Tausendertrennzeichen gilt.
- `NaN` und `∞` würden von `double.TryParse` akzeptiert. Sie werden ausdrücklich abgelehnt.
- Eine Masse von 0 ist erlaubt, nur negative Werte sind ungültig.
- Endet die Eingabe (EOF), beendet sich das Programm mit einer Meldung, statt endlos zu fragen.
