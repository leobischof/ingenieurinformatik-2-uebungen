namespace Teilueberpruefung_Training5
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Hier können Sie die Methoden testen

            // Task 1
            int[,] numbersArray = { { 2, 4, 7, 9 },
                                    { 1, 11, 15, 13 },
                                    { 0, 17, 21, 23 } };

            List<int> primeNumbers = TwoDimensionalArray.GetPrimeNumbers(numbersArray);

            Console.WriteLine($"Found prime numbers: {string.Join(", ", primeNumbers)}");
            Console.WriteLine("Expected:            2, 7, 11, 13, 17, 23");

            // Task 2
            Vehicle[] vehiclesArray = { new Car("VW Golf", 210, 5),             // 4 Räder
                                        new Motorcycle("Vespa", 90),            // zu langsam
                                        new Motorcycle("KTM Duke", 200),        // schnelles Zweirad
                                        new Bicycle("Rennrad", 60, 22),         // zu langsam
                                        new Vehicle("Traktor", 40),             // 4 Räder
                                        new Motorcycle("Honda CB", 180),        // schnelles Zweirad
                                        new Car("Smart", 145, 2) };             // 4 Räder (nur 2 Sitze!)
            List<Vehicle> fastTwoWheelers = ObjectsCollection.GetFastTwoWheelers(vehiclesArray);

            Console.WriteLine($"Found fast two-wheelers: {string.Join(", ", fastTwoWheelers)}");
            Console.WriteLine("Expected:                KTM Duke, Honda CB");
        }
    }
}
