namespace Teilueberpruefung_Training3
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Hier können Sie die Methoden testen

            // Task 1
            int[,] numbersArray = { {    6,  12,  28 },
                                    {    1, 496, 100 },
                                    { 8128,  30,   0 } };

            List<int> perfectNumbers = TwoDimensionalArray.GetPerfectNumbers(numbersArray);

            Console.WriteLine($"Found perfect numbers: {string.Join(", ", perfectNumbers)}");
            Console.WriteLine("Expected:              6, 28, 496, 8128");

            // Task 2
            Employee[] employeesArray = { new Employee("Anna", "Huber", "anna.huber@tugraz.at", 3200.0),          // gültig
                                          new Employee("Max", "Maier", "max.maier.tugraz.at", 2900.0),            // kein '@'
                                          new Employee("Lisa", "Gruber", "lisa@@gruber.at", 3500.0),              // zwei '@'
                                          new Employee("Paul", "Berger", "paul@localhost", 4100.0),               // kein '.' nach dem '@'
                                          new Employee("Eva", "Wolf", "eva.wolf@student.tugraz.at", 1800.0) };    // gültig
            List<Employee> validEmployees = ObjectsCollection.GetEmployeesWithValidEmail(employeesArray);

            Console.WriteLine($"Found employees with valid e-mail: {string.Join(", ", validEmployees)}");
            Console.WriteLine("Expected:                          Anna Huber, Eva Wolf");
        }
    }
}
