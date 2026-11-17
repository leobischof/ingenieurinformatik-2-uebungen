# C#-Spickzettel – Programme starten & Tastenkürzel

Alles, was man im Alltag mit diesen Übungen braucht: wie man ein Programm startet, und die
wichtigsten Tastenkürzel – vor allem in **Zed**, dazu kurz VS Code und Visual Studio.

> Tastenkürzel gelten für eine **deutsche/österreichische Tastatur**. Zed und VS Code übersetzen
> die US-Kürzel auf die Taste, die unter Windows an derselben Stelle der Tastencodes liegt – deshalb
> wird z. B. US-`Strg+/` hier zu `Strg+#` und US-``Strg+` `` zu `Strg+Ö`. Der US-Name steht in Klammern.

---

## 1 · Einmalig einrichten

| Was | Stand / Wie |
| --- | --- |
| .NET SDK | `dotnet --list-sdks` muss eine Version ≥ 8 zeigen (installiert: 10.0) |
| Zed | Installiert. Erweiterungen **C#** (Roslyn: IntelliSense, Fehler) und **C# Snippets** werden über `auto_install_extensions` in den Zed-Einstellungen automatisch installiert |
| Zed-Tasks für C# | Liegen in `%APPDATA%\Zed\tasks.json` („C#: Projekt starten“, „C#: Projektmappe bauen“, „C#: Tests ausfuehren“) und rufen `%APPDATA%\Zed\dotnet.ps1` auf. Tastenkürzel dafür in `%APPDATA%\Zed\keymap.json` |
| VS Code (optional) | Erweiterung **C# Dev Kit** fehlt noch: `code --install-extension ms-dotnettools.csdevkit` |

---

## 2 · Programme starten

### 2.1 In Zed (Hauptweg)

1. **Den Repo-Ordner öffnen, nicht einen einzelnen Projektordner** – Roslyn lädt die `.sln` im
   geöffneten Ordner, sonst gibt es keine IntelliSense/Fehleranzeige:
   ```powershell
   zed "C:\Users\leobi\1_DATA\0_TU_GRAZ\Ing info 2\ingenieurinformatik-2-uebungen"
   # oder im Repo-Root einfach:
   zed .
   ```
2. Die `Program.cs` (oder irgendeine andere `.cs`-Datei) der gewünschten Aufgabe öffnen
   (`Strg+P` → Dateiname tippen).
3. **`Strg+F5`** → startet *das Projekt der gerade offenen Datei* (`dotnet run`). Das Skript sucht
   vom Ordner der Datei aufwärts die nächste `.csproj` – es ist also egal, welche `.cs`-Datei des
   Projekts offen ist.
4. Das Programm läuft unten im **Task-Terminal**. Eingaben für `Console.ReadLine()` tippt man direkt
   dort hinein (ins Terminal klicken, tippen, `Enter`).

| Kürzel in Zed | Aktion |
| --- | --- |
| `Strg+F5` *(nur in einer `.cs`-Datei)* | **Projekt der offenen Datei starten** |
| `Strg+Umschalt+B` *(nur in einer `.cs`-Datei)* | **Ganze Projektmappe bauen** (zeigt alle Fehler) |
| `Alt+T` (oder `Strg+Umschalt+R`) | Letzten Task wiederholen – **mit demselben Projekt wie beim letzten Mal**, auch wenn gerade eine Datei aus einer anderen Aufgabe offen ist. Für eine andere Aufgabe also wieder `Strg+F5` in deren `.cs`-Datei |
| `Umschalt+Alt+T` | Task-Liste öffnen → „C#: …“ tippen und auswählen (z. B. „C#: Tests ausfuehren“) |
| `Strg+C` *(im Terminal)* | Laufendes Programm abbrechen |

> **Wichtig:** `Strg+F5` und `Strg+Umschalt+B` sind nur belegt, solange der Cursor in einer
> `.cs`-Datei steht. Steht man in der README oder im Terminal, passiert nichts bzw. etwas anderes
> (`Strg+Umschalt+B` öffnet dann die Gliederung). Ist keine `.cs`-Datei offen, meldet der Task
> „Kein .csproj … gefunden“.
>
> **Debugger:** Für C# ist in Zed kein Debugger eingerichtet (die C#-Erweiterung bringt keinen mit) –
> Haltepunkte und Schritt-für-Schritt gehen nur in VS Code oder Visual Studio (Abschnitt 5). In Zed
> hilft man sich mit `Console.WriteLine(...)` an der fraglichen Stelle.

### 2.2 Im Terminal (funktioniert immer)

Terminal in Zed: `Strg+Ö`. Alle Befehle vom **Repo-Root** aus; Pfade mit Leerzeichen in
Anführungszeichen.

```bash
# eine Aufgabe bauen + starten (Pfad = Ordner mit der .csproj)
dotnet run --project "UE04_Verzweigungen-Arrays-Klassen/A1_Multiplikationstabelle"

# oder: in den Ordner wechseln und einfach dotnet run
cd "UE04_Verzweigungen-Arrays-Klassen/A1_Multiplikationstabelle"
dotnet run

# ohne neu zu bauen starten (schneller, wenn schon gebaut)
dotnet run --no-build

# ALLE Projekte auf einmal bauen (zeigt alle Fehler/Warnungen)
dotnet build IngInfo2-Uebungen.sln

# Build-Ordner (bin/ obj/) aufräumen, z. B. bei komischen Build-Fehlern
dotnet clean IngInfo2-Uebungen.sln

# automatisch neu starten, sobald man eine Datei speichert (Beenden: Strg+C)
dotnet watch run

# Eingabe automatisch einspeisen, statt sie jedes Mal zu tippen
echo x | dotnet run
dotnet run < eingabe.txt

# gebautes Programm direkt ausführen (ohne dotnet run)
./bin/Debug/net8.0/UE04.A1.Multiplikationstabelle.exe

# welche Projekte gibt es in der Solution?
dotnet sln list
```

**Im laufenden Programm (Konsole):**

| Taste | Wirkung |
| --- | --- |
| `Strg+C` | Programm sofort abbrechen |
| `Strg+Z` dann `Enter` | „Ende der Eingabe“ senden → `Console.ReadLine()` liefert `null` |
| `↑` / `↓` | vorherige Befehle durchblättern |
| `Tab` | Pfade automatisch vervollständigen |
| `cls` | Terminal leeren |

### 2.3 Neues Projekt anlegen (für eine neue Aufgabe)

```bash
# neues Konsolenprojekt erzeugen
dotnet new console -n UE05.A1.Beispiel -o "UE05_.../A1_..."

# zur Solution hinzufügen, damit Zed/Roslyn, Visual Studio und der Solution-Build es kennen
dotnet sln IngInfo2-Uebungen.sln add "UE05_.../A1_..."
```

Die gemeinsamen Einstellungen (`net8.0`, `Nullable`, …) kommen automatisch aus
`Directory.Build.props` – in der neuen `.csproj` daher `TargetFramework`, `OutputType`,
`ImplicitUsings` und `Nullable` löschen, damit nichts doppelt definiert ist.

---

## 3 · Tastenkürzel Zed (gilt fast identisch in VS Code)

Zed läuft bei dir mit der **VS-Code-Tastenbelegung** (`"base_keymap": "VSCode"`). Wo VS Code
abweicht, steht es in der Spalte ganz rechts.

### Code schreiben

| Kürzel | Aktion | VS Code |
| --- | --- | --- |
| `Strg+Leertaste` | IntelliSense-Vorschläge erzwingen | |
| `Strg+I` | Parameter-Infos der Methode anzeigen | `Strg+Umschalt+Leertaste` |
| `Strg+K Strg+I` | Info-Popup (Typ, Doku) zur Stelle unter dem Cursor | |
| `Strg+.` | **Schnellkorrektur / Code-Aktionen** (fehlendes `using`, Fehler beheben …) | |
| `F2` | Variable/Methode/Klasse überall **umbenennen** | |
| `Umschalt+Alt+F` | Dokument formatieren (Formatieren beim Speichern ist **aus**) | |
| `Strg+#` (US: `Strg+/`) oder `Strg+K Strg+C` | Zeile(n) aus-/einkommentieren | nur `Strg+#` |
| `Umschalt+Alt+A` | Blockkommentar `/* … */` | |

### Navigieren

| Kürzel | Aktion | VS Code |
| --- | --- | --- |
| `F12` | Zur Definition springen | |
| `Alt+F12` | Definition daneben öffnen | als Vorschau |
| `Umschalt+Alt+F12` | **Alle Verwendungen** anzeigen | `Umschalt+F12` |
| `Alt+←` / `Alt+→` | Zurück / vor (nach einem Sprung) | |
| `F8` / `Umschalt+F8` | Zum nächsten / vorigen Fehler | |
| `Strg+Umschalt+M` | Alle Fehler & Warnungen | |
| `Strg+P` | Datei nach Namen öffnen | |
| `Strg+Umschalt+O` | Zu Methode/Klasse in **dieser** Datei | |
| `Strg+T` | Symbol im **ganzen** Projekt suchen | |
| `Strg+G` | Zu Zeilennummer | |
| `Strg+Umschalt+P` | **Befehlspalette** (jeden Befehl per Name finden) | |
| `Strg+Tab` | Zwischen offenen Dateien wechseln | |

### Bearbeiten

| Kürzel | Aktion |
| --- | --- |
| `Alt+↑` / `Alt+↓` | Zeile nach oben / unten verschieben |
| `Umschalt+Alt+↑` / `↓` | Zeile nach oben / unten kopieren |
| `Strg+Umschalt+K` | Zeile löschen |
| `Strg+Enter` / `Strg+Umschalt+Enter` | Neue Zeile darunter / darüber |
| `Strg+L` | Ganze Zeile markieren |
| `Strg+D` | Nächstes gleiches Wort zusätzlich markieren (Mehrfachcursor) |
| `Strg+Umschalt+L` | Alle gleichen Wörter markieren |
| `Alt+Klick` | Weiteren Cursor setzen |
| `Strg+Alt+↑` / `↓` | Cursor darüber / darunter hinzufügen |
| `Strg+F` / `Strg+H` | Suchen / Ersetzen in der Datei |
| `Strg+Umschalt+F` | Im ganzen Projekt suchen |
| `Strg+K Strg+0` / `Strg+K Strg+J` | Alles einklappen / alles ausklappen |
| `Strg+K Strg+L` | Block unter dem Cursor ein-/ausklappen |
| `Strg+Z` / `Strg+Y` | Rückgängig / Wiederholen |

### Fenster

| Kürzel | Aktion |
| --- | --- |
| `Strg+Ö` (US: ``Strg+` ``) | Terminal ein-/ausblenden |
| `Strg+Umschalt+Ö` | Neues Terminal |
| `Strg+B` | Linke Seitenleiste ein-/ausblenden |
| `Strg+Umschalt+E` | Dateibaum (Explorer) |
| `Strg+Umschalt+G` | Git-Panel |
| `Strg+^` (US: `Strg+\`) | Editor nach rechts teilen |
| `Strg+W` | Datei/Tab schließen |
| `Strg+K S` | Alle Dateien speichern |
| `Strg+K Strg+S` | Liste **aller** Tastenkürzel (dort auch ändern) |
| `Strg++` / `Strg+-` / `Strg+0` | Schrift größer / kleiner / zurücksetzen |

---

## 4 · Snippets (Kürzel + Tab)

Wort tippen, im Vorschlagsmenü auswählen bzw. **`Tab`** drücken; mit `Tab` springt man zum nächsten
Platzhalter. In Zed kommen die Snippets aus der Erweiterung **C# Snippets**.

| Tippen | Ergibt | Zed | VS / VS Code |
| --- | --- | :-: | :-: |
| `cw` | `Console.WriteLine();` | ✓ | ✓ |
| `if` / `ifelse` / `elseif` | `if` / `if-else` / `if-else if` | ✓ | nur `if`, `else` |
| `for` | `for (int i = 0; i < length; i++) { }` | ✓ | ✓ |
| `foreach` | `foreach (var item in collection) { }` | ✓ | ✓ |
| `while` | `while`-Schleife | ✓ | ✓ |
| `dowhile` | `do { } while (…);` | ✓ | heißt dort `do` |
| `switch` | `switch`-Anweisung | ✓ | ✓ |
| `try` / `tryf` | `try-catch` / `try-finally` | ✓ | ✓ |
| `class` / `static` / `abstract` | Klasse / statische / abstrakte Klasse | ✓ | nur `class` |
| `ctor` | Konstruktor | ✓ | ✓ |
| `method` | Methode `public void MethodName() { }` | ✓ | – |
| `prop` | `public int MyProperty { get; set; }` | ✓ | ✓ |
| `propfull` | Property mit privatem Feld dahinter | ✓ | ✓ |
| `propread` | Nur-lesen-Property `{ get; }` | ✓ | – |
| `enum` / `struct` / `record` / `interface` | jeweiliges Gerüst | ✓ | ✓ (ohne `record`) |
| `throw` | `throw new Exception("message");` | ✓ | – |
| `ternary` | `bedingung ? a : b` | ✓ | – |
| `svm` | `static void Main(string[] args) { }` | **–** | ✓ |
| `forr` | `for`-Schleife rückwärts | **–** | ✓ |

In Visual Studio muss man nach dem Kürzel **zweimal** `Tab` drücken.

---

## 5 · Mit Debugger: VS Code und Visual Studio

Nur nötig, wenn man Haltepunkte und Schritt-für-Schritt-Ausführung braucht (in Zed nicht eingerichtet).

**VS Code** (braucht C# Dev Kit, siehe 1): Repo mit `code .` öffnen, `Program.cs` öffnen, `F5`
(beim ersten Mal *C#* und das Projekt wählen). Achtung: Die Debugkonsole nimmt keine
`Console.ReadLine()`-Eingaben an – dafür in `.vscode/launch.json` `"console": "integratedTerminal"`
setzen. Alle anderen Kürzel wie in Abschnitt 3.

**Visual Studio 2022** (nicht installiert; Workload „.NET-Desktopentwicklung“): `IngInfo2-Uebungen.sln`
öffnen → Rechtsklick aufs Projekt → **„Als Startprojekt festlegen“**.

| Kürzel | VS Code | Visual Studio |
| --- | --- | --- |
| Debuggen starten / weiter | `F5` | `F5` |
| Ohne Debugger starten | `Strg+F5` | `Strg+F5` |
| Debuggen beenden | `Umschalt+F5` | `Umschalt+F5` |
| Haltepunkt setzen/entfernen | `F9` | `F9` |
| Prozedurschritt (Methoden nicht betreten) | `F10` | `F10` |
| Einzelschritt (in Methode hinein) | `F11` | `F11` |
| Aus der Methode heraus | `Umschalt+F11` | `Umschalt+F11` |
| Bauen | `Strg+Umschalt+B` | `Strg+Umschalt+B` |
| Umbenennen | `F2` | `Strg+R Strg+R` |
| Formatieren | `Umschalt+Alt+F` | `Strg+K Strg+D` |
| Auskommentieren | `Strg+#` | `Strg+K Strg+C` / `Strg+K Strg+U` |
| Alle Verwendungen | `Umschalt+F12` | `Umschalt+F12` |
| Zeile duplizieren | `Umschalt+Alt+↓` | `Strg+D` |
| Alles durchsuchen | `Strg+T` | `Strg+T` / `Strg+,` |

Beim Debuggen: Maus über eine Variable halten zeigt ihren Wert; im Debug-Panel stehen alle lokalen
Variablen, unter **Überwachen** kann man eigene Ausdrücke eintragen.

---

## 6 · Häufige Stolpersteine

| Problem | Lösung |
| --- | --- |
| `Strg+F5` in Zed macht nichts | Cursor steht nicht in einer `.cs`-Datei → erst in die `.cs`-Datei klicken |
| Zed: keine Vorschläge / keine roten Wellenlinien | Zed wurde mit einem Unterordner geöffnet → Repo-Root öffnen (`zed .`). Sonst `Strg+Umschalt+P` → *editor: restart language server* |
| `Es wurde kein ausführbares Projekt gefunden` | Im Terminal im falschen Ordner → `cd` in den Ordner mit der `.csproj` oder `--project "…"` angeben |
| Programm wartet „ewig“ | Es wartet auf `Console.ReadLine()` – ins Terminal klicken, etwas eintippen + `Enter` |
| Komma vs. Punkt bei Zahlen | Auf deutschem Windows ergibt `double.Parse("1,5")` → `1,5`, aber `double.Parse("1.5")` → **`15`** (der Punkt gilt als Tausendertrennzeichen, kein Fehler!). Bei der Eingabe also Komma verwenden |
| Seltsame Build-Fehler nach Umbenennen/Verschieben | `dotnet clean`, dann neu bauen |
