// UE06 – Aufgabe 1: Matrix-Analyser – Leo Bischof (12320283)

namespace UE06.A1.MatrixAnalyser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // damit Umlaute richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 6 x 6, also quadratisch: beide Diagonalen werden berechnet
            int[,] matrix1 = new int[,]
            {
                { 4, 17, 8, 23, 1, 12 },
                { 9, 30, 2, 14, 27, 5 },
                { 21, 6, 18, 11, 3, 25 },
                { 13, 28, 7, 19, 22, 10 },
                { 2, 15, 26, 9, 16, 8 },
                { 24, 3, 12, 20, 6, 29 }
            };

            // 6 x 7, also nicht quadratisch: die Diagonalen liefern 0
            int[,] matrix2 = new int[,]
            {
                { -5, 12, 33, 7, 18, 0, 41 },
                { 22, 9, -12, 15, 3, 27, 6 },
                { 14, 38, 11, -2, 25, 8, 19 },
                { 1, 16, 29, 44, 10, 21, -7 },
                { 35, 4, 13, 20, 31, 2, 17 },
                { 8, 26, 5, 37, -9, 14, 23 }
            };

            Console.WriteLine("=== Matrix 1 ===");
            MatrixAnalyser analyser1 = new MatrixAnalyser(matrix1);
            analyser1.Analysiere();

            Console.WriteLine("=== Matrix 2 ===");
            MatrixAnalyser analyser2 = new MatrixAnalyser(matrix2);
            analyser2.Analysiere();
        }
    }
}
