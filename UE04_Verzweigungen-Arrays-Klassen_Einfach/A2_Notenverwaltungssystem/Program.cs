// UE04 – Aufgabe 2: Notenverwaltungssystem – Leo Bischof (12320283)

namespace UE04.A2.Notenverwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // damit Umlaute und € richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // drei Objekte der Klasse Student, alle in einem Array gespeichert
            Student[] studenten = new Student[]
            {
                new Student("Andreas", new int[] { 1, 4, 3 }),
                new Student("Paul", new int[] { 2, 2, 5 }),
                new Student("Laura", new int[] { 2, 1, 1 })
            };

            // zwischen den Studenten soll eine Leerzeile stehen, davor nicht
            bool istErster = true;
            foreach (Student student in studenten)
            {
                if (!istErster)
                {
                    Console.WriteLine();
                }
                istErster = false;

                Console.WriteLine("Name: " + student.GetName());
                // string.Join setzt " / " nur zwischen die Noten: 1 / 4 / 3
                Console.WriteLine("Noten: " + string.Join(" / ", student.GetNoten()));
                Console.WriteLine("Notendurchschnitt: " + student.BerechneNotendurchschnitt());
            }
        }
    }
}
