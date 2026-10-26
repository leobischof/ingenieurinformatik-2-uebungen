// UE05 – Aufgabe 3: Immobilienverwaltung – Leo Bischof (12320283)

namespace UE05.A3.Immobilienverwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // damit Umlaute richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Herzlich willkommen zum Immobilienverwaltungs-Kostenrechner. Bitte wählen Sie aus welche Art von Immobilie Sie verwalten lassen möchten:");
            Console.WriteLine("1. Einfamilienhaus");
            Console.WriteLine("2. Zinshaus");
            Console.WriteLine("3. Geschäftsfläche");
            int art = LeseZahl(1, 3);

            Console.WriteLine("\nGeben Sie die Fläche in m^2 an:");
            double flaeche = LeseFlaeche();

            // Die Variable hat den Typ der Basisklasse, das Objekt darin ist aber ein EFH, Zinshaus oder eine Geschäftsfläche.
            Immobilie immobilie;
            switch (art)
            {
                case 1:
                    Einfamilienhaus haus = new Einfamilienhaus(flaeche);
                    Console.WriteLine("\nHat das Gebäude einen Garten? 1 für ja und 2 für nein.");
                    haus.SetHatGarten(LeseZahl(1, 2) == 1);
                    Console.WriteLine("\nHat das Gebäude eine Garage? 1 für ja und 2 für nein.");
                    haus.SetHatGarage(LeseZahl(1, 2) == 1);
                    immobilie = haus;
                    break;
                case 2:
                    Zinshaus zinshaus = new Zinshaus(flaeche);
                    Console.WriteLine("\nGeben Sie die Anzahl der Wohnungen an.");
                    zinshaus.SetAnzahlWohnungen(LeseZahl(1, 1000));
                    immobilie = zinshaus;
                    break;
                default:
                    // bleibt nur noch 3 übrig: Geschäftsfläche
                    immobilie = new Geschaeftsflaeche(flaeche);
                    break;
            }

            // Dank virtual/override wird automatisch die Methode der passenden Unterklasse aufgerufen.
            double kosten = Math.Round(immobilie.BerechneJahreskosten(), 2);
            Console.WriteLine($"\nDie Gesamtverwaltungskosten für {immobilie.GetBezeichnung()} betragen: {kosten} Euro pro Jahr.");
        }

        // static: Die Hilfsmethode braucht kein Objekt, sie wird direkt aus Main aufgerufen.
        /// <summary>Liest so lange ein, bis eine ganze Zahl zwischen minimum und maximum eingegeben wurde.</summary>
        static int LeseZahl(int minimum, int maximum)
        {
            int zahl;
            while (!int.TryParse(Console.ReadLine(), out zahl) || zahl < minimum || zahl > maximum)
            {
                Console.WriteLine($"Ungültige Eingabe! Bitte eine ganze Zahl von {minimum} bis {maximum} eingeben:");
            }
            return zahl;
        }

        /// <summary>Liest so lange ein, bis eine Fläche größer als 0 eingegeben wurde.</summary>
        static double LeseFlaeche()
        {
            double flaeche;
            while (!double.TryParse(Console.ReadLine(), out flaeche) || flaeche <= 0)
            {
                Console.WriteLine("Ungültige Eingabe! Bitte eine Zahl größer als 0 eingeben:");
            }
            return flaeche;
        }
    }
}
