namespace Teilueberpruefung_Training2
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Hier können Sie die Methoden testen

            // Task 1
            int[,] numbersArray = { {   121,   45,   7 },
                                    {  1331,   10,  88 },
                                    { 12321,  123, 909 } };

            List<int> palindromes = TwoDimensionalArray.GetPalindromeNumbers(numbersArray);

            Console.WriteLine($"Found palindrome numbers: {string.Join(", ", palindromes)}");
            Console.WriteLine("Expected:                 121, 1331, 88, 12321, 909");

            // Task 2
            Book[] booksArray = { new Book("Der Herr der Ringe", "J. R. R. Tolkien", "978-3-608-93828-9", 1200),     // 4x 'e'
                                  new Book("Faust", "Johann Wolfgang von Goethe", "978-3-15-000001-4", 160),        // 0x 'e'
                                  new Book("Die Verwandlung", "Franz Kafka", "978-3-15-009900-5", 96),              // 2x 'e'
                                  new Book("Emil und die Detektive", "Erich Kästner", "978-3-7915-3012-9", 176),    // 5x 'e' (ein großes 'E')
                                  new Book("Momo", "Michael Ende", "978-3-522-20210-4", 304) };                    // 0x 'e'
            List<Book> foundBooks = ObjectsCollection.GetBooksWithManyE(booksArray);

            Console.WriteLine($"Found books: {string.Join(", ", foundBooks)}");
            Console.WriteLine("Expected:    \"Der Herr der Ringe\" von J. R. R. Tolkien, \"Emil und die Detektive\" von Erich Kästner");
        }
    }
}
