// UE06 – Aufgabe 2: Stückliste – Leo Bischof (12320283)

using System.Globalization;

namespace UE06.A2.Stueckliste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // damit Umlaute richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Component> stueckliste = LeseStueckliste("Stueckliste.csv");
            Console.WriteLine("Stueckliste.csv erfolgreich importiert.");
            Console.WriteLine();

            Console.WriteLine("Unsortierte Liste:");
            GibListeAus(stueckliste);
            Console.WriteLine();

            // Sort() ruft intern immer wieder CompareTo aus der Klasse Component auf
            stueckliste.Sort();

            Console.WriteLine("Sortierte Liste:");
            GibListeAus(stueckliste);
        }

        /// <summary>Liest die CSV-Datei ein und gibt eine Liste mit allen Bauteilen zurück.</summary>
        static List<Component> LeseStueckliste(string pfad)
        {
            List<Component> liste = new List<Component>();
            string[] zeilen = File.ReadAllLines(pfad);

            // Die Masse steht mit Komma in der Datei (3,265), deshalb deutsche Zahlenschreibweise zum Umwandeln.
            CultureInfo deutsch = new CultureInfo("de-DE");

            // i beginnt bei 1, weil Zeile 0 die Kopfzeile ist (Pos;Name;Material;Masse [kg])
            for (int i = 1; i < zeilen.Length; i++)
            {
                // Getrennt wird mit ';' (nicht ',' wie in der Angabe), weil manche Namen selbst Kommas enthalten.
                string[] teile = zeilen[i].Split(';');

                int position = int.Parse(teile[0]);
                string name = teile[1];
                string material = teile[2];
                double masse = double.Parse(teile[3], deutsch);

                liste.Add(new Component(position, name, material, masse));
            }

            return liste;
        }

        /// <summary>Gibt jedes Bauteil der Liste in einer eigenen Zeile aus.</summary>
        static void GibListeAus(List<Component> liste)
        {
            foreach (Component bauteil in liste)
            {
                // WriteLine ruft automatisch unser überschriebenes ToString() auf
                Console.WriteLine(bauteil);
            }
        }
    }
}
