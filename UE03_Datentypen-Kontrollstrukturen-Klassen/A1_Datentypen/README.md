# A1 – Datentypen

## Aufgabe (in eigenen Worten)

Das Programm fragt so lange nach einer Eingabe, bis genau **ein** Zeichen eingegeben wurde. Dieses
Zeichen wird als `char` gespeichert, seine Zahl (der Zeichencode) separat als `int`. Der Zahlenwert
wird ausgegeben. Danach geht er in eine `double`-Variable, die mit 1,3 multipliziert wird. Dazu
kommt eine `float`-Variable mit dem Wert 2,56. Die Summe der beiden wird ausgegeben, anschließend
mit `(int)` in eine Ganzzahl umgewandelt und noch einmal ausgegeben. Die drei Fragen der Angabe sind
im Code als Kommentar beantwortet und stehen auch unten.

## Klassisch vs. Modern

| Aspekt | Klassisch | Modern |
|--------|-----------|--------|
| Programmrahmen | `namespace { class Program { static void Main } }` | Top-Level-Statements |
| Eingabeschleife | `do-while` + Längenprüfung `eingabe.Length != 1` | `while (true)` + `char.TryParse(eingabe, out zeichen)` |
| string → char | `char.Parse(eingabe)` (nach der Prüfung) | übernimmt `char.TryParse` |
| null-Prüfung (EOF) | `eingabe == null` | `eingabe is null` (Pattern Matching) |
| Ausgabe | String-Verkettung mit `+` | String-Interpolation, zusätzlich `{x:X4}` (Unicode-Hex) und `{x:F2}` |
| Datentypen | explizit (`char`, `int`, `double`, `float`) | ebenfalls explizit, bewusst kein `var` |

## Starten

```powershell
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A1_Datentypen/Klassisch"
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A1_Datentypen/Modern"
```

## Beispiel-Ausgabe (Klassisch)

Testlauf mit umgeleiteter Eingabe `ab`, *(leere Zeile)*, `a`. Bei umgeleiteter Eingabe erscheinen
die eingegebenen Werte nicht in der Konsole, deshalb stehen die Meldungen direkt hinter den Fragen.

```text
Bitte geben Sie ein einzelnes Zeichen ein: Ungültige Eingabe: "ab" besteht aus 2 Zeichen. Bitte genau EIN Zeichen eingeben.
Bitte geben Sie ein einzelnes Zeichen ein: Ungültige Eingabe: "" besteht aus 0 Zeichen. Bitte genau EIN Zeichen eingeben.
Bitte geben Sie ein einzelnes Zeichen ein: Numerische Repräsentation von 'a': 97
double-Wert (97 * 1,3): 126,10000000000001
float-Wert: 2,56
Summe (double + float): 128,65999994277956
Summe als int: 128
```

Die moderne Version gibt zusätzlich `(Unicode U+0061)` und `(gerundet angezeigt: 128,66)` aus.

## Antworten auf die Fragen

**1. Warum haben Zeichen eine numerische Repräsentation?**
Ein Computer speichert nur Zahlen (Bits). Eine Zeichenkodierung legt fest, welche Zahl für welches
Zeichen steht. **ASCII** (7 Bit, 128 Zeichen) ordnet z. B. `'A'` = 65, `'a'` = 97 und `'0'` = 48 zu.
**Unicode** erweitert das auf alle Schriften der Welt, die ersten 128 Codepunkte sind identisch mit
ASCII. In C# ist ein `char` eine 16-Bit-Codeeinheit in **UTF-16** (0 bis 65535), z. B. `'ä'` = 228
und `'€'` = 8364. Weil Zeichen Zahlen sind, kann man sie vergleichen und sortieren (`'a' < 'b'`) und
mit ihnen rechnen (`'7' - '0'` = 7). Zeichen außerhalb von 16 Bit, etwa viele Emojis, bestehen in
UTF-16 aus zwei `char`s (Surrogat-Paar) und gelten im Programm deshalb als zwei Zeichen.

**2. Welchen Datentyp muss die Summe ohne explizite Konversion haben, und warum?**
`double`. Bei `double + float` wandelt C# den `float` automatisch (implizit) in einen `double` um.
`double` hat den größeren Wertebereich und die höhere Genauigkeit (ca. 15–16 statt ca. 7
signifikante Stellen). Diese **erweiternde** Konversion verliert keine Information, darum führt der
Compiler sie selbst durch, und das Ergebnis ist ein `double`. Für eine `float`-Summe wäre ein
expliziter Cast `(float)` nötig. Dass die Summe „krumm“ ist (128,65999994277956 statt 128,66),
liegt daran, dass sich 2,56 als `float` und 1,3 als `double` binär nicht exakt darstellen lassen.

**3. Was beobachtet man bei der Konversion nach `int`?**
Die Nachkommastellen werden **abgeschnitten, nicht gerundet** (Richtung 0): 128,66 → 128,
128,99 → 128, −2,7 → −2. Der Cast `(int)` muss ausdrücklich dastehen, weil dabei Information verloren
geht (Nachkommastellen, kleinerer Wertebereich). Wer runden will, schreibt `(int)Math.Round(summe)`.
