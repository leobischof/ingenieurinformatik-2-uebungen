namespace Teilueberpruefung_Training8
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Hier können Sie die Methoden testen

            // Task 1
            int[,] numbersArray = { { 12, 18, 24 },
                                    { 7, 14, 21 },
                                    { 9, 4, 15 },
                                    { 100, 75, 50 } };

            List<int> rowGcds = TwoDimensionalArray.GetRowGcds(numbersArray);

            Console.WriteLine($"Found row gcds: {string.Join(", ", rowGcds)}");
            Console.WriteLine("Expected:       6, 7, 1, 25");

            // Task 2
            Animal[] animalsArray = { new Dog("Bello", 7),
                                      new Bird("Tweety", 2, true),          // kann fliegen
                                      new Spider("Thekla", 1),
                                      new Bird("Pingu", 5, false),          // Vogel, kann aber NICHT fliegen
                                      new Dog("Rex", 3),
                                      new Bird("Polly", 30, true),          // kann fliegen
                                      new Spider("Charlotte", 5) };         // gleich alt wie Pingu -> kommt nach Pingu
            List<Animal> groundAnimals = ObjectsCollection.GetGroundAnimalsSortedByAge(animalsArray);

            Console.WriteLine($"Found ground animals: {string.Join(", ", groundAnimals)}");
            Console.WriteLine("Expected:             Thekla (1), Rex (3), Pingu (5), Charlotte (5), Bello (7)");
        }
    }
}
