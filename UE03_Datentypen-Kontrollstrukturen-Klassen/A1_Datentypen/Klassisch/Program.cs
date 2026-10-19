// ============================================================================
// Ingenieurinformatik II – Übungsblock #3, Aufgabe 1: Datentypen (KLASSISCHE Version)
// ----------------------------------------------------------------------------
// Ziel:
//   1. So lange eine Eingabe einlesen, bis sie aus GENAU EINEM Zeichen besteht.
//   2. Das Zeichen als "char" speichern, seine numerische Repräsentation separat
//      als "int" speichern und ausgeben.
//   3. Den Zahlenwert in ein "double" übernehmen, mit 1,3 multiplizieren,
//      ein "float" mit 2,56 anlegen, beide addieren und die Summe ausgeben.
//   4. Die Summe explizit nach "int" konvertieren und ausgeben.
//   Die mit * markierten Fragen der Angabe werden unten (Abschnitt "ANTWORTEN")
//   ausführlich beantwortet.
//
// Verwendete Konzepte:
//   - Datentypen string, char, int, double, float
//   - implizite Konversion (automatisch, ohne Datenverlust) und
//     explizite Konversion / Cast mit (int) (möglicher Datenverlust)
//   - Parse-Methoden (char.Parse)
//   - Operatoren: arithmetisch (*, +), vergleichend (!=, ==), zuweisend (=, *=)
//   - do-while-Schleife für eine Eingabe, die MINDESTENS EINMAL erfolgen muss
//
// Aufbau wie in der Vorlesung: block-scoped namespace, Klasse Program,
// statische Main-Methode als Einstiegspunkt.
// ============================================================================

namespace UE03.A1.Datentypen.Klassisch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Die Windows-Konsole verwendet standardmäßig eine alte Codepage (z. B. 850),
            // in der Zeichen wie "ä", "ö", "ü" oder "€" fehlen bzw. falsch dargestellt
            // werden (im Screenshot der Angabe erscheint das € deshalb als "?").
            // Mit UTF-8 als Ausgabe-Kodierung werden alle Unicode-Zeichen korrekt ausgegeben.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ----------------------------------------------------------------
            // Schritt 1: Eingabe einlesen, bis genau EIN Zeichen eingegeben wurde
            // ----------------------------------------------------------------
            // Warum "string?" (mit Fragezeichen)?
            //   Console.ReadLine() liefert normalerweise die eingegebene Zeile als string.
            //   Ist die Eingabe aber zu Ende (z. B. Strg+Z unter Windows oder wenn die
            //   Eingabe aus einer Datei/Pipe umgeleitet wurde und alle Zeilen gelesen
            //   sind), liefert ReadLine() den Wert null. Das "?" sagt dem Compiler:
            //   "Diese Variable darf auch null sein" – er warnt uns dann, falls wir
            //   vergessen, diesen Fall zu behandeln.
            string? eingabe;

            // Warum eine do-while-Schleife?
            //   Bei einer do-while-Schleife wird der Schleifenrumpf IMMER mindestens
            //   einmal ausgeführt, die Bedingung wird erst am ENDE geprüft
            //   ("fußgesteuert"). Genau das brauchen wir: Wir müssen den Benutzer
            //   mindestens einmal fragen, bevor wir überhaupt prüfen können, ob die
            //   Eingabe gültig ist.
            //   Eine while-Schleife ("kopfgesteuert") prüft die Bedingung VOR dem ersten
            //   Durchlauf – dafür müssten wir "eingabe" künstlich mit einem ungültigen
            //   Wert vorbelegen. Eine for-Schleife passt am besten, wenn die Anzahl der
            //   Durchläufe vorher bekannt ist (Zähler) – das ist hier nicht der Fall.
            do
            {
                Console.Write("Bitte geben Sie ein einzelnes Zeichen ein: ");
                eingabe = Console.ReadLine();

                // EOF-Schutz (End Of File): Liefert ReadLine() null, kommt nie wieder
                // eine Eingabe. Ohne diese Prüfung würde die Schleife endlos laufen
                // (bzw. eingabe.Length würde abstürzen). Darum beenden wir sauber.
                if (eingabe == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Keine weitere Eingabe vorhanden – das Programm wird beendet.");
                    return; // verlässt Main und damit das gesamte Programm
                }

                // Vergleichsoperator "!=" (ungleich): Fehlermeldung bei 0 oder mehr als 1 Zeichen.
                if (eingabe.Length != 1)
                {
                    Console.WriteLine("Ungültige Eingabe: \"" + eingabe + "\" besteht aus "
                        + eingabe.Length + " Zeichen. Bitte genau EIN Zeichen eingeben.");
                }
            } while (eingabe.Length != 1);

            // ----------------------------------------------------------------
            // Schritt 2: string -> char -> int (beide Variablen separat speichern)
            // ----------------------------------------------------------------
            // string = Zeichenkette (beliebig viele Zeichen), char = GENAU EIN Zeichen.
            // char.Parse wandelt einen string der Länge 1 in ein char um. Wir haben die
            // Länge oben schon geprüft, deshalb kann hier keine Ausnahme auftreten.
            // (Gleichwertig wäre der Index-Zugriff eingabe[0].)
            char zeichen = char.Parse(eingabe);

            // Explizite Konversion (Cast) mit (int): Wir holen uns die Zahl, mit der das
            // Zeichen intern gespeichert ist (Unicode-Codepunkt, siehe ANTWORT 1).
            // Hinweis: char -> int wäre sogar IMPLIZIT möglich ("int zahl = zeichen;"),
            // weil jeder char-Wert (0 bis 65535) in einen int passt. Der Cast macht die
            // Absicht aber für den Leser deutlich sichtbar.
            int numerischeRepraesentation = (int)zeichen;

            Console.WriteLine("Numerische Repräsentation von '" + zeichen + "': " + numerischeRepraesentation);

            // ----------------------------------------------------------------
            // Schritt 3: double * 1,3 und float 2,56 addieren
            // ----------------------------------------------------------------
            // int -> double ist eine IMPLIZITE Konversion: Jeder int-Wert lässt sich
            // exakt als double darstellen, es geht nichts verloren – darum erledigt
            // der Compiler das automatisch, ohne Cast.
            double kommazahl = numerischeRepraesentation;

            // Zuweisungsoperator "*=" ist die Kurzform von: kommazahl = kommazahl * 1.3;
            // Im Quellcode ist der Punkt IMMER das Dezimaltrennzeichen (1.3), egal welche
            // Sprache der Rechner eingestellt hat. Erst bei der Ausgabe/Eingabe zur
            // Laufzeit spielt die Ländereinstellung (Culture) eine Rolle.
            kommazahl *= 1.3;

            // Das Suffix "f" ist Pflicht: Ein Literal wie 2.56 ist in C# automatisch ein
            // double. double -> float wäre eine VERENGENDE Konversion (Genauigkeit geht
            // verloren), die C# nie automatisch durchführt -> ohne "f" Compilerfehler.
            float kleineKommazahl = 2.56f;

            // Summe double + float: der float wird automatisch (implizit) zu double
            // erweitert, das Ergebnis ist ein double (siehe ANTWORT 2).
            double summe = kommazahl + kleineKommazahl;

            Console.WriteLine("double-Wert (" + numerischeRepraesentation + " * 1,3): " + kommazahl);
            Console.WriteLine("float-Wert: " + kleineKommazahl);
            Console.WriteLine("Summe (double + float): " + summe);

            // ----------------------------------------------------------------
            // Schritt 4: explizite Konversion double -> int
            // ----------------------------------------------------------------
            // double -> int ist VERENGEND (Nachkommastellen gehen verloren, große Werte
            // passen nicht hinein). Deshalb verlangt C# einen expliziten Cast (int):
            // Damit bestätigen wir dem Compiler "ich weiß, dass Information verloren geht".
            int summeGanzzahl = (int)summe;

            Console.WriteLine("Summe als int: " + summeGanzzahl);

            // ================================================================
            // ANTWORTEN auf die Fragen der Angabe (*)
            // ================================================================
            //
            // ANTWORT 1 – Warum haben Zeichen eine numerische Repräsentation?
            //   Ein Computer kann intern nur Zahlen (Bitmuster aus 0 und 1) speichern,
            //   keine "Buchstaben". Damit Texte gespeichert und ausgetauscht werden
            //   können, legt eine Zeichenkodierung fest, welche Zahl für welches Zeichen
            //   steht. Der älteste verbreitete Standard ist ASCII (7 Bit, 128 Zeichen,
            //   z. B. 'A' = 65, 'a' = 97, '0' = 48). Weil ASCII keine Umlaute, kein €
            //   und keine anderen Schriften kennt, gibt es heute Unicode, das jedem
            //   Zeichen weltweit einen eindeutigen Codepunkt zuordnet (die ersten 128
            //   Codepunkte sind identisch mit ASCII). In C# ist ein char ein 16-Bit-Wert
            //   in der Kodierung UTF-16 (Wertebereich 0 bis 65535); 'ä' hat z. B. den
            //   Wert 228, '€' den Wert 8364. Die Zahl zu kennen ist praktisch: Man kann
            //   Zeichen vergleichen/sortieren ('a' < 'b'), Bereiche prüfen
            //   (zeichen >= '0' && zeichen <= '9') oder rechnen ('7' - '0' = 7).
            //   Hinweis: Manche Zeichen (z. B. viele Emojis) liegen außerhalb dieses
            //   16-Bit-Bereichs und brauchen in UTF-16 ZWEI char-Werte
            //   ("Surrogat-Paar") – für unser Programm gilt so eine Eingabe daher als
            //   "mehr als ein Zeichen".
            //
            // ANTWORT 2 – Welchen Datentyp muss die Summe haben, damit keine explizite
            //             Konversion nötig ist, und warum?
            //   Die Summe muss vom Typ double sein. Bei "double + float" wandelt C# den
            //   float automatisch (implizit) in einen double um, weil double den
            //   größeren Wertebereich und die höhere Genauigkeit hat (ca. 15–16 statt
            //   ca. 7 signifikante Stellen). Diese ERWEITERNDE Konversion ist ohne
            //   Informationsverlust möglich, deshalb darf der Compiler sie selbst
            //   durchführen. Das Ergebnis des Ausdrucks ist daher ein double.
            //   Wollte man die Summe in einer float-Variablen speichern, müsste man
            //   explizit casten: float f = (float)(kommazahl + kleineKommazahl);
            //   – denn double -> float könnte Genauigkeit verlieren.
            //   Beobachtung am Rande: Die ausgegebene Summe ist nicht "glatt"
            //   (bei 'a': 128,65999994277956 statt 128,66). Grund: 2,56 lässt sich als
            //   float (und 1,3 als double) im Binärsystem nicht exakt darstellen; beim
            //   Erweitern auf double wird der kleine Rundungsfehler des float sichtbar.
            //
            // ANTWORT 3 – Was beobachtet man bei der Konversion nach int?
            //   Die Nachkommastellen werden einfach ABGESCHNITTEN, NICHT gerundet
            //   (Richtung 0 abgeschnitten, "truncation"). Aus 128,66 wird 128, und auch
            //   aus z. B. 128,99 würde 128 werden; aus -2,7 würde -2. Wer runden will,
            //   muss das selbst tun, z. B. (int)Math.Round(summe).
            //   Der Cast ist nötig, weil ein int keine Nachkommastellen speichern kann
            //   und einen viel kleineren Wertebereich hat als double – es geht also
            //   Information verloren, und das muss der Programmierer ausdrücklich
            //   mit (int) bestätigen.
        }
    }
}
