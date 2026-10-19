// =====================================================================================
// UE04 – Aufgabe 4: Leistungsübersicht einer Solaranlage – Hauptprogramm
//                   (klassische Version)
// -------------------------------------------------------------------------------------
// Ziel:
//   Die Solaranlage instanziieren und ein Menü anzeigen, bis der Benutzer 0 eingibt:
//     1 ... Messwerte als Tabelle
//     2 ... Gesamtleistung (kW, 2 Nachkommastellen) und Auslastung (%, 1 Stelle)
//     3 ... Leistung pro Reihe + schwächste Reihe
//   Ungültige Eingaben (Buchstaben, falsche Zahlen) werden abgefangen; bei
//   Eingabeende (EOF) beendet sich das Programm sauber.
//
// Verwendete Konzepte:
//   - Objekt instanziieren, Methoden aufrufen, Rückgabewerte nutzen
//   - do-while-Schleife für das Menü, switch-Anweisung mit break
//   - 1D-Array (Reihenleistungen) mit for-Schleife durchsuchen (Minimum)
//   - int.TryParse für sichere Zahleneingabe
// =====================================================================================

namespace UE04.A4.Solaranlage.Klassisch
{
    internal class Program
    {
        // Daten der Anlage laut Angabe.
        private const string Standort = "Dach Halle A";
        private const int Modulnennleistung = 400; // in Watt

        // Menüpunkte als benannte Konstanten statt "magischer Zahlen" im switch.
        private const int MenueBeenden = 0;
        private const int MenueAnlageAnzeigen = 1;
        private const int MenueGesamtleistung = 2;
        private const int MenueReihenleistung = 3;

        // Wird zurückgegeben, wenn die Eingabe keine Zahl ist. Jeder Wert, der kein
        // Menüpunkt ist, landet im default-Zweig des switch.
        private const int UngueltigeAuswahl = -1;

        // Umrechnung W -> kW. Als double, damit 8470 / 1000.0 = 8,47 ergibt
        // (mit int 1000 wäre es eine Ganzzahl-Division: 8470 / 1000 = 8).
        private const double WattProKilowatt = 1000.0;

        // Breite der Beschriftungen "Gesamtleistung: " / "Auslastung:     " und der
        // Zahlenspalte bei "Reihe 1:   2338 W" (wie im Beispiel der Angabe).
        private const int BreiteBeschriftung = 16;
        private const int BreiteReihenleistung = 7;

        static void Main(string[] args)
        {
            // Umlaute/Sonderzeichen (ä in "Schwächste") in der Windows-Konsole korrekt darstellen.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Instanziierung: Aus der KLASSE Solaranlage (Bauplan) wird ein OBJEKT.
            // Der Konstruktor bekommt Standort und Nennleistung und befüllt die Messwerte.
            Solaranlage anlage = new Solaranlage(Standort, Modulnennleistung);

            // WARUM do-while?
            //   Das Menü muss MINDESTENS EINMAL angezeigt werden, bevor überhaupt eine
            //   Auswahl existiert. do-while prüft die Bedingung erst NACH dem Durchlauf –
            //   genau passend. (Mit while müsste man "auswahl" künstlich vorbelegen.)
            int auswahl;
            do
            {
                ZeigeMenue();
                auswahl = LiesAuswahl();

                // switch-Anweisung: springt zum passenden case. Jedes "break" beendet
                // den switch (NICHT die do-while-Schleife!) – ohne break meldet C# einen
                // Fehler, weil ein "Durchfallen" in den nächsten case nicht erlaubt ist.
                switch (auswahl)
                {
                    case MenueAnlageAnzeigen:
                        Console.WriteLine();
                        anlage.MesswerteAnzeigen();
                        break;
                    case MenueGesamtleistung:
                        ZeigeGesamtleistungUndAuslastung(anlage);
                        break;
                    case MenueReihenleistung:
                        ZeigeReihenleistung(anlage);
                        break;
                    case MenueBeenden:
                        Console.WriteLine("Programm beendet.");
                        break;
                    default:
                        Console.WriteLine("Ungültige Auswahl! Bitte " + MenueAnlageAnzeigen + ", "
                            + MenueGesamtleistung + ", " + MenueReihenleistung + " oder "
                            + MenueBeenden + " eingeben.");
                        break;
                }

                // Leerzeile vor dem nächsten Menü (nicht nach "Programm beendet.").
                if (auswahl != MenueBeenden)
                {
                    Console.WriteLine();
                }
            } while (auswahl != MenueBeenden);
        }

        /// <summary>Gibt das Hauptmenü aus.</summary>
        static void ZeigeMenue()
        {
            Console.WriteLine("========== PV-Monitoring ==========");
            Console.WriteLine(MenueAnlageAnzeigen + " ... Anlage anzeigen");
            Console.WriteLine(MenueGesamtleistung + " ... Gesamtleistung und Auslastung");
            Console.WriteLine(MenueReihenleistung + " ... Leistung pro Reihe");
            Console.WriteLine(MenueBeenden + " ... Programm beenden");
        }

        /// <summary>
        /// Liest die Menüauswahl ein.
        /// </summary>
        /// <returns>
        /// Die eingegebene Zahl; UngueltigeAuswahl, wenn es keine Zahl ist;
        /// MenueBeenden, wenn die Eingabe zu Ende ist (EOF).
        /// </returns>
        static int LiesAuswahl()
        {
            Console.Write("Auswahl: ");
            string? eingabe = LiesZeile();

            // Console.ReadLine() liefert null, wenn keine Eingabe mehr kommen kann
            // (Strg+Z oder umgeleitete Eingabe ist aufgebraucht). Würden wir das als
            // "ungültig" behandeln, liefe das Menü ENDLOS weiter, weil jeder weitere
            // ReadLine()-Aufruf wieder null liefert. Darum: wie "0" behandeln.
            if (eingabe == null)
            {
                Console.WriteLine();
                Console.WriteLine("Keine weitere Eingabe vorhanden.");
                return MenueBeenden;
            }

            // int.TryParse versucht die Umwandlung und meldet über den Rückgabewert,
            // ob sie geklappt hat – anders als int.Parse wirft es bei "abc" keine
            // Exception. Das Ergebnis landet im out-Parameter.
            int auswahl;
            if (!int.TryParse(eingabe, out auswahl))
            {
                return UngueltigeAuswahl;
            }

            return auswahl;
        }

        /// <summary>
        /// Liest eine Zeile ein. Bei umgeleiteter Eingabe (Pipe/Datei) erscheint der
        /// "getippte" Text nicht von selbst in der Konsole – dann geben wir ihn aus,
        /// damit ein Testprotokoll genauso aussieht wie eine echte Sitzung.
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

        /// <summary>Menüpunkt 2: Gesamtleistung in kW und Auslastung in %.</summary>
        static void ZeigeGesamtleistungUndAuslastung(Solaranlage anlage)
        {
            // Die Methode liefert Watt (int); für die Anzeige in kW durch 1000.0 teilen.
            double gesamtleistungInKw = anlage.BerechneGesamtleistung() / WattProKilowatt;
            double auslastungInProzent = anlage.BerechneGesamtauslastung();

            // ToString("F2") = Festkommaformat mit 2 Nachkommastellen (rundet),
            // "F1" mit einer. Das Dezimaltrennzeichen kommt von der Systemsprache
            // (Deutsch: Komma -> 8,47).
            Console.WriteLine("Gesamtleistung:".PadRight(BreiteBeschriftung) + gesamtleistungInKw.ToString("F2") + " kW");
            Console.WriteLine("Auslastung:".PadRight(BreiteBeschriftung) + auslastungInProzent.ToString("F1") + " %");
        }

        /// <summary>Menüpunkt 3: Leistung jeder Reihe und die schwächste Reihe.</summary>
        static void ZeigeReihenleistung(Solaranlage anlage)
        {
            // Rückgabewert der Methode nutzen: ein 1D-Array mit einer Summe pro Reihe.
            int[] reihenleistung = anlage.BerechneReihenleistung();

            for (int reihe = 0; reihe < reihenleistung.Length; reihe++)
            {
                // Reihe + 1, weil Menschen ab 1 zählen, Arrays aber ab 0.
                Console.WriteLine("Reihe " + (reihe + 1) + ":"
                    + reihenleistung[reihe].ToString().PadLeft(BreiteReihenleistung) + " W");
            }

            Console.WriteLine("Schwächste Reihe: " + (ErmittleSchwaechsteReihe(reihenleistung) + 1));
        }

        /// <summary>
        /// Sucht den Index des kleinsten Werts im Array (klassische Minimumsuche).
        /// Bei Gleichstand gewinnt die erste Reihe.
        /// </summary>
        /// <returns>0-basierter Index der schwächsten Reihe.</returns>
        static int ErmittleSchwaechsteReihe(int[] reihenleistung)
        {
            // Annahme: Reihe 0 ist die schwächste. Dann alle weiteren damit vergleichen
            // und die Annahme korrigieren, sobald eine noch schwächere auftaucht.
            // (Die Anlage hat immer mindestens eine Reihe, Index 0 existiert also.)
            int schwaechsteReihe = 0;

            for (int reihe = 1; reihe < reihenleistung.Length; reihe++)
            {
                if (reihenleistung[reihe] < reihenleistung[schwaechsteReihe])
                {
                    schwaechsteReihe = reihe;
                }
            }

            return schwaechsteReihe;
        }
    }
}
