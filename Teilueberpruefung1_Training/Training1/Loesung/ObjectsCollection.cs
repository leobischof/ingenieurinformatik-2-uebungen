// Teilüberprüfung 1 – Training 1 – Lösung Task 2: Matrikelnummer prüfen

namespace Teilueberpruefung_Training1
{
    public class ObjectsCollection
    {
        public static List<Student> GetStudentsWithValidMatrikelnummer(Student[] students) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Student> validStudents = new List<Student>();

            for (int i = 0; i < students.Length; i++)
            {
                string nummer = students[i].GetMatrikelnummer();

                // falsche Länge -> gleich zum nächsten Studierenden
                if (nummer.Length != 8)
                {
                    continue;
                }

                // jedes Zeichen anschauen, ein einziges Nicht-Ziffer-Zeichen reicht für ungültig
                bool nurZiffern = true;
                for (int j = 0; j < nummer.Length; j++)
                {
                    if (nummer[j] < '0' || nummer[j] > '9')
                    {
                        nurZiffern = false;
                        break;
                    }
                }

                if (nurZiffern)
                {
                    validStudents.Add(students[i]);
                }
            }

            return validStudents; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
