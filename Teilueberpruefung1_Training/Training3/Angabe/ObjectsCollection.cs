namespace Teilueberpruefung_Training3
{
    public class ObjectsCollection
    {
        // Vervollständigen Sie den Code derart, dass die E-Mail-Adresse ('string GetEmail()') der Mitarbeitenden
        // ('Employee') im übergebenen 1D Array ('Employee[] employees') geprüft wird. Eine E-Mail-Adresse ist gültig, wenn
        //   1) das Zeichen '@' GENAU EINMAL vorkommt UND
        //   2) NACH dem '@' mindestens ein Punkt '.' vorkommt.
        // Ist die E-Mail-Adresse gültig, soll die Instanz in die vorbereitete Liste ('List<Employee> validEmployees') hinzugefügt werden.

        // Hierfür muss das Konstrukt einer Schleife verwendet werden! (Methoden wie Contains, IndexOf oder Split sind NICHT erlaubt.)

        // Tipp 1: ein 'string' ist ein Array von Zeichen ('char[]') - auf ein Zeichen greift man mit text[index] zu.
        // Tipp 2: mit einer 'bool' Variable kann man sich merken, ob das '@' in der Schleife schon vorgekommen ist.

        // Übergabeparameter:   Employee[] employees            -> 1D Array von Objekten vom Typ 'Employee'
        // Rückgabewert:        List<Employee> validEmployees   -> Liste der Mitarbeitenden mit gültiger E-Mail-Adresse

        public static List<Employee> GetEmployeesWithValidEmail(Employee[] employees) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Employee> validEmployees = new List<Employee>();

            // Code hier schreiben...


            return validEmployees; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
