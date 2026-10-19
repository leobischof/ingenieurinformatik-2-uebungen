// =====================================================================================
// UE04 – Aufgabe 2: Notenverwaltungssystem – Hauptprogramm (klassische Version)
// -------------------------------------------------------------------------------------
// Ziel:
//   Drei Objekte der Klasse Student anlegen, in einem Array speichern, das Array
//   durchlaufen und für jeden Studenten Name, Noten und Notendurchschnitt ausgeben.
//
// Verwendete Konzepte:
//   - Objekte instanziieren mit "new", Konstruktor-Parameter übergeben
//   - Array von Objekten (Student[]), foreach-Schleife
//   - Methoden eines Objekts aufrufen (GetName, GetNoten, BerechneNotendurchschnitt)
//   - string.Join zur Ausgabe eines Arrays
// =====================================================================================

namespace UE04.A2.Notenverwaltung.Klassisch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Umlaute/Sonderzeichen in der Windows-Konsole korrekt darstellen.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Ein Array vom Typ Student[] – "angemessen", weil wir genau drei
            // gleichartige Objekte haben, deren Anzahl von Anfang an feststeht.
            //
            // Jedes "new Student(...)" erzeugt ein neues OBJEKT nach dem Bauplan der
            // KLASSE Student und ruft dabei den Konstruktor auf.
            // "new int[] { 1, 4, 3 }" erzeugt das Noten-Array für diesen Studenten.
            Student[] studenten = new Student[]
            {
                new Student("Andreas", new int[] { 1, 4, 3 }),
                new Student("Paul", new int[] { 2, 2, 5 }),
                new Student("Laura", new int[] { 2, 1, 1 })
            };

            // Für die AUSGABE brauchen wir nur das Lesen – kein Index, kein Ändern
            // -> foreach ist hier die passende, am besten lesbare Schleife.
            // Zusätzlich merken wir uns, ob wir beim ersten Studenten sind, damit nur
            // ZWISCHEN den Blöcken eine Leerzeile steht.
            bool istErsterStudent = true;
            foreach (Student student in studenten)
            {
                if (!istErsterStudent)
                {
                    Console.WriteLine();
                }
                istErsterStudent = false;

                GibStudentAus(student);
            }
        }

        /// <summary>
        /// Gibt Name, Noten und Notendurchschnitt eines Studenten aus.
        /// Eigene Methode, damit die Schleife oben kurz und lesbar bleibt.
        /// </summary>
        static void GibStudentAus(Student student)
        {
            Console.WriteLine("Name: " + student.GetName());

            // string.Join(trenner, array) verbindet alle Elemente zu EINEM String und
            // setzt den Trenner nur ZWISCHEN die Elemente: 1 / 4 / 3
            Console.WriteLine("Noten: " + string.Join(" / ", student.GetNoten()));

            // Ein double wird ohne Formatangabe mit dem Dezimaltrennzeichen des
            // Systems ausgegeben (Deutsch: Komma -> 2,67). Ganze Werte erscheinen ohne
            // Nachkommastellen (3 statt 3,00) – genau wie im Beispiel der Angabe.
            Console.WriteLine("Notendurchschnitt: " + student.BerechneNotendurchschnitt());
        }
    }
}
