namespace Teilueberpruefung_Training4
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Hier können Sie die Methoden testen

            // Task 1 (Achtung: 3 Zeilen, aber 4 Spalten!)
            int[,] numbersArray = { { 1, 5, 2, 3 },
                                    { 4, 3, 8, 1 },
                                    { 9, 2, 1, 7 } };

            List<int> localMaxima = TwoDimensionalArray.GetLocalMaxima(numbersArray);

            Console.WriteLine($"Found local maxima: {string.Join(", ", localMaxima)}");
            Console.WriteLine("Expected:           5, 3, 8, 9, 7");

            // Task 2
            Product[] productsArray = { new Product("Schraube M6", "AB12345", 0.15, 500),   // gültig
                                        new Product("Mutter M6", "ab12345", 0.10, 300),     // Kleinbuchstaben
                                        new Product("Bohrer 8mm", "XY98765", 4.99, 0),      // nicht lagernd
                                        new Product("Hammer", "HM1234", 12.50, 20),         // nur 6 Zeichen
                                        new Product("Zange", "ZG5432A", 9.90, 15),          // Buchstabe am Ende
                                        new Product("Säge", "SG00001", 19.90, 3) };         // gültig
            List<Product> availableProducts = ObjectsCollection.GetAvailableProducts(productsArray);

            Console.WriteLine($"Found available products: {string.Join(", ", availableProducts)}");
            Console.WriteLine("Expected:                 Schraube M6 [AB12345], Säge [SG00001]");
        }
    }
}
