namespace Teilueberpruefung_Training7
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Hier können Sie die Methoden testen

            // Task 1
            int[,] numbersArray = { { 153, 12, 370, 99 },
                                    { 7, 100, 371, 10 },
                                    { 407, 1634, 200, -153 } };

            List<int> armstrongNumbers = TwoDimensionalArray.GetArmstrongNumbers(numbersArray);

            Console.WriteLine($"Found armstrong numbers: {string.Join(", ", armstrongNumbers)}");
            Console.WriteLine("Expected:                153, 370, 7, 371, 407, 1634");

            // Task 2
            Employee[] employeesArray = { new Employee("Anna", 3000),           // Gehalt 3000
                                          new Manager("Bernd", 4000, 1500),     // Gehalt 5500
                                          new Intern("Clara", 2000),            // Gehalt 1000
                                          new Employee("David", 3500),          // Gehalt 3500
                                          new Intern("Eva", 6000),              // Gehalt 3000 (Grundgehalt 6000!)
                                          new Manager("Fritz", 2500, 500) };    // Gehalt 3000
            // Durchschnitt: 19000 / 6 = 3166,67
            List<Employee> topEarners = ObjectsCollection.GetTopEarners(employeesArray);

            Console.WriteLine($"Found top earners: {string.Join(", ", topEarners)}");
            Console.WriteLine("Expected:          Bernd, David");
        }
    }
}
