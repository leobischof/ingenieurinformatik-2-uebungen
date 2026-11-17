// UE06 – Aufgabe 4: Fertigungsaufträge – Leo Bischof (12320283)

namespace UE06.A4.Fertigungsauftraege
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // damit Umlaute richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Produktionsstart heute um 6 Uhr. Alle Liefertermine sind "Start + so viele Stunden".
            DateTime start = DateTime.Today.AddHours(6);

            List<Auftrag> auftraege = new List<Auftrag>();
            auftraege.Add(new Auftrag(1001, "Antriebswelle", TimeSpan.FromHours(6), start + TimeSpan.FromHours(20)));
            auftraege.Add(new Auftrag(1002, "Lagerdeckel", TimeSpan.FromHours(3), start + TimeSpan.FromHours(14)));
            auftraege.Add(new Auftrag(1003, "Getriebegehäuse", TimeSpan.FromHours(12), start + TimeSpan.FromHours(40)));
            auftraege.Add(new Auftrag(1004, "Zahnrad z=42", TimeSpan.FromHours(5), start + TimeSpan.FromHours(14)));
            auftraege.Add(new Auftrag(1005, "Flansch DN50", TimeSpan.FromHours(2), start + TimeSpan.FromHours(30)));
            auftraege.Add(new Auftrag(1006, "Ritzelwelle", TimeSpan.FromHours(8), start + TimeSpan.FromHours(22)));
            auftraege.Add(new Auftrag(1007, "Distanzhülse", TimeSpan.FromHours(2), start + TimeSpan.FromHours(8)));
            auftraege.Add(new Auftrag(1008, "Kupplungsnabe", TimeSpan.FromHours(4), start + TimeSpan.FromHours(36)));

            Console.WriteLine("=== Offene Aufträge ===");
            Console.WriteLine("Nr.  | Artikel          | Dauer | Termin");
            foreach (Auftrag auftrag in auftraege)
            {
                Console.WriteLine(auftrag);
            }
            Console.WriteLine();

            // so lange fragen, bis wirklich ein Auftrag storniert wurde
            bool storniert = false;
            while (!storniert)
            {
                Console.Write("Zu stornierender Auftrag (Nr.): ");
                int nummer;
                while (!int.TryParse(Console.ReadLine(), out nummer))
                {
                    Console.Write("Ungültige Eingabe! Bitte eine Auftragsnummer eingeben: ");
                }
                storniert = AuftragStornieren(auftraege, nummer);
            }
            Console.WriteLine();

            // Sort() ohne Parameter verwendet CompareTo aus Auftrag (KOZ)
            auftraege.Sort();
            GibPlanAus("Reihenfolge nach KOZ-Regel (kürzeste Operationszeit)", auftraege, start);

            // Sort mit Comparer-Objekt verwendet stattdessen dessen Compare-Methode (FLT)
            auftraege.Sort(new LieferterminComparer());
            GibPlanAus("Reihenfolge nach FLT-Regel (frühester Liefertermin)", auftraege, start);
        }

        /// <summary>Sucht den Auftrag mit der Nummer und löscht ihn. Gibt false zurück, wenn es ihn nicht gibt.</summary>
        static bool AuftragStornieren(List<Auftrag> auftraege, int nummer)
        {
            for (int i = 0; i < auftraege.Count; i++)
            {
                if (auftraege[i].GetAuftragsnummer() == nummer)
                {
                    auftraege.RemoveAt(i);
                    Console.WriteLine($"Auftrag {nummer} wurde storniert.");
                    return true;
                }
            }

            Console.WriteLine($"Auftrag {nummer} existiert nicht.");
            return false;
        }

        /// <summary>Gibt den Plan mit Produktionsende und Verspätung je Auftrag sowie die Kennzahlen aus.</summary>
        static void GibPlanAus(string titel, List<Auftrag> auftraege, DateTime start)
        {
            Console.WriteLine($"=== {titel} ===");
            Console.WriteLine("Pos | Nr.  | Artikel          | Dauer | Termin           | Ende             | Verspätung");

            // Die Maschine arbeitet einen Auftrag nach dem anderen ab: jedes Ende ist das vorige Ende plus die Dauer.
            DateTime ende = start;
            double summeDurchlaufzeit = 0;
            int anzahlVerspaetet = 0;

            for (int i = 0; i < auftraege.Count; i++)
            {
                Auftrag auftrag = auftraege[i];
                ende = ende + auftrag.GetBearbeitungszeit();

                // Verspätung = Ende minus Termin, aber nie negativ (zu früh fertig zählt als 0)
                TimeSpan verspaetung = ende - auftrag.GetLiefertermin();
                if (verspaetung < TimeSpan.Zero)
                {
                    verspaetung = TimeSpan.Zero;
                }
                else if (verspaetung > TimeSpan.Zero)
                {
                    anzahlVerspaetet++;
                }

                // Durchlaufzeit = wie lange der Auftrag ab Produktionsstart gebraucht hat, bis er fertig war
                summeDurchlaufzeit = summeDurchlaufzeit + (ende - start).TotalHours;

                Console.WriteLine($"{(i + 1).ToString().PadLeft(3)} | {auftrag} | {ende.ToString("dd.MM.yyyy HH:mm")} | {verspaetung.TotalHours.ToString().PadLeft(8)} h");
            }

            double mittlereDurchlaufzeit = summeDurchlaufzeit / auftraege.Count;
            Console.WriteLine();
            Console.WriteLine($"Mittlere Durchlaufzeit:      {mittlereDurchlaufzeit.ToString("0.00")} h");
            Console.WriteLine($"Anzahl verspäteter Aufträge: {anzahlVerspaetet}");
            Console.WriteLine();
        }
    }
}
