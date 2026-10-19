// ============================================================================
// Ingenieurinformatik II – Übungsblock #3, Aufgabe 2: Multi-Massenkonverter
// (KLASSISCHE Version)
// ----------------------------------------------------------------------------
// Ziel:
//   Eine Masse in einer gewählten Einheit (Kilogramm, Pfund oder Stone) einlesen
//   und in die beiden ANDEREN Einheiten umrechnen. Ungültige Eingaben (keine Zahl,
//   negative Masse, Menüwahl außerhalb 1–3) werden so lange erneut abgefragt, bis
//   sie gültig sind. Nach jeder Umrechnung: "Weitere Umrechnung? (Ja/Nein)".
//
// Verwendete Konzepte:
//   - Konstanten (const) für Einheiten-Abkürzungen und Umrechnungsfaktoren
//   - Datentypen string, int, double; Konversion string -> Zahl mit TryParse
//   - Operatoren: arithmetisch (*, /), vergleichend (<, >, ==, !=),
//     logisch (&&, ||, !), zuweisend (=)
//   - geschachtelte Verzweigung (if innerhalb von if/else) und switch
//   - do-while-Schleifen (Abfrage mindestens einmal) und eine while-Schleife
// ============================================================================

namespace UE03.A2.Massenkonverter.Klassisch
{
    internal class Program
    {
        // --------------------------------------------------------------------
        // KONSTANTEN
        // --------------------------------------------------------------------
        // Warum const?
        //   Ein const-Wert wird beim Kompilieren festgelegt und kann zur Laufzeit
        //   NIE verändert werden – ein versehentliches "UMRECHNUNG = 3;" ist ein
        //   Compilerfehler. Außerdem steht jeder Wert genau EINMAL im Programm
        //   ("Single Source of Truth"): Muss ein Faktor korrigiert werden, ändert man
        //   ihn an einer einzigen Stelle. Und ein sprechender Name wie
        //   PFUND_PRO_KILOGRAMM erklärt mehr als eine "magische Zahl" 2.20462.
        //   Konvention in vielen Vorlesungen: Konstanten in GROSSBUCHSTABEN.
        //
        // Die Konstanten stehen als Felder der Klasse (nicht in Main), damit sie
        // gut sichtbar "oben" stehen. const-Felder sind automatisch statisch.

        // Abkürzungen der Einheiten -> Datentyp string, weil "lbs" mehrere Zeichen hat.
        const string ABK_KILOGRAMM = "kg";
        const string ABK_PFUND = "lbs";
        const string ABK_STONE = "st";

        // Umrechnungsfaktoren -> Datentyp double, weil es Kommazahlen sind.
        // 1 kg = 2,20462 lbs
        const double PFUND_PRO_KILOGRAMM = 2.20462;
        // 1 st = 6,35029 kg
        const double KILOGRAMM_PRO_STONE = 6.35029;
        // (1 st = 14 lbs wird NICHT als eigene Konstante gespeichert: Wir rechnen
        //  immer über Kilogramm als "Basiseinheit". So gibt es keine zweite, eventuell
        //  widersprüchliche Angabe derselben Information.)

        // Menünummern als Konstanten statt "magischer Zahlen" 1/2/3 im Code.
        const int AUSWAHL_KILOGRAMM = 1;
        const int AUSWAHL_PFUND = 2;
        const int AUSWAHL_STONE = 3;

        // Dieselbe Meldung wird an mehreren Stellen gebraucht -> einmal als Konstante.
        const string MELDUNG_EINGABE_ENDE = "Keine weitere Eingabe vorhanden – das Programm wird beendet.";

        static void Main(string[] args)
        {
            // UTF-8-Ausgabe, damit Umlaute (ä, ö, ü) korrekt dargestellt werden; die
            // Windows-Konsole nutzt sonst eine alte Codepage (z. B. 850), in der
            // Sonderzeichen wie "€" als "?" erscheinen (siehe Screenshots der Angabe).
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Willkommen zum Masseneinheitenkonverter!");

            // "weiter" steuert die äußere Programmschleife (Typ bool: nur true/false).
            bool weiter = true;

            // Äußere Schleife: while, weil die Bedingung eine einfache "Flagge" ist,
            // die am Ende jedes Durchlaufs durch die Ja/Nein-Frage gesetzt wird.
            // (Eine do-while-Schleife wäre hier gleichwertig, da "weiter" anfangs true ist.)
            while (weiter)
            {
                // ------------------------------------------------------------
                // 1) Menü anzeigen und Auswahl einlesen (1–3)
                // ------------------------------------------------------------
                Console.WriteLine("Wählen Sie eine Masseneinheit aus:");
                Console.WriteLine(AUSWAHL_KILOGRAMM + ". Kilogramm (" + ABK_KILOGRAMM + ")");
                Console.WriteLine(AUSWAHL_PFUND + ". Pfund (" + ABK_PFUND + ")");
                Console.WriteLine(AUSWAHL_STONE + ". Stone (" + ABK_STONE + ")");
                Console.WriteLine();

                int auswahl;
                bool auswahlGueltig;

                // do-while: Wir MÜSSEN mindestens einmal fragen – die Bedingung kann
                // erst nach der ersten Eingabe geprüft werden ("fußgesteuerte" Schleife).
                do
                {
                    Console.Write("Ihre Auswahl: ");
                    string? auswahlText = Console.ReadLine();

                    // EOF-Schutz: ReadLine() liefert null, wenn die Eingabe zu Ende ist
                    // (Strg+Z bzw. umgeleitete Eingabe aus Datei/Pipe vollständig gelesen).
                    // Es kann dann nie wieder eine gültige Eingabe kommen -> sonst
                    // Endlosschleife. Deshalb Programm sauber beenden.
                    if (auswahlText == null)
                    {
                        Console.WriteLine();
                        Console.WriteLine(MELDUNG_EINGABE_ENDE);
                        return;
                    }

                    // int.TryParse versucht, den Text in eine ganze Zahl umzuwandeln.
                    //   - Erfolg: liefert true und schreibt die Zahl in "auswahl" (out).
                    //   - Misserfolg ("abc", "1,5", ""): liefert false, KEINE Ausnahme.
                    // int.Parse würde bei "abc" dagegen eine Ausnahme werfen und das
                    // Programm abstürzen lassen -> für Benutzereingaben ist TryParse besser.
                    //
                    // Logischer Operator &&: Die Auswahl ist nur gültig, wenn ALLE drei
                    // Bedingungen stimmen. && wertet "kurzschließend" aus: Ist die erste
                    // Bedingung false, werden die restlichen gar nicht mehr geprüft.
                    auswahlGueltig = int.TryParse(auswahlText, out auswahl)
                                     && auswahl >= AUSWAHL_KILOGRAMM
                                     && auswahl <= AUSWAHL_STONE;

                    // Logischer Operator ! (NICHT): kehrt true/false um.
                    if (!auswahlGueltig)
                    {
                        Console.WriteLine("Ungültige Auswahl. Bitte geben Sie 1, 2 oder 3 ein.");
                    }
                } while (!auswahlGueltig);

                // ------------------------------------------------------------
                // 2) Masse einlesen und prüfen
                // ------------------------------------------------------------
                double masse = 0;
                bool masseGueltig = false;

                do
                {
                    Console.Write("Geben Sie die Masse in der ausgewählten Einheit ein: ");
                    string? masseText = Console.ReadLine();

                    if (masseText == null) // EOF-Schutz (siehe oben)
                    {
                        Console.WriteLine();
                        Console.WriteLine(MELDUNG_EINGABE_ENDE);
                        return;
                    }

                    // BEWUSST GESCHACHTELTE VERZWEIGUNG (Lernziel der Aufgabe):
                    // Erst wenn feststeht, DASS es eine Zahl ist (äußeres if), kann man
                    // prüfen, OB die Zahl sinnvoll ist (inneres if). So bekommt der
                    // Benutzer für jeden Fehlerfall eine passende Meldung.
                    //
                    // Hinweis: double.TryParse verwendet die Ländereinstellung (Culture)
                    // des Rechners. Auf einem deutsch eingestellten System ist das Komma
                    // das Dezimaltrennzeichen ("2,5"); ein Punkt wird dort als
                    // Tausender-Trennzeichen interpretiert ("2.5" ergäbe 25!).
                    if (double.TryParse(masseText, out masse))
                    {
                        // double.IsFinite schließt die Sonderwerte "NaN" (keine Zahl) und
                        // "∞" (unendlich) aus, die double.TryParse ebenfalls akzeptiert.
                        if (!double.IsFinite(masse))
                        {
                            Console.WriteLine("Ungültige Masse: Bitte eine endliche Zahl eingeben.");
                        }
                        else if (masse < 0)
                        {
                            Console.WriteLine("Ungültige Masse: Die Masse darf nicht negativ sein.");
                        }
                        else
                        {
                            masseGueltig = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe: \"" + masseText + "\" ist keine Zahl.");
                    }
                } while (!masseGueltig);

                // ------------------------------------------------------------
                // 3) Umrechnen – immer über Kilogramm als Basiseinheit
                // ------------------------------------------------------------
                // Idee: Erst die Eingabe in kg umrechnen, danach aus kg alle anderen
                // Einheiten berechnen. So braucht man nur 2 Faktoren statt 6 Formeln.
                double masseInKilogramm;

                // switch: übersichtlich, wenn EINE Variable mit mehreren festen Werten
                // verglichen wird. Jeder case muss mit "break" enden.
                switch (auswahl)
                {
                    case AUSWAHL_KILOGRAMM:
                        masseInKilogramm = masse;
                        break;
                    case AUSWAHL_PFUND:
                        masseInKilogramm = masse / PFUND_PRO_KILOGRAMM;
                        break;
                    default: // kann nur noch AUSWAHL_STONE sein, wurde oben geprüft
                        masseInKilogramm = masse * KILOGRAMM_PRO_STONE;
                        break;
                }

                double masseInPfund = masseInKilogramm * PFUND_PRO_KILOGRAMM;
                double masseInStone = masseInKilogramm / KILOGRAMM_PRO_STONE;

                // ------------------------------------------------------------
                // 4) Nur die beiden NICHT gewählten Einheiten ausgeben
                // ------------------------------------------------------------
                // Formatierte Ausgabe: {0:F2} = erster Wert nach dem Text, als
                // Festkommazahl mit 2 Nachkommastellen (gerundet, nur für die Anzeige).
                Console.WriteLine();
                Console.WriteLine("Die Masse in den anderen Einheiten:");
                if (auswahl != AUSWAHL_KILOGRAMM)
                {
                    Console.WriteLine("Kilogramm: {0:F2} {1}", masseInKilogramm, ABK_KILOGRAMM);
                }
                if (auswahl != AUSWAHL_PFUND)
                {
                    Console.WriteLine("Pfund: {0:F2} {1}", masseInPfund, ABK_PFUND);
                }
                if (auswahl != AUSWAHL_STONE)
                {
                    Console.WriteLine("Stone: {0:F2} {1}", masseInStone, ABK_STONE);
                }
                Console.WriteLine();

                // ------------------------------------------------------------
                // 5) Weitere Umrechnung? (Ja/Nein) – ungültige Antworten erneut abfragen
                // ------------------------------------------------------------
                bool antwortGueltig = false;
                do
                {
                    Console.Write("Möchten Sie eine weitere Umrechnung durchführen? (Ja/Nein): ");
                    string? antwort = Console.ReadLine();

                    if (antwort == null) // EOF-Schutz (siehe oben)
                    {
                        Console.WriteLine();
                        Console.WriteLine(MELDUNG_EINGABE_ENDE);
                        return;
                    }

                    // Trim() entfernt Leerzeichen am Rand, ToLower() macht alles klein –
                    // so werden "Ja", "ja", " JA " gleich behandelt.
                    antwort = antwort.Trim().ToLower();

                    // Logischer Operator || (ODER): eine der Bedingungen reicht.
                    if (antwort == "ja" || antwort == "j")
                    {
                        weiter = true;
                        antwortGueltig = true;
                        Console.WriteLine();
                    }
                    else if (antwort == "nein" || antwort == "n")
                    {
                        weiter = false;
                        antwortGueltig = true;
                    }
                    else
                    {
                        Console.WriteLine("Bitte antworten Sie mit \"Ja\" oder \"Nein\".");
                    }
                } while (!antwortGueltig);
            }

            Console.WriteLine("Das Programm wird beendet.");
        }
    }
}
