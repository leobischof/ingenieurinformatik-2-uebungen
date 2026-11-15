# UE07 – Fehlerbehandlung: Erklärung aller Aufgaben

Dieses Dokument erklärt jede Aufgabe in drei Schritten:
**1. Worum geht es?** · **2. Welche Konzepte braucht man?** · **3. Wie ist die Lösung aufgebaut, und warum so?**

| Aufgabe | Ordner | Kernthema |
| --- | --- | --- |
| 1 | [A1_DatumEinlesen](A1_DatumEinlesen/) | `try`/`catch`, mehrere `catch`-Blöcke |
| 2 | [A2_Ausschussquote](A2_Ausschussquote/) | eigenes `throw`, `finally` |
| 3 | [A3_Zugstab](A3_Zugstab/) | Exceptions in Klassen, verschachteltes `try`, `finally` |

---

## Grundlagen: Die drei Fehlerarten

| Fehlerart | Wann merkt man ihn? | Beispiel | Wer findet ihn? |
| --- | --- | --- | --- |
| **Syntaxfehler** | beim Kompilieren | fehlendes `;`, Tippfehler im Namen | der Compiler (rote Wellenlinie) |
| **Logischer Fehler** | nie automatisch | `<` statt `>`, falsche Formel | nur Testen und Nachrechnen |
| **Laufzeitfehler** | während das Programm läuft | `int.Parse("drei")`, Datei fehlt | das Programm stürzt ab, **außer** man fängt die Exception ab |

Diese Übung behandelt die dritte Art. Ein Laufzeitfehler heißt in C# **Exception**, genau wie in Python.

## Grundlagen: try / catch / finally / throw

| C# | Python | Bedeutung |
| --- | --- | --- |
| `try { ... }` | `try:` | Code, der schiefgehen kann |
| `catch (FormatException) { ... }` | `except ValueError:` | reagiert auf genau diese Fehlerart |
| `catch (Exception ex) { ... }` | `except Exception as ex:` | fängt alles; `ex.Message` = Fehlertext |
| `finally { ... }` | `finally:` | läuft **immer**, mit oder ohne Fehler |
| `throw new ArgumentException("...")` | `raise ValueError("...")` | selbst einen Fehler auslösen |

Wichtig: Die `catch`-Blöcke werden **von oben nach unten** geprüft, der erste passende gewinnt.
Darum stehen die speziellen Exceptions oben und das allgemeine `Exception` ganz unten.
Sonst würde `Exception` alles abfangen und die speziellen Blöcke kämen nie dran (der Compiler meldet das sogar als Fehler).

---

## Aufgabe 1 – Datum einlesen

### 1. Worum geht es?

Der Benutzer gibt zuerst ein **Datumsformat** ein (z. B. `dd_MM~yyyy`), dann ein **Datum** in diesem
Format (z. B. `10_12~2023`). Das Programm wandelt es mit `DateTime.ParseExact` um und gibt es im
ISO-Format `2023-12-10` aus. Passt etwas nicht, soll eine verständliche Fehlermeldung kommen statt eines Absturzes.

### 2. Konzepte

**`DateTime.ParseExact(text, format, null)`.** Liest ein Datum genau nach einem Muster
(Python: `datetime.strptime(text, format)`, nur mit anderen Platzhaltern):

| C# | Python | Bedeutung |
| --- | --- | --- |
| `dd` | `%d` | Tag zweistellig |
| `MM` | `%m` | Monat zweistellig (klein `mm` wäre Minuten!) |
| `yyyy` | `%Y` | Jahr vierstellig |

Alle anderen Zeichen im Format (`_`, `~`, `.`) müssen genau so im Datum stehen.

**Welche Exceptions?** Laut Microsoft-Dokumentation wirft `ParseExact`:

- `FormatException`: Text oder Format leer, Format ungültig, Datum passt nicht zum Format
  oder existiert nicht (31.02.).
- `ArgumentNullException`: Text oder Format ist `null` (keine Eingabe vorhanden).

### 3. Lösungsansatz und warum

- **`while (!erfolgreich)`-Schleife:** Bei einem Fehler fragt das Programm einfach neu, statt sich zu beenden.
  `erfolgreich = true` steht als letzte Zeile im `try`, wird also nur erreicht, wenn das Umwandeln geklappt hat.
- **Nur die riskante Zeile steht im `try`:** das Einlesen selbst kann nicht schiefgehen, nur `ParseExact`.
- **Für jede dokumentierte Exception ein eigenes `catch`** mit passender Meldung, dann zur Sicherheit
  ein allgemeines `catch (Exception ex)`. So weiß der Benutzer genau, was falsch war.
- **`ToString("yyyy-MM-dd")`** erzeugt das ISO-Format (Python: `strftime("%Y-%m-%d")`).

Getestet: `31.02.2023` mit `dd.MM.yyyy` → Fehlermeldung (den 31. Februar gibt es nicht),
leeres Format → Fehlermeldung, `10_12~2023` mit `dd_MM~yyyy` → `2023-12-10`.

---

## Aufgabe 2 – Ausschussquote

### 1. Worum geht es?

Aus „produzierte Teile“ und „Ausschussteile“ wird die Ausschussquote in Prozent berechnet
(30 von 1200 → 2,50 %). Drei Fehlerfälle sollen abgefangen werden:

- keine ganze Zahl eingegeben (`drei`) → „Ungültige Eingabe!“
- unplausible Werte (0 Teile produziert, mehr Ausschuss als produziert) → „Unplausible Eingabe!“ mit Begründung
- danach immer die Frage, ob man weiterrechnen will.

### 2. Konzepte

**`int.Parse` statt `int.TryParse`.** `TryParse` meldet Fehler mit `false`, `Parse` wirft eine
Exception. Hier wird bewusst `Parse` verwendet, weil die Übung Exceptions üben soll.

**Eigene Exceptions werfen (`throw`).** Die Methode `BerechneAusschussquote` prüft die Werte und
wirft eine `ArgumentException`, wenn sie keinen Sinn ergeben. `throw` bricht die Methode sofort ab
und springt zum passenden `catch` in `Main`, auch über Methodengrenzen hinweg (wie `raise` in Python).

**`finally`.** Läuft immer am Ende des `try`, egal ob es geklappt hat oder welcher `catch` dran war.

### 3. Lösungsansatz und warum

- **Prüfung in der Rechen-Methode, Meldung in `Main`:** Die Methode weiß, *was* falsch ist, und schreibt
  das in die Exception (`ex.Message`). `Main` entscheidet, *wie* es dem Benutzer angezeigt wird.
  So kann man die Methode auch in einem anderen Programm verwenden.
- **Drei `catch`-Blöcke:**
  - `FormatException`: Text statt Zahl.
  - `OverflowException`: Zahl zu groß für `int` (über ca. 2,1 Milliarden), damit auch das nicht abstürzt.
  - `ArgumentException`: unser eigenes `throw`.
- **Die „Weiter?“-Frage steht im `finally`**, weil sie nach *jedem* Durchlauf kommen soll, mit oder
  ohne Fehler. Ohne `finally` müsste man sie in jeden `catch` und ans Ende des `try` kopieren.
- **`(double)ausschuss / produziert * 100`:** ohne `(double)` wäre `30 / 1200` ganzzahlig `0`.

---

## Aufgabe 3 – Zugstab

### 1. Worum geht es?

Für einen runden Zugstab mit Durchmesser `d` und Streckgrenze `Re` wird bei einer Zugkraft `F`
die Spannung berechnet:

```
A = π · d² / 4        σ = F / A        S = Re / σ
```

Ist `σ > Re`, wird der Stab plastisch verformt: Dann soll eine Exception geworfen werden und das
Programm nach neuen Werten fragen. Ungültige Eingaben (Text, Werte ≤ 0) sollen ebenfalls abgefangen
werden. Am Ende soll immer „Auf Wiedersehen!“ erscheinen.

### 2. Konzepte

**Exceptions in einer Klasse.** Die Klasse `Zugstab` schützt sich selbst:

- Der **Konstruktor** wirft `ArgumentOutOfRangeException`, wenn `d` oder `Re` ≤ 0 ist. So kann es nie
  ein ungültiges Zugstab-Objekt geben.
- Die Methode **`Spannung(kraft)`** wirft `InvalidOperationException("Stab wird plastisch verformt")`,
  wenn σ > Re. Diese Exception passt, weil jeder Wert einzeln gültig ist, aber die Kombination nicht funktioniert.

**Verschachteltes `try`.** Ein inneres `try` behandelt den erwarteten Fehler (plastisch → neue Werte),
ein äußeres `try` fängt alles Unerwartete ab und sorgt mit `finally` für die Verabschiedung.

### 3. Lösungsansatz und warum

- **`LeseWert(frage)` fragt nur den falschen Wert neu:** Wer beim Durchmesser `abc` tippt, muss nicht
  alles neu eingeben. In der Methode steht ein `while (true)` mit `try`:
  `double.Parse` wirft bei Text eine `FormatException`, bei Werten ≤ 0 wirft die Methode selbst eine
  `ArgumentOutOfRangeException`. Beide werden direkt dort abgefangen, dann wird nochmal gefragt.
  `return` beendet die Methode, sobald der Wert passt.
- **Innere Schleife in `Main`** wiederholt die ganze Eingabe nur, wenn der Stab plastisch verformt
  würde, denn dann müssen alle drei Werte neu überlegt werden.
- **Äußeres `catch (Exception)` + `finally`:** Sollte trotzdem etwas Unerwartetes passieren,
  stürzt das Programm nicht ab, und „Auf Wiedersehen!“ kommt in jedem Fall.
- **Warum der Konstruktor trotzdem prüft, obwohl `LeseWert` schon ≤ 0 verhindert:** Die Klasse soll
  auch dann sicher sein, wenn sie jemand anders (ohne `LeseWert`) verwendet. Jede Klasse prüft ihre
  eigenen Regeln.

Getestet: `abc` → „Bitte eine Zahl“, `-5` → „größer als 0“, d = 10, Re = 235, F = 100000 →
σ = 1273 N/mm² > Re → „plastisch verformt“, neue Werte F = 10000 → σ = 127,32 N/mm², S = 1,85.
