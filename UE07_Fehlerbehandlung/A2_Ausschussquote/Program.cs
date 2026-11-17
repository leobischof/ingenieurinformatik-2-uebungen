// UE07 – Aufgabe 2: Ausschussquote – Leo Bischof (12320283)

namespace UE07.A2.Ausschussquote
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // damit Umlaute richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Ausschussquote ===");

            bool weiter = true;
            while (weiter)
            {
                try
                {
                    // int.Parse statt TryParse: bei "drei" wird absichtlich eine FormatException ausgelöst
                    Console.Write("Produzierte Teile: ");
                    int produziert = int.Parse(Console.ReadLine());
                    Console.Write("Ausschussteile: ");
                    int ausschuss = int.Parse(Console.ReadLine());

                    double quote = BerechneAusschussquote(produziert, ausschuss);
                    Console.WriteLine();
                    Console.WriteLine($"Ausschussquote: {quote.ToString("0.00")} %");
                }
                catch (FormatException)
                {
                    // keine ganze Zahl eingegeben (z. B. "drei" oder "2,5")
                    Console.WriteLine();
                    Console.WriteLine("Ungültige Eingabe! Bitte ganze Zahlen eingeben.");
                }
                catch (OverflowException)
                {
                    // Zahl zu groß für int (über ca. 2,1 Milliarden)
                    Console.WriteLine();
                    Console.WriteLine("Ungültige Eingabe! Die Zahl ist zu groß.");
                }
                catch (ArgumentException ex)
                {
                    // kommt von unserem eigenen throw in BerechneAusschussquote, ex.Message ist unser Text
                    Console.WriteLine();
                    Console.WriteLine("Unplausible Eingabe!");
                    Console.WriteLine(ex.Message);
                }
                // finally läuft IMMER, egal ob ein Fehler aufgetreten ist oder nicht
                finally
                {
                    Console.WriteLine();
                    Console.Write("Weitere Berechnung? (j/n): ");
                    weiter = Console.ReadLine().Trim().ToLower() == "j";
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Programm beendet.");
        }

        /// <summary>Berechnet die Ausschussquote in Prozent. Wirft eine ArgumentException bei unplausiblen Werten.</summary>
        static double BerechneAusschussquote(int produziert, int ausschuss)
        {
            if (produziert <= 0)
            {
                // throw bricht die Methode sofort ab und springt in den passenden catch-Block in Main
                throw new ArgumentException("Es muss mindestens ein Teil produziert worden sein.");
            }
            if (ausschuss < 0 || ausschuss > produziert)
            {
                throw new ArgumentException("Ausschuss muss zwischen 0 und Teileanzahl liegen.");
            }

            // (double) damit nicht ganzzahlig geteilt wird (30 / 1200 wäre sonst 0)
            return (double)ausschuss / produziert * 100;
        }
    }
}
