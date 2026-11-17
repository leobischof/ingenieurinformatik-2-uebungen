namespace Teilueberpruefung_Training1
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Hier können Sie die Methoden testen

            // Task 1
            int[,] numbersArray = { { 12,  35,  7 },
                                    { 44, 101, 58 },
                                    {  9,  20, 66 } };

            List<int> evenDigitSums = TwoDimensionalArray.GetNumbersWithEvenDigitSum(numbersArray);

            Console.WriteLine($"Found numbers with even digit sum: {string.Join(", ", evenDigitSums)}");
            Console.WriteLine("Expected:                         35, 44, 101, 20, 66");

            // Task 2
            Student[] studentsArray = { new Student("Anna Huber", "12320283", "Maschinenbau", 3),        // 8 Ziffern
                                        new Student("Max Maier", "1234567", "Bauingenieurwesen", 1),     // 7 Ziffern
                                        new Student("Lisa Gruber", "1232A283", "Elektrotechnik", 5),     // Buchstabe drin
                                        new Student("Paul Berger", "01234567", "Maschinenbau", 3),       // 8 Ziffern
                                        new Student("Eva Wolf", "123456789", "Wirtschaftsingenieur", 7) }; // 9 Ziffern
            List<Student> validStudents = ObjectsCollection.GetStudentsWithValidMatrikelnummer(studentsArray);

            Console.WriteLine($"Found valid students: {string.Join(", ", validStudents)}");
            Console.WriteLine("Expected:             Anna Huber (12320283), Paul Berger (01234567)");
        }
    }
}
