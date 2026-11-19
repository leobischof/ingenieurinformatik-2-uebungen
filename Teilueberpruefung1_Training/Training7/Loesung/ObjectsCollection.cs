// Teilüberprüfung 1 – Training 7 – Lösung Task 2: überdurchschnittliches Gehalt (virtual/override mit base)

namespace Teilueberpruefung_Training7
{
    public class ObjectsCollection
    {
        public static List<Employee> GetTopEarners(Employee[] employees) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Employee> topEarners = new List<Employee>();

            // zuerst den Durchschnitt, sonst kann man noch nicht vergleichen
            double durchschnitt = GetAverageSalary(employees);

            for (int i = 0; i < employees.Length; i++)
            {
                // GetSalary() ist virtual: Manager und Intern rechnen mit ihrer override-Version
                if (employees[i].GetSalary() > durchschnitt)
                {
                    topEarners.Add(employees[i]);
                }
            }

            return topEarners; // ACHTUNG! Return Statement muss unverändert bleiben!
        }

        /// <summary>Berechnet das durchschnittliche Gehalt aller Mitarbeitenden.</summary>
        static double GetAverageSalary(Employee[] employees)
        {
            // leeres Array -> sonst würden wir durch 0 teilen
            if (employees.Length == 0)
            {
                return 0;
            }

            double summe = 0;
            for (int i = 0; i < employees.Length; i++)
            {
                summe = summe + employees[i].GetSalary();
            }

            return summe / employees.Length;
        }
    }
}
