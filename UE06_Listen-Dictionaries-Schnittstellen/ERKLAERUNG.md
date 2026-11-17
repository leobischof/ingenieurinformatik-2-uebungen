# UE06 – Listen, Dictionaries, Schnittstellen: Erklärung aller Aufgaben

Dieses Dokument erklärt jede Aufgabe in drei Schritten:
**1. Worum geht es?** · **2. Welche Konzepte braucht man?** · **3. Wie ist die Lösung aufgebaut, und warum so?**

Überall gibt es einen Vergleich mit Python, weil die Ideen dort oft gleich sind und nur anders heißen.

| Aufgabe | Ordner | Kernthema |
| --- | --- | --- |
| 1 | [A1_MatrixAnalyser](A1_MatrixAnalyser/) | 2D-Arrays, Schleifen vorwärts und rückwärts |
| 2 | [A2_Stueckliste](A2_Stueckliste/) | `List<T>`, CSV einlesen, `IComparable<T>` |
| 3 | [A3_Lagerverwaltung](A3_Lagerverwaltung/) | `Dictionary<K, V>`, Menü, Referenzen |
| 4 | [A4_Fertigungsauftraege](A4_Fertigungsauftraege/) | `IComparable<T>` und `IComparer<T>`, `DateTime`/`TimeSpan` |

---

## Aufgabe 1 – Matrix-Analyser

### 1. Worum geht es?

Eine Klasse `MatrixAnalyser` bekommt eine Zahlenmatrix (2D-Array) und soll vier Dinge berechnen:

- `GetMaxValue()`: den größten Wert, gesucht **von links oben**, Zeile für Zeile.
- `GetMinValue()`: den kleinsten Wert, gesucht **von rechts unten rückwärts**.
- `GetAverageDiagonal1()`: Mittelwert der Diagonale **von links unten nach rechts oben**.
- `GetAverageDiagonal2()`: Mittelwert der Diagonale **von rechts oben nach links unten**.

Ist die Matrix nicht quadratisch, gibt es keine richtige Diagonale, dann ist das Ergebnis 0.

### 2. Konzepte

**2D-Array `int[,]`.** Ein Rechteck aus Zahlen mit fester Größe. Zugriff mit `matrix[zeile, spalte]`.
In Python entspricht das am ehesten einer Liste von Listen (`matrix[zeile][spalte]`) bzw. einem
NumPy-Array (`a[zeile, spalte]`, gleiche Schreibweise!).

```csharp
int[,] m = { { 1, 2, 3 },
             { 4, 5, 6 } };      // 2 Zeilen, 3 Spalten
m.GetLength(0);  // 2 → Anzahl Zeilen   (Python: len(m))
m.GetLength(1);  // 3 → Anzahl Spalten  (Python: len(m[0]))
```

**Verschachtelte `for`-Schleifen.** Außen die Zeilen, innen die Spalten. Rückwärts läuft man,
indem man beim letzten Index beginnt und herunterzählt (`zeile--`), wie in Python
`for zeile in range(n - 1, -1, -1)`.

**Ganzzahlige Division.** `7 / 2` ist in C# `3`, weil beide Seiten `int` sind (wie `7 // 2` in Python).
Für den Mittelwert braucht man deshalb `(double)summe / anzahl`.

### 3. Lösungsansatz und warum

- **Zeilen und Spalten im Konstruktor merken** (`anzahlZeilen`, `anzahlSpalten`), damit nicht jede
  Methode wieder `GetLength` aufrufen muss. Sie ändern sich nie, darum keine Getter/Setter.
- **Max/Min:** Der Startwert ist das erste Element *in Suchrichtung* (`matrix[0,0]` bzw. das
  Element rechts unten). Nicht `0` als Startwert, denn bei einer Matrix mit nur negativen Zahlen
  wäre `0` falsch.
- **Diagonalen:** Bei einer n×n-Matrix gibt es genau n Diagonal-Elemente, darum reicht **eine**
  Schleife mit einem Zähler `i`:
  - Diagonale 1 (links unten → rechts oben): `matrix[n - 1 - i, i]` → Zeile wird kleiner, Spalte größer.
  - Diagonale 2 (rechts oben → links unten): `matrix[i, n - 1 - i]` → Zeile wird größer, Spalte kleiner.
- **Guard Clause** `if (anzahlZeilen != anzahlSpalten) return 0;` gleich am Anfang statt einer
  großen Verschachtelung.
- `Program.cs` testet zwei Matrizen: eine quadratische 6×6 und eine 6×7, damit man den 0-Fall sieht.

> **Hinweis:** Laut Abbildung in der Angabe laufen *beide* Diagonalen über dieselbe Linie
> (die Nebendiagonale), nur in entgegengesetzter Richtung. Deshalb liefern beide Methoden **denselben
> Mittelwert** (im Test 16,00). Das ist kein Fehler: Die Aufgabe übt die zwei Laufrichtungen.

---

## Aufgabe 2 – Stückliste

### 1. Worum geht es?

Eine Stückliste (Bauteile einer Baugruppe) liegt als CSV-Datei vor. Das Programm soll sie einlesen,
jede Zeile in ein `Component`-Objekt umwandeln, in einer `List<Component>` speichern, ausgeben,
dann **nach Material und bei gleichem Material nach Masse** sortieren und nochmals ausgeben.

### 2. Konzepte

**`List<T>`.** Eine Liste, die wachsen und schrumpfen kann, genau wie eine Python-`list`.
Das `<Component>` sagt, dass nur `Component`-Objekte hinein dürfen.

| C# | Python |
| --- | --- |
| `List<Component> l = new List<Component>();` | `l = []` |
| `l.Add(x)` | `l.append(x)` |
| `l.Count` | `len(l)` |
| `l[0]` | `l[0]` |
| `l.Sort()` | `l.sort()` |

**Datei einlesen und zerlegen.** `File.ReadAllLines(pfad)` gibt ein `string[]` mit allen Zeilen
(Python: `open(pfad).read().splitlines()`). `zeile.Split(';')` zerlegt eine Zeile (Python: `zeile.split(";")`).

**Zahlen mit Komma.** In der Datei steht `3,265`. `double.Parse` verwendet sonst die Einstellung
des Computers, darum geben wir ausdrücklich die deutsche Schreibweise mit:
`double.Parse(text, new CultureInfo("de-DE"))`. So funktioniert es auf jedem Computer gleich.

**Schnittstelle `IComparable<T>`.** Eine Schnittstelle (Interface) ist ein Versprechen: „Diese Klasse
hat eine Methode `CompareTo`.“ `List.Sort()` verlässt sich darauf und ruft `CompareTo` immer wieder
auf, um je zwei Bauteile zu vergleichen. Rückgabe:

- `< 0`: dieses Objekt kommt **vor** dem anderen
- `0`: gleich
- `> 0`: dieses Objekt kommt **nach** dem anderen

In Python wäre das `__lt__` in der Klasse oder `liste.sort(key=lambda c: (c.material, c.masse))`.

### 3. Lösungsansatz und warum

- **Eigene Methode `LeseStueckliste`** gibt die fertige Liste zurück. `Main` bleibt dadurch kurz und
  liest sich wie ein Ablauf: einlesen, ausgeben, sortieren, ausgeben.
- **Schleife beginnt bei `i = 1`**, weil Zeile 0 die Kopfzeile ist.
- **Trennzeichen `;` statt `,`:** Die Massen haben ein Dezimalkomma (`3,265`). Würde man mit `,`
  trennen, würde jede Masse in zwei Teile zerfallen. Darum ist die CSV mit `;` getrennt
  (so speichert auch das deutsche Excel CSV-Dateien).
- **`CompareTo` in zwei Stufen:** zuerst `string.Compare` auf das Material. Nur wenn das 0 ergibt
  (gleiches Material), entscheidet `masse.CompareTo(...)`. Das ist genau „sortiere nach Material,
  dann nach Masse“.
- **CSV wird ins Ausgabeverzeichnis kopiert** (`CopyToOutputDirectory` in der `.csproj`), damit
  das Programm sie mit dem einfachen Pfad `"Stueckliste.csv"` findet, egal wie man es startet.
- **`ToString()` überschreiben**, damit `Console.WriteLine(bauteil)` eine schöne Tabellenzeile druckt
  (Python: `__str__`). `PadRight(40)` füllt mit Leerzeichen auf, damit die Spalten untereinander stehen.

> **Hinweis:** Mehrere Bauteile (Normteile wie Lager, Schrauben, Sicherungsringe) haben in der CSV kein
> Material. Wie im Beispiel der Angabe bleibt das Feld leer. Ein leerer Text ist alphabetisch „kleiner“
> als jeder andere, darum stehen diese Bauteile nach dem Sortieren ganz oben (untereinander nach Masse).

---

## Aufgabe 3 – Lagerverwaltung

### 1. Worum geht es?

Ein kleines Lagerprogramm mit Menü. Die Artikel liegen in einem `Dictionary<string, Artikel>`,
Schlüssel ist die Artikelnummer. Menüpunkte:

1. Lagerbestand anzeigen
2. Artikel anlegen (doppelte Nummer → Fehlermeldung)
3. Buchung: Wareneingang oder Warenausgang (zu wenig Bestand → Fehlermeldung)
4. Artikel löschen
5. Gesamtwert des Lagers (Summe Bestand × Preis)
6. Experiment: `ContainsKey` / `ContainsValue` mit Original und Kopie
0. Beenden

Dazu zwei Theoriefragen: a) Warum findet `ContainsValue` die Kopie nicht? b) Wann Array, List, Dictionary?

### 2. Konzepte

**`Dictionary<TKey, TValue>`** ist dasselbe wie ein Python-`dict`.

| C# | Python |
| --- | --- |
| `lager.Add("A-100", artikel)` | `lager["A-100"] = artikel` |
| `lager.ContainsKey("A-100")` | `"A-100" in lager` |
| `lager.TryGetValue("A-100", out Artikel a)` | `a = lager.get("A-100")` |
| `lager.Remove("A-100")` | `lager.pop("A-100", None)` |
| `foreach (KeyValuePair<string, Artikel> kvp in lager)` | `for key, value in lager.items():` |
| `lager.Values` | `lager.values()` |

**`TryGetValue` mit `out`.** Prüft und holt in einem Schritt. Rückgabe `true`/`false`; das gefundene
Objekt landet in der `out`-Variable. Python hat kein `out`, dort gibt `get` einfach `None` zurück.

**Referenz vs. Inhalt.** Eine Variable mit einem Objekt enthält nur einen *Verweis* auf das Objekt im
Speicher. Zwei Objekte mit gleichen Daten sind trotzdem zwei verschiedene Objekte.

**Klassisches `switch`.** Wie `match`/`case` in Python oder eine `if/elif`-Kette; jeder Fall endet mit `break`.

### 3. Lösungsansatz und warum

- **Eine Methode pro Menüpunkt** (`ArtikelAnlegen`, `BuchungDurchfuehren`, …). Das `switch` in `Main`
  ruft nur auf, dadurch bleibt `Main` übersichtlich.
- **Hilfsmethoden fürs Einlesen** (`LeseGanzzahl`, `LeseKommazahl`, `LeseArtikelnummer`) fragen so lange,
  bis die Eingabe stimmt. Das wird mehrmals gebraucht, darum nur einmal geschrieben.
- **Artikelnummer `Trim().ToUpper()`:** So findet `b-100` auch `B-100`, und versehentliche Leerzeichen stören nicht.
- **Vor `Add` mit `ContainsKey` prüfen**, weil `Add` bei einem doppelten Schlüssel eine Exception wirft.
- **`Entnehmen` gibt `bool` zurück:** Die Klasse `Artikel` entscheidet selbst, ob genug da ist, und ändert
  den Bestand nur dann. Das Programm reagiert nur auf `true`/`false`. So kann der Bestand nie negativ werden.
- **Gesamtwert über `lager.Values`**, weil man nur die Artikel braucht, nicht die Schlüssel.

**Antwort a):** Die Kopie ist ein *neues* Objekt mit denselben Daten. `ContainsValue` vergleicht
Objekte ohne eigenes `Equals` über ihre **Referenz**, also „ist es genau dasselbe Objekt im Speicher?“.
Das ist bei der Kopie nicht so, darum `false`. In Python ist das der Unterschied zwischen `is` und `==`.

**Antwort b):**

- **Array:** feste Größe, Zugriff über Position. Gut, wenn die Anzahl feststeht (Matrix aus Aufgabe 1).
- **List:** variable Größe, Zugriff über Position, sortierbar. Gut für Reihenfolgen (Aufgaben 2 und 4).
- **Dictionary:** Zugriff über einen eindeutigen Schlüssel, sehr schnelles Nachschlagen. Passt hier,
  weil Artikel immer über die Artikelnummer gesucht werden und doppelte Nummern verboten sind.

---

## Aufgabe 4 – Fertigungsaufträge

### 1. Worum geht es?

Eine Maschine soll mehrere Fertigungsaufträge **nacheinander** abarbeiten. Jeder Auftrag hat Nummer,
Artikel, Bearbeitungszeit und Liefertermin. Das Programm:

1. zeigt alle offenen Aufträge,
2. fragt, welcher Auftrag storniert werden soll, und löscht ihn,
3. plant die Reihenfolge nach der **KOZ-Regel** (kürzeste Operationszeit zuerst),
4. plant die Reihenfolge nach der **FLT-Regel** (frühester Liefertermin zuerst),
5. zeigt jeweils Ende, Verspätung, mittlere Durchlaufzeit und Anzahl verspäteter Aufträge.

### 2. Konzepte

**`DateTime` und `TimeSpan`.** `DateTime` ist ein Zeitpunkt, `TimeSpan` eine Dauer, genau wie
`datetime` und `timedelta` in Python:

```csharp
DateTime start = DateTime.Today.AddHours(6);        // heute 06:00
DateTime ende = start + TimeSpan.FromHours(3);      // 09:00
TimeSpan diff = ende - start;                       // 3 Stunden
diff.TotalHours;                                    // 3.0
```

**Zwei Arten zu sortieren:**

- **`IComparable<T>`** (in der Klasse selbst, Methode `CompareTo`): die *Standard*-Sortierung.
  `liste.Sort()` ohne Parameter verwendet sie. Hier: KOZ.
- **`IComparer<T>`** (eigene Klasse, Methode `Compare(a, b)`): eine *zusätzliche* Sortierung.
  Man übergibt ein Objekt davon: `liste.Sort(new LieferterminComparer())`. Hier: FLT.

In Python entspricht das einem `__lt__` in der Klasse (Standard) und `sort(key=...)` für andere Sortierungen.

**`RemoveAt(i)`** löscht das Element an Position `i` (Python: `del liste[i]`).

### 3. Lösungsansatz und warum

- **Start = heute 06:00** (`DateTime.Today.AddHours(6)`), alle Liefertermine sind „Start + x Stunden“.
  Dadurch passen die Daten zu jedem Tag, an dem man das Programm vorführt.
- **Stornieren in eigener Methode mit `bool`-Rückgabe:** Die Schleife in `Main` fragt so lange,
  bis wirklich ein Auftrag gelöscht wurde. Eine `for`-Schleife mit Index wird verwendet, weil man
  während eines `foreach` nichts aus der Liste löschen darf.
- **Beide Regeln mit Gleichstands-Regel:** Bei KOZ entscheidet bei gleicher Dauer der Termin, bei FLT bei
  gleichem Termin die Dauer. So ist die Reihenfolge immer eindeutig.
- **Eine Methode `GibPlanAus` für beide Pläne:** Die Berechnung ist bei beiden Regeln gleich, nur die
  Reihenfolge der Liste ist anders. Darum nur einmal geschrieben (DRY).
- **Berechnung im Plan:**
  - Ende = voriges Ende + Bearbeitungszeit (die Maschine macht einen Auftrag nach dem anderen).
  - Verspätung = Ende − Termin, aber nie negativ (zu früh fertig zählt als 0 h).
  - Durchlaufzeit = Ende − Start, der Mittelwert über alle Aufträge.

**Ergebnis (nach Stornieren von 1003):** KOZ hat 3 verspätete Aufträge, aber die kleinere mittlere
Durchlaufzeit (13,14 h). FLT hat nur 1 verspäteten Auftrag, aber die größere Durchlaufzeit (16,14 h).
Genau das ist die Lehre: **KOZ minimiert die mittlere Durchlaufzeit, FLT minimiert Verspätungen.**

> **Hinweis:** Im Beispiel der Angabe steht „mittlere Durchlaufzeit 4,29 h“. Das ist nur der Mittelwert
> der *Bearbeitungszeiten* (30 h / 7 Aufträge) und wäre bei beiden Regeln gleich. Die echte
> Durchlaufzeit misst aber, wie lange ein Auftrag ab Produktionsstart bis zur Fertigstellung braucht
> (inkl. Warten). Nur damit sieht man den Unterschied zwischen KOZ und FLT. Deshalb rechnet die Lösung so.
