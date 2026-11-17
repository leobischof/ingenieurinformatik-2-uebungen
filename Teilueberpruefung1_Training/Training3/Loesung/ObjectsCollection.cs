// Teilüberprüfung 1 – Training 3 – Lösung Task 2: E-Mail-Adresse prüfen

namespace Teilueberpruefung_Training3
{
    public class ObjectsCollection
    {
        public static List<Employee> GetEmployeesWithValidEmail(Employee[] employees) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Employee> validEmployees = new List<Employee>();

            for (int i = 0; i < employees.Length; i++)
            {
                string email = employees[i].GetEmail();

                int anzahlAt = 0;
                bool punktNachAt = false;

                for (int j = 0; j < email.Length; j++)
                {
                    if (email[j] == '@')
                    {
                        anzahlAt++;
                    }
                    // ein Punkt zählt nur, wenn vorher schon ein '@' war
                    else if (email[j] == '.' && anzahlAt > 0)
                    {
                        punktNachAt = true;
                    }
                }

                if (anzahlAt == 1 && punktNachAt)
                {
                    validEmployees.Add(employees[i]);
                }
            }

            return validEmployees; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
