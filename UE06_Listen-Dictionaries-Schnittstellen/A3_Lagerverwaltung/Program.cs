// UE06 – Aufgabe 3: Lagerverwaltung – Leo Bischof (12320283)

namespace UE06.A3.Lagerverwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // damit Umlaute richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Schlüssel = Artikelnummer, Wert = das Artikel-Objekt (wie ein dict in Python)
            Dictionary<string, Artikel> lager = new Dictionary<string, Artikel>();
            lager.Add("A-100", new Artikel("A-100", "Schraube M8", 500, 0.12));
            lager.Add("A-200", new Artikel("A-200", "Mutter M8", 800, 0.08));
            lager.Add("B-100", new Artikel("B-100", "Welle d=20mm", 25, 14.90));
            lager.Add("C-300", new Artikel("C-300", "Kugellager 6204", 60, 6.50));

            int auswahl = -1;
            while (auswahl != 0)
            {
                ZeigeMenue();
                Console.Write("Auswahl: ");
                if (!int.TryParse(Console.ReadLine(), out auswahl))
                {
                    // -1 landet unten im default-Zweig und die Schleife läuft weiter
                    auswahl = -1;
                }
                Console.WriteLine();

                switch (auswahl)
                {
                    case 1:
                        ZeigeLagerbestand(lager);
                        break;
                    case 2:
                        ArtikelAnlegen(lager);
                        break;
                    case 3:
                        BuchungDurchfuehren(lager);
                        break;
                    case 4:
                        ArtikelLoeschen(lager);
                        break;
                    case 5:
                        ZeigeGesamtwert(lager);
                        break;
                    case 6:
                        Experiment(lager);
                        break;
                    case 0:
                        Console.WriteLine("Programm beendet.");
                        break;
                    default:
                        Console.WriteLine("Ungültige Auswahl!");
                        break;
                }
                Console.WriteLine();
            }
        }

        /// <summary>Gibt das Hauptmenü aus.</summary>
        static void ZeigeMenue()
        {
            Console.WriteLine("========== Lagerverwaltung ==========");
            Console.WriteLine("1 ... Lagerbestand anzeigen");
            Console.WriteLine("2 ... Artikel anlegen");
            Console.WriteLine("3 ... Wareneingang / Warenausgang buchen");
            Console.WriteLine("4 ... Artikel löschen");
            Console.WriteLine("5 ... Gesamten Lagerwert berechnen");
            Console.WriteLine("6 ... Experiment: ContainsKey vs. ContainsValue");
            Console.WriteLine("0 ... Programm beenden");
        }

        /// <summary>Gibt alle Artikel als Tabelle aus.</summary>
        static void ZeigeLagerbestand(Dictionary<string, Artikel> lager)
        {
            Console.WriteLine("Nr.     Bezeichnung        Bestand      Preis");
            // kvp.Key ist die Artikelnummer, kvp.Value das Artikel-Objekt (wie dict.items() in Python)
            foreach (KeyValuePair<string, Artikel> kvp in lager)
            {
                Artikel artikel = kvp.Value;
                Console.WriteLine($"{kvp.Key.PadRight(8)}{artikel.GetBezeichnung().PadRight(18)}{artikel.GetBestand().ToString().PadLeft(8)}{artikel.GetPreis().ToString("0.00").PadLeft(11)} EUR");
            }
        }

        /// <summary>Fragt die Daten ab und legt einen neuen Artikel an, wenn die Nummer noch frei ist.</summary>
        static void ArtikelAnlegen(Dictionary<string, Artikel> lager)
        {
            string nummer = LeseArtikelnummer();

            // Add würde bei einem doppelten Schlüssel abstürzen, darum vorher mit ContainsKey prüfen
            if (lager.ContainsKey(nummer))
            {
                Console.WriteLine($"Fehler: Die Artikelnummer {nummer} existiert bereits.");
                return;
            }

            Console.Write("Bezeichnung: ");
            string bezeichnung = Console.ReadLine();
            int bestand = LeseGanzzahl("Bestand: ");
            double preis = LeseKommazahl("Preis in EUR: ");

            lager.Add(nummer, new Artikel(nummer, bezeichnung, bestand, preis));
            Console.WriteLine($"Artikel {nummer} wurde angelegt.");
        }

        /// <summary>Bucht einen Wareneingang oder Warenausgang für einen Artikel.</summary>
        static void BuchungDurchfuehren(Dictionary<string, Artikel> lager)
        {
            string nummer = LeseArtikelnummer();

            // TryGetValue prüft und holt in einem Schritt: true + Artikel in "artikel", wenn es ihn gibt
            Artikel artikel;
            if (!lager.TryGetValue(nummer, out artikel))
            {
                Console.WriteLine($"Fehler: Artikel {nummer} nicht gefunden.");
                return;
            }

            int art = LeseGanzzahl("1 = Wareneingang, 2 = Warenausgang: ");
            if (art != 1 && art != 2)
            {
                Console.WriteLine("Fehler: Bitte 1 oder 2 eingeben.");
                return;
            }

            int menge = LeseGanzzahl("Menge: ");

            if (art == 1)
            {
                artikel.Einlagern(menge);
            }
            else if (!artikel.Entnehmen(menge))
            {
                // Entnehmen hat false zurückgegeben, der Bestand ist unverändert
                Console.WriteLine($"Fehler: Nicht genügend Bestand (verfügbar: {artikel.GetBestand()}).");
                return;
            }

            Console.WriteLine($"Neuer Bestand: {artikel.GetBestand()}");
        }

        /// <summary>Löscht einen Artikel aus dem Lager.</summary>
        static void ArtikelLoeschen(Dictionary<string, Artikel> lager)
        {
            string nummer = LeseArtikelnummer();

            // Remove gibt true zurück, wenn es den Schlüssel gab, sonst false
            if (lager.Remove(nummer))
            {
                Console.WriteLine($"Artikel {nummer} wurde gelöscht.");
            }
            else
            {
                Console.WriteLine($"Fehler: Artikel {nummer} nicht gefunden.");
            }
        }

        /// <summary>Berechnet den Wert aller Artikel (Bestand mal Preis) und gibt ihn aus.</summary>
        static void ZeigeGesamtwert(Dictionary<string, Artikel> lager)
        {
            double gesamtwert = 0;
            // Values = nur die Artikel-Objekte, ohne Schlüssel (wie dict.values() in Python)
            foreach (Artikel artikel in lager.Values)
            {
                gesamtwert = gesamtwert + artikel.GetBestand() * artikel.GetPreis();
            }
            Console.WriteLine($"Gesamter Lagerwert: {gesamtwert.ToString("0.00")} EUR ({lager.Count} Artikel)");
        }

        /// <summary>Vergleicht ContainsKey und ContainsValue mit dem Original und einer Kopie des ersten Artikels.</summary>
        static void Experiment(Dictionary<string, Artikel> lager)
        {
            if (lager.Count == 0)
            {
                Console.WriteLine("Das Lager ist leer, kein Experiment möglich.");
                return;
            }

            // den ersten Artikel holen: Schleife nach dem ersten Durchlauf abbrechen
            Artikel original = null;
            foreach (Artikel artikel in lager.Values)
            {
                original = artikel;
                break;
            }

            // neues Objekt mit genau denselben Daten
            Artikel kopie = new Artikel(original.GetArtikelnummer(), original.GetBezeichnung(), original.GetBestand(), original.GetPreis());

            Console.WriteLine($"ContainsKey(\"{original.GetArtikelnummer()}\"): {lager.ContainsKey(original.GetArtikelnummer())}");
            Console.WriteLine($"ContainsValue(Original): {lager.ContainsValue(original)}");
            Console.WriteLine($"ContainsValue(Kopie):    {lager.ContainsValue(kopie)}");

            // a) ContainsValue(Kopie) ist false, weil Objekte ohne eigenes Equals über ihre Referenz verglichen werden:
            //    Es wird geprüft, ob genau DIESES Objekt im Speicher im Dictionary liegt, nicht ob die Daten gleich sind.
            //    Die Kopie ist ein zweites Objekt mit gleichem Inhalt, also ein anderes Objekt (in Python: "is" statt "==").
        }

        /// <summary>Liest eine Artikelnummer ein und wandelt sie in Großbuchstaben um (a-100 wird A-100).</summary>
        static string LeseArtikelnummer()
        {
            Console.Write("Artikelnummer: ");
            return Console.ReadLine().Trim().ToUpper();
        }

        /// <summary>Fragt so lange, bis eine ganze Zahl ab 0 eingegeben wurde.</summary>
        static int LeseGanzzahl(string frage)
        {
            Console.Write(frage);
            int zahl;
            while (!int.TryParse(Console.ReadLine(), out zahl) || zahl < 0)
            {
                Console.Write("Ungültige Eingabe! Bitte eine ganze Zahl ab 0 eingeben: ");
            }
            return zahl;
        }

        /// <summary>Fragt so lange, bis eine Kommazahl ab 0 eingegeben wurde.</summary>
        static double LeseKommazahl(string frage)
        {
            Console.Write(frage);
            double zahl;
            while (!double.TryParse(Console.ReadLine(), out zahl) || zahl < 0)
            {
                Console.Write("Ungültige Eingabe! Bitte eine Zahl ab 0 eingeben: ");
            }
            return zahl;
        }

        // b) Array: feste Größe, Zugriff über die Position (0, 1, 2 ...). Gut, wenn die Anzahl vorher feststeht (z. B. Matrix).
        //    List: wächst und schrumpft (Add, Remove), Zugriff auch über die Position. Gut für Reihenfolgen, die sortiert werden.
        //    Dictionary: Paare aus Schlüssel und Wert, Zugriff direkt über den Schlüssel. Gut zum schnellen Nachschlagen.
        //    Hier passt ein Dictionary, weil man Artikel immer über ihre eindeutige Artikelnummer sucht und doppelte Nummern verboten sind.
    }
}
