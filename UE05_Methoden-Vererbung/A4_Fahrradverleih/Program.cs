// UE05 – Aufgabe 4: Fahrradverleih – Leo Bischof (12320283)

namespace UE05.A4.Fahrradverleih
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // damit Umlaute richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Das Array hat den Typ Fahrrad, darin liegen aber Citybike, Mountainbike und EBike.
            Fahrrad[] fahrraeder = new Fahrrad[] { new Citybike(), new Mountainbike(), new EBike() };

            Console.WriteLine("Willkommen beim Fahrradverleih!");
            Console.WriteLine();
            Console.WriteLine("Folgende Modelle stehen zur Auswahl:");
            Console.WriteLine();
            ZeigeModelltabelle(fahrraeder);
            Console.WriteLine();
            Console.WriteLine($"Inkludiert sind {Fahrrad.GetInklusiveKm()} km und {Fahrrad.GetInklusiveStunden()} Stunden Mietdauer.");
            Console.WriteLine("Zusätzliche Kilometer und Stunden werden verrechnet.");
            Console.WriteLine();

            int modell = LeseZahl("Bitte wählen Sie ein Modell (1, 2 oder 3):", 1, 3);
            Fahrrad fahrrad = fahrraeder[modell - 1];

            // bei "n" bleiben die Zusatzwerte 0
            Console.WriteLine();
            if (LeseJaNein("Möchten Sie zusätzliche Kilometer buchen? (j/n)"))
            {
                fahrrad.SetZusatzKm(LeseZahl("Wie viele zusätzliche Kilometer?", 1, 1000));
            }

            Console.WriteLine();
            if (LeseJaNein("Möchten Sie zusätzliche Stunden buchen? (j/n)"))
            {
                fahrrad.SetZusatzStunden(LeseZahl("Wie viele zusätzliche Stunden?", 1, 72));
            }

            // BerechneKosten ist virtual: Bei einem E-Bike läuft automatisch die Version aus EBike (mit Pauschale).
            double kosten = fahrrad.BerechneKosten();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Ihre Gesamtkosten belaufen sich auf {kosten.ToString("0.00")} Euro!");
            Console.WriteLine($"Gesamtzeit:    {fahrrad.GetGesamtStunden()} Stunden");
            Console.WriteLine($"Gesamtstrecke: {fahrrad.GetGesamtKm()} km");
            Console.WriteLine();
            Console.WriteLine("Vielen Dank und gute Fahrt!");
        }

        // static: Die Hilfsmethoden brauchen keine Daten eines Program-Objekts, und Main (auch static) kann sie direkt aufrufen.

        /// <summary>Gibt die Frage aus und fragt so lange neu, bis eine ganze Zahl von min bis max eingegeben wurde.</summary>
        static int LeseZahl(string frage, int min, int max)
        {
            Console.WriteLine(frage);

            int zahl;
            while (!int.TryParse(Console.ReadLine(), out zahl) || zahl < min || zahl > max)
            {
                Console.WriteLine($"Ungültige Eingabe! Bitte eine ganze Zahl von {min} bis {max} eingeben:");
            }

            return zahl;
        }

        /// <summary>Gibt die Frage aus und fragt so lange neu, bis j oder n eingegeben wurde. Liefert true bei j.</summary>
        static bool LeseJaNein(string frage)
        {
            Console.WriteLine(frage);

            string eingabe = Console.ReadLine();
            while (eingabe != "j" && eingabe != "n")
            {
                Console.WriteLine("Ungültige Eingabe! Bitte j oder n eingeben:");
                eingabe = Console.ReadLine();
            }

            return eingabe == "j";
        }

        /// <summary>Gibt die Modelle mit Grundgebühr und Zusatzpreisen als Tabelle aus.</summary>
        static void ZeigeModelltabelle(Fahrrad[] fahrraeder)
        {
            // PadRight füllt den Text mit Leerzeichen auf, damit die Spalten untereinander stehen
            Console.WriteLine("Modell".PadRight(20) + "Grundgebühr".PadRight(18) + "Zusätzl. Euro/km".PadRight(18) + "Zusätzl. Euro/Stunde");

            for (int i = 0; i < fahrraeder.Length; i++)
            {
                Fahrrad fahrrad = fahrraeder[i];
                string spalte1 = $"{i + 1}: {fahrrad.GetModellname()}".PadRight(20);
                string spalte2 = $"{fahrrad.GetGrundgebuehr()} Euro".PadRight(18);
                string spalte3 = $"{fahrrad.GetPreisProKm().ToString("0.00")} Euro".PadRight(18);
                string spalte4 = $"{fahrrad.GetPreisProStunde()} Euro";
                Console.WriteLine(spalte1 + spalte2 + spalte3 + spalte4);
            }
        }
    }
}
