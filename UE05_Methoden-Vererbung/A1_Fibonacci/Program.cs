// UE05 – Aufgabe 1: Fibonacci rekursiv – Leo Bischof (12320283)

namespace UE05.A1.Fibonacci
{
    internal class Program
    {
        // static: gehört zur Klasse selbst, deshalb kann die statische Main-Methode direkt darauf zugreifen.
        // Über 40 wird die Rekursion sehr langsam, ab 47 passt das Ergebnis nicht mehr in einen int.
        private static int maxStelle = 40;

        static void Main(string[] args)
        {
            // damit Umlaute richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine($"Welche Stelle der Fibonacci-Folge möchten Sie berechnen? (1 bis {maxStelle})");

            // so lange neu fragen, bis eine gültige Zahl im erlaubten Bereich eingegeben wurde
            int stelle;
            while (!int.TryParse(Console.ReadLine(), out stelle) || stelle < 1 || stelle > maxStelle)
            {
                Console.WriteLine($"Ungültige Eingabe! Bitte eine ganze Zahl von 1 bis {maxStelle} eingeben:");
            }

            int ergebnis = Fibonacci(stelle);
            Console.WriteLine($"Die {stelle}. Fibonacci-Zahl ist {ergebnis}.");
        }

        /// <summary>Berechnet die Fibonacci-Zahl an der gegebenen Stelle rekursiv.</summary>
        static int Fibonacci(int n)
        {
            // Abbruchbedingung: die ersten zwei Zahlen der Folge sind 1
            if (n <= 2)
            {
                return 1;
            }

            // die Methode ruft sich selbst auf (Rekursion): Summe der zwei Zahlen davor
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
