// =====================================================================================
// UE04 – Aufgabe 3: Instrumentenverleih – Hauptprogramm (klassische Version)
// -------------------------------------------------------------------------------------
// Ziel:
//   Vier Instrumente stehen in einem Array. Der User sieht das Inventar mit Status
//   und kann per Seriennummer ein Instrument ausleihen. Nach jedem erfolgreichen
//   Verleih wird das Inventar erneut angezeigt. Das Programm endet,
//     - wenn der User "e" eingibt,
//     - wenn kein Instrument mehr verfügbar ist, oder
//     - wenn die Eingabe zu Ende ist (EOF, z. B. bei umgeleiteter Eingabe).
//   Ungültige Eingaben (keine Zahl, unbekannte Seriennummer, bereits verliehen)
//   werden mit einer passenden Meldung abgefangen.
//
// Verwendete Konzepte:
//   - Array von Objekten, direkt befüllt (Array-Initialisierer)
//   - while(true)-Schleife mit break, foreach-Schleife (mit break), for-Schleife
//   - Methoden mit Parametern und Rückgabewerten (bool, Instrument?)
//   - enum (über instrument.GetStatus())
// =====================================================================================

namespace UE04.A3.Instrumentenverleih.Klassisch
{
    internal class Program
    {
        // Eingabe, mit der der User das Programm beendet (laut Angabe "e").
        private const string BeendenBefehl = "e";

        // Spaltenbreiten der Inventartabelle (in Zeichen). Als Konstanten, damit
        // Kopfzeile und Datenzeilen garantiert dieselben Breiten verwenden.
        private const int BreiteBezeichnung = 30;
        private const int BreiteSeriennummer = 12;

        // Trennzeichen zwischen den Spalten, wie im Beispiel der Angabe.
        private const string Spaltentrenner = "| ";

        static void Main(string[] args)
        {
            // Umlaute/Sonderzeichen (ü, ö, –) in der Windows-Konsole korrekt darstellen.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Laut Angabe: Array mit vier Instrumenten, direkt befüllt (nicht eingelesen).
            // Jedes "new Instrument(...)" erzeugt ein OBJEKT; der Konstruktor setzt
            // Name, Seriennummer und den Status ReadyToRent.
            // Seriennummern als string – Begründung siehe Instrument.cs.
            Instrument[] instrumente = new Instrument[]
            {
                new Instrument("Yamaha YCL Klarinette", "494773"),
                new Instrument("Olds Recording Trompete", "324385"),
                new Instrument("Stradivari Geige", "654435"),
                new Instrument("Pearl Roadshow Schlagzeug", "847473")
            };

            Console.WriteLine("Willkommen beim Instrumentenverleih!");
            Console.WriteLine();
            ZeigeInventar(instrumente);

            // WARUM while(true) + break?
            //   Die Schleife hat DREI gleichwertige Abbruchgründe (nichts mehr
            //   verfügbar, "e", Eingabeende). Statt einer langen Bedingung im
            //   Schleifenkopf prüfen wir jeden Grund einzeln mit einer klaren Meldung
            //   und verlassen die Schleife mit "break".
            //   break beendet sofort die INNERSTE Schleife (bzw. ein switch), in der
            //   es steht; das Programm macht nach der Schleife weiter.
            while (true)
            {
                // Abbruchgrund 1: Alles verliehen -> Programm endet automatisch.
                if (!GibtVerfuegbareInstrumente(instrumente))
                {
                    Console.WriteLine("Alle Instrumente sind verliehen. Das Programm wird automatisch beendet.");
                    break;
                }

                // Console.ReadLine() liefert null, wenn die Eingabe zu Ende ist
                // (z. B. Strg+Z unter Windows oder eine umgeleitete Datei/Pipe ist
                // vollständig gelesen). Daher der Typ "string?" (darf null sein).
                string? eingabe = LiesZeile();

                // Abbruchgrund 2: Eingabeende. Ohne diese Prüfung würde die Schleife
                // endlos weiterlaufen, weil ReadLine() ab jetzt immer null liefert.
                if (eingabe == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Keine weitere Eingabe vorhanden. Das Programm wird beendet.");
                    break;
                }

                // Trim() entfernt Leerzeichen am Anfang/Ende (" 324385 " -> "324385").
                eingabe = eingabe.Trim();

                // Abbruchgrund 3: User beendet manuell ("e" oder "E").
                if (eingabe.ToLower() == BeendenBefehl)
                {
                    Console.WriteLine("Sie haben das Programm beendet.");
                    break;
                }

                // Nach einem erfolgreichen Verleih wird das Inventar neu angezeigt.
                // Bei einem Fehler wurde bereits eine Meldung ausgegeben und der User
                // kann es im nächsten Schleifendurchlauf erneut versuchen.
                if (VersucheZuVerleihen(instrumente, eingabe))
                {
                    Console.WriteLine();
                    ZeigeInventar(instrumente);
                }
            }
        }

        /// <summary>
        /// Liest eine Zeile ein (Console.ReadLine()). Bei umgeleiteter Eingabe (Pipe/
        /// Datei) erscheint der "getippte" Text nicht von selbst in der Konsole – dann
        /// geben wir ihn aus, damit ein Testprotokoll wie eine echte Sitzung aussieht.
        /// </summary>
        /// <returns>Die Zeile oder null bei Eingabeende.</returns>
        static string? LiesZeile()
        {
            string? zeile = Console.ReadLine();

            if (zeile != null && Console.IsInputRedirected)
            {
                Console.WriteLine(zeile);
            }

            return zeile;
        }

        /// <summary>
        /// Prüft die Eingabe und verleiht das passende Instrument.
        /// Jede Fehlersituation wird mit einer Guard-Clause früh behandelt – so bleibt
        /// der "Erfolgsweg" ganz unten und es gibt keine tiefe if-else-Verschachtelung.
        /// </summary>
        /// <returns>true bei erfolgreichem Verleih, sonst false.</returns>
        static bool VersucheZuVerleihen(Instrument[] instrumente, string eingabe)
        {
            // Fehler 1: Eingabe ist keine Zahl (Buchstaben, leer, ...).
            if (!BestehtNurAusZiffern(eingabe))
            {
                Console.WriteLine("Ungültige Eingabe: Bitte geben Sie eine Seriennummer (nur Ziffern) oder "
                    + BeendenBefehl + " ein.");
                return false;
            }

            // "Instrument?" = das Ergebnis darf null sein (= nichts gefunden).
            Instrument? instrument = SucheInstrument(instrumente, eingabe);

            // Fehler 2: Zahl, aber keine bekannte Seriennummer.
            if (instrument == null)
            {
                Console.WriteLine("Es gibt kein Instrument mit der Seriennummer " + eingabe + ".");
                return false;
            }

            // Fehler 3: Instrument ist bereits verliehen. Die Prüfung macht die Klasse
            // selbst (Verleihen() liefert false) – die Regel steckt also im Objekt.
            if (!instrument.Verleihen())
            {
                Console.WriteLine("Das Instrument " + instrument.GetName() + " (" + instrument.GetSeriennummer()
                    + ") ist bereits verliehen. Bitte wählen Sie ein anderes Instrument.");
                return false;
            }

            Console.WriteLine("Sie haben " + instrument.GetName() + " ausgeliehen. Vielen Dank.");
            return true;
        }

        /// <summary>
        /// Prüft, ob ein Text nicht leer ist und nur aus den Ziffern 0–9 besteht.
        /// (Alle Seriennummern dieses Verleihs sind rein numerisch.)
        /// </summary>
        static bool BestehtNurAusZiffern(string text)
        {
            if (text.Length == 0)
            {
                return false;
            }

            // Ein string ist eine Folge von Zeichen (char) -> mit foreach durchlaufbar.
            // Vergleich mit '0' und '9' funktioniert, weil die Ziffern im Zeichensatz
            // direkt hintereinander liegen.
            foreach (char zeichen in text)
            {
                if (zeichen < '0' || zeichen > '9')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Sucht das Instrument mit der angegebenen Seriennummer.
        /// </summary>
        /// <returns>Das gefundene Instrument oder null, wenn es keines gibt.</returns>
        static Instrument? SucheInstrument(Instrument[] instrumente, string seriennummer)
        {
            Instrument? gefunden = null;

            foreach (Instrument instrument in instrumente)
            {
                if (instrument.GetSeriennummer() == seriennummer)
                {
                    gefunden = instrument;

                    // Seriennummern sind eindeutig – sobald wir den Treffer haben, ist
                    // Weitersuchen sinnlos. break verlässt die foreach-Schleife sofort.
                    break;
                }
            }

            return gefunden;
        }

        /// <summary>Gibt es noch mindestens ein Instrument mit Status ReadyToRent?</summary>
        static bool GibtVerfuegbareInstrumente(Instrument[] instrumente)
        {
            foreach (Instrument instrument in instrumente)
            {
                if (instrument.IstVerfuegbar())
                {
                    // Ein verfügbares reicht – sofort mit true zurück (beendet auch die Schleife).
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gibt den Hinweistext und die Inventartabelle (Bezeichnung | Seriennummer | Status) aus.
        /// </summary>
        static void ZeigeInventar(Instrument[] instrumente)
        {
            Console.WriteLine("Hier sind unsere verfügbaren Instrumente. Bitte geben Sie die Seriennummer "
                + "des Instruments an, das Sie entlehnen möchten.");
            Console.WriteLine("Wenn Sie das Programm beenden möchten, drücken Sie " + BeendenBefehl + ".");
            Console.WriteLine();

            // Kopfzeile: Die Spaltenüberschriften stehen genau über dem Trennzeichen,
            // deshalb wird die Breite um die Länge des Trenners ("| ") erweitert.
            Console.WriteLine("Bezeichnung".PadRight(BreiteBezeichnung)
                + "Seriennummer".PadRight(BreiteSeriennummer + Spaltentrenner.Length)
                + "Status");
            Console.WriteLine();

            // Eine for-Schleife wäre hier ebenso möglich; foreach ist kürzer, weil wir
            // den Index nicht brauchen. PadRight füllt RECHTS mit Leerzeichen auf ->
            // Texte stehen linksbündig in Spalten fester Breite.
            foreach (Instrument instrument in instrumente)
            {
                Console.WriteLine(instrument.GetName().PadRight(BreiteBezeichnung)
                    + Spaltentrenner + instrument.GetSeriennummer().PadRight(BreiteSeriennummer)
                    + Spaltentrenner + instrument.GetStatus());
            }

            Console.WriteLine();
        }
    }
}
