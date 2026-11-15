// UE07 – Aufgabe 3: Zugstab – Leo Bischof (12320283)

namespace UE07.A3.Zugstab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // damit Umlaute und ² richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Zugstab ===");

            try
            {
                bool fertig = false;
                while (!fertig)
                {
                    double durchmesser = LeseWert("Durchmesser d [mm]: ");
                    double streckgrenze = LeseWert("Streckgrenze Re [N/mm²]: ");
                    double kraft = LeseWert("Zugkraft F [N]: ");

                    try
                    {
                        Zugstab stab = new Zugstab(durchmesser, streckgrenze);
                        double spannung = stab.Spannung(kraft);
                        double sicherheit = stab.GetStreckgrenze() / spannung;

                        Console.WriteLine();
                        Console.WriteLine($"Spannung sigma:      {spannung.ToString("0.00")} N/mm²");
                        Console.WriteLine($"Sicherheitsfaktor S: {sicherheit.ToString("0.00")}");
                        fertig = true;
                    }
                    catch (InvalidOperationException ex)
                    {
                        // Streckgrenze überschritten: Meldung zeigen, Schleife läuft weiter und fragt alles neu ab
                        Console.WriteLine();
                        Console.WriteLine($"Fehler: {ex.Message}! Bitte neue Werte eingeben.");
                        Console.WriteLine();
                    }
                }
            }
            // allgemeiner Fall: jede andere Exception (z. B. ArgumentOutOfRangeException aus dem Konstruktor)
            catch (Exception ex)
            {
                Console.WriteLine($"Unerwarteter Fehler: {ex.Message}");
            }
            // finally läuft immer, egal ob alles geklappt hat oder ein Fehler aufgetreten ist
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Auf Wiedersehen!");
            }
        }

        /// <summary>Liest einen Wert ein und fragt nur diesen Wert neu, bis eine Zahl größer als 0 eingegeben wurde.</summary>
        static double LeseWert(string frage)
        {
            while (true)
            {
                Console.Write(frage);
                try
                {
                    double wert = double.Parse(Console.ReadLine());
                    if (wert <= 0)
                    {
                        throw new ArgumentOutOfRangeException("wert", "Der Wert muss größer als 0 sein.");
                    }
                    // return beendet die Methode und damit auch die Schleife
                    return wert;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ungültige Eingabe! Bitte eine Zahl eingeben.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Ungültige Eingabe! Der Wert muss größer als 0 sein.");
                }
            }
        }
    }
}
