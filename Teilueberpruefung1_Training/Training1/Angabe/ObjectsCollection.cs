namespace Teilueberpruefung_Training1
{
    public class ObjectsCollection
    {
        // Vervollständigen Sie den Code derart, dass die Matrikelnummer ('string GetMatrikelnummer()') der Studierenden
        // ('Student') im übergebenen 1D Array ('Student[] students') geprüft wird. Eine Matrikelnummer ist gültig, wenn sie
        // aus GENAU 8 Zeichen besteht UND jedes dieser Zeichen eine Ziffer ('0' bis '9') ist.
        // Ist die Matrikelnummer gültig, soll die Instanz in die vorbereitete Liste ('List<Student> validStudents') hinzugefügt werden.

        // Hierfür muss das Konstrukt einer Schleife verwendet werden!

        // Tipp 1: ein 'string' ist ein Array von Zeichen ('char[]') - auf ein Zeichen greift man mit text[index] zu.
        // Tipp 2: Zeichen kann man wie Zahlen vergleichen, z.B. (zeichen >= '0' && zeichen <= '9').

        // Übergabeparameter:   Student[] students              -> 1D Array von Objekten vom Typ 'Student'
        // Rückgabewert:        List<Student> validStudents     -> Liste der Studierenden mit gültiger Matrikelnummer

        public static List<Student> GetStudentsWithValidMatrikelnummer(Student[] students) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Student> validStudents = new List<Student>();

            // Code hier schreiben...


            return validStudents; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
