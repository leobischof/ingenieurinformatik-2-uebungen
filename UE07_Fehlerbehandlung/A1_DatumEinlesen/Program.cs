// UE07 – Aufgabe 1: Datum einlesen – Leo Bischof (12320283)

namespace UE07.A1.DatumEinlesen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // damit Umlaute richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Willkommen in der Datum-Parser Anwendung!");

            // so lange wiederholen, bis die Umwandlung einmal geklappt hat
            bool erfolgreich = false;
            while (!erfolgreich)
            {
                Console.Write("Bitte geben Sie ein Format für das Datum ein: ");
                string format = Console.ReadLine();
                Console.Write($"Bitte geben Sie ein Datum im Format {format} ein: ");
                string datum = Console.ReadLine();

                // try: der Code, der einen Laufzeitfehler (Exception) auslösen kann
                try
                {
                    // null = Standardeinstellungen des Computers für Monatsnamen usw.
                    DateTime dateTime = DateTime.ParseExact(datum, format, null);
                    Console.WriteLine($"Das geparste Datum im ISO-Format: {dateTime.ToString("yyyy-MM-dd")}");
                    erfolgreich = true;
                }
                // Laut Dokumentation wirft ParseExact genau diese zwei Exceptions:
                catch (FormatException)
                {
                    // Datum oder Format ist leer, das Format ist ungültig oder das Datum passt nicht zum Format
                    Console.WriteLine("Fehler: Das Datum passt nicht zum angegebenen Format (oder eine Eingabe ist leer).");
                    Console.WriteLine();
                }
                catch (ArgumentNullException)
                {
                    // Datum oder Format ist null, z. B. wenn die Eingabe abgebrochen wurde
                    Console.WriteLine("Fehler: Es wurde kein Datum oder kein Format eingegeben.");
                    Console.WriteLine();
                }
                // zur Sicherheit: alles, was oben nicht abgefangen wurde
                catch (Exception ex)
                {
                    Console.WriteLine($"Unerwarteter Fehler: {ex.Message}");
                    Console.WriteLine();
                }
            }
        }
    }
}
