namespace Teilueberpruefung_Training6
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Hier können Sie die Methoden testen

            // Task 1
            int[,] numbersArray = { { 4, 8, 13, 6 },
                                    { 21, 7, 34, 50 },
                                    { 1, 55, 100, 89 } };

            List<int> fibonacciNumbers = TwoDimensionalArray.GetFibonacciNumbers(numbersArray);

            Console.WriteLine($"Found fibonacci numbers: {string.Join(", ", fibonacciNumbers)}");
            Console.WriteLine("Expected:                8, 13, 21, 34, 1, 55, 89");

            // Task 2
            Shape[] shapesArray = { new Rectangle("Rechteck A", 2, 3),      // Fläche 6, Umfang 10
                                    new Circle("Kreis A", 1),               // Fläche 3,14, Umfang 6,28
                                    new Rectangle("Rechteck B", 5, 6),      // Fläche 30, Umfang 22
                                    new Rectangle("Quadrat", 4, 4),         // Fläche 16, Umfang 16 (gleich -> nicht größer!)
                                    new Circle("Kreis B", 3),               // Fläche 28,27, Umfang 18,85
                                    new Circle("Kreis C", 2.5) };           // Fläche 19,63, Umfang 15,71
            List<Shape> compactShapes = ObjectsCollection.GetCompactShapes(shapesArray);

            Console.WriteLine($"Found compact shapes: {string.Join(", ", compactShapes)}");
            Console.WriteLine("Expected:             Rechteck B, Kreis B, Kreis C");
        }
    }
}
