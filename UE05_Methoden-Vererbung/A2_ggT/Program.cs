// UE05 – Aufgabe 2: Größter gemeinsamer Teiler – Leo Bischof (12320283)

namespace UE05.A2.ggT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // damit Umlaute richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int untereGrenze = LeseZahl("Bitte die untere Grenze eingeben:");
            int obereGrenze = LeseZahl("Bitte die obere Grenze eingeben:");

            // die untere Grenze muss kleiner sein, sonst nur die obere Grenze neu eingeben
            while (untereGrenze >= obereGrenze)
            {
                Console.WriteLine("Ungültige Eingabe! Die obere Grenze muss größer als die untere Grenze sein.");
                obereGrenze = LeseZahl("Bitte die obere Grenze erneut eingeben:");
            }

            // Random.Next(a, b) liefert Zahlen von a bis b - 1, deshalb obereGrenze + 1, damit sie auch vorkommen kann
            Random rng = new Random();
            int zahl1 = rng.Next(untereGrenze, obereGrenze + 1);
            int zahl2 = rng.Next(untereGrenze, obereGrenze + 1);
            Console.WriteLine($"Die Zufallszahlen sind {zahl1} und {zahl2}.");

            Console.WriteLine($"ggT rekursiv: {GgtRekursiv(zahl1, zahl2)}");
            Console.WriteLine($"ggT mit Schleife: {GgtSchleife(zahl1, zahl2)}");

            // Vergleich: Beide Varianten machen gleich viele %-Rechnungen und Vergleiche (b == 0 bzw. b != 0).
            // Die rekursive Variante braucht pro Schritt zusätzlich einen Methodenaufruf, der Speicher
            // auf dem Stack belegt. Die Schleife ist daher etwas effizienter.
        }

        /// <summary>Liest eine ganze Zahl ab 1 ein und fragt bei falscher Eingabe neu.</summary>
        static int LeseZahl(string frage)
        {
            Console.WriteLine(frage);

            int zahl;
            while (!int.TryParse(Console.ReadLine(), out zahl) || zahl < 1)
            {
                Console.WriteLine("Ungültige Eingabe! Bitte eine ganze Zahl ab 1 eingeben:");
            }
            return zahl;
        }

        /// <summary>Berechnet den ggT mit dem Euklidischen Algorithmus rekursiv.</summary>
        static int GgtRekursiv(int a, int b)
        {
            // Abbruchbedingung: wenn b 0 ist, ist a der ggT
            if (b == 0)
            {
                return a;
            }

            // die Methode ruft sich selbst mit (b, Rest von a durch b) auf
            return GgtRekursiv(b, a % b);
        }

        /// <summary>Berechnet den ggT mit dem Euklidischen Algorithmus in einer Schleife.</summary>
        static int GgtSchleife(int a, int b)
        {
            // gleiche Rechnung wie oben, aber statt Selbstaufruf werden a und b in der Schleife getauscht
            while (b != 0)
            {
                int rest = a % b;
                a = b;
                b = rest;
            }
            return a;
        }
    }
}
