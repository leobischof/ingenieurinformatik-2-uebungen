// UE04 – Aufgabe 1: Multiplikationstabelle – Leo Bischof (12320283)

namespace UE04.A1.Multiplikationstabelle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // damit Umlaute und € richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ein 2-dimensionales Array mit 10 Zeilen und 10 Spalten
            int[,] tabelle = new int[10, 10];
            FuelleTabelle(tabelle);

            Console.WriteLine("Multiplikationstabelle von 1 bis 10: \n");
            GibTabelleAus(tabelle);
        }

        /// <summary>Füllt jede Zelle mit dem Produkt aus Zeilen- und Spaltennummer.</summary>
        static void FuelleTabelle(int[,] tabelle)
        {

            // Array-Indizes beginnen bei 0, deshalb rechnen wir mit "+ 1"
            const int array_start = 1;
            for (int zeile = 0; zeile < 10; zeile++)
            {
                for (int spalte = 0; spalte < 10; spalte++)
                {
                    tabelle[zeile, spalte] = (zeile + array_start) * (spalte + array_start);
                }
            }
        }

        /// <summary>Gibt die Tabelle Zeile für Zeile aus, rechtsbündig.</summary>
        static void GibTabelleAus(int[,] tabelle)
        {
            for (int zeile = 0; zeile < 10; zeile++)
            {
                for (int spalte = 0; spalte < 10; spalte++)
                {
                    // PadLeft(4) füllt links mit Leerzeichen auf 4 Zeichen auf, die Zahlen stehen rechtsbündig
                    Console.Write(tabelle[zeile, spalte].ToString().PadLeft(4));
                }

                // am Ende jeder Zeile ein Zeilenumbruch
                Console.WriteLine();
            }
        }
    }
}
