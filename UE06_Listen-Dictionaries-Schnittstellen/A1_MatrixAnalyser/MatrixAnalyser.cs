// UE06 – Aufgabe 1: Matrix-Analyser – Leo Bischof (12320283)

namespace UE06.A1.MatrixAnalyser
{
    internal class MatrixAnalyser
    {
        // Alles wird im Konstruktor gesetzt und danach nicht mehr geändert, deshalb keine Getter/Setter.
        private int[,] matrix;
        private int anzahlZeilen;
        private int anzahlSpalten;

        public MatrixAnalyser(int[,] matrix)
        {
            this.matrix = matrix;
            // GetLength(0) = Anzahl Zeilen, GetLength(1) = Anzahl Spalten
            this.anzahlZeilen = matrix.GetLength(0);
            this.anzahlSpalten = matrix.GetLength(1);
        }

        /// <summary>Gibt die Matrix und alle Ergebnisse der Analyse auf der Konsole aus.</summary>
        public void Analysiere()
        {
            Console.WriteLine($"Matrix mit {anzahlZeilen} Zeilen und {anzahlSpalten} Spalten:");
            for (int zeile = 0; zeile < anzahlZeilen; zeile++)
            {
                for (int spalte = 0; spalte < anzahlSpalten; spalte++)
                {
                    Console.Write(matrix[zeile, spalte].ToString().PadLeft(5));
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Größter Wert:               {GetMaxValue()}");
            Console.WriteLine($"Kleinster Wert:             {GetMinValue()}");

            if (anzahlZeilen != anzahlSpalten)
            {
                Console.WriteLine("Die Matrix ist nicht quadratisch, darum sind die Diagonalen-Mittelwerte 0.");
            }
            Console.WriteLine($"Mittelwert Diagonale 1:     {GetAverageDiagonal1().ToString("0.00")}");
            Console.WriteLine($"Mittelwert Diagonale 2:     {GetAverageDiagonal2().ToString("0.00")}");
            Console.WriteLine();
        }

        /// <summary>Sucht den größten Wert, beginnt links oben und geht Zeile für Zeile nach rechts unten.</summary>
        private int GetMaxValue()
        {
            int max = matrix[0, 0];
            for (int zeile = 0; zeile < anzahlZeilen; zeile++)
            {
                for (int spalte = 0; spalte < anzahlSpalten; spalte++)
                {
                    if (matrix[zeile, spalte] > max)
                    {
                        max = matrix[zeile, spalte];
                    }
                }
            }
            return max;
        }

        /// <summary>Sucht den kleinsten Wert, beginnt rechts unten und geht rückwärts nach links oben.</summary>
        private int GetMinValue()
        {
            int min = matrix[anzahlZeilen - 1, anzahlSpalten - 1];
            for (int zeile = anzahlZeilen - 1; zeile >= 0; zeile--)
            {
                for (int spalte = anzahlSpalten - 1; spalte >= 0; spalte--)
                {
                    if (matrix[zeile, spalte] < min)
                    {
                        min = matrix[zeile, spalte];
                    }
                }
            }
            return min;
        }

        /// <summary>Mittelwert der Diagonale von links unten nach rechts oben (0, wenn nicht quadratisch).</summary>
        private double GetAverageDiagonal1()
        {
            if (anzahlZeilen != anzahlSpalten)
            {
                return 0;
            }

            int summe = 0;
            for (int i = 0; i < anzahlZeilen; i++)
            {
                // Zeile läuft von unten nach oben, Spalte von links nach rechts
                summe = summe + matrix[anzahlZeilen - 1 - i, i];
            }
            // (double) damit nicht ganzzahlig geteilt wird, sonst fällt die Kommastelle weg
            return (double)summe / anzahlZeilen;
        }

        /// <summary>Mittelwert der Diagonale von rechts oben nach links unten (0, wenn nicht quadratisch).</summary>
        private double GetAverageDiagonal2()
        {
            if (anzahlZeilen != anzahlSpalten)
            {
                return 0;
            }

            int summe = 0;
            for (int i = 0; i < anzahlZeilen; i++)
            {
                // Zeile läuft von oben nach unten, Spalte von rechts nach links
                summe = summe + matrix[i, anzahlSpalten - 1 - i];
            }
            return (double)summe / anzahlZeilen;
        }
    }
}
