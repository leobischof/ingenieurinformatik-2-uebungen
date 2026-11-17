namespace Teilueberpruefung_Training2
{
    public class ObjectsCollection
    {
        // Vervollständigen Sie den Code derart, dass im Titel ('string GetTitle()') jedes Buches ('Book') im übergebenen
        // 1D Array ('Book[] books') gezählt wird, wie oft der Buchstabe 'e' vorkommt - Groß- UND Kleinschreibung zählen
        // ('e' und 'E'). Kommt der Buchstabe MINDESTENS 3 Mal vor, soll die Instanz des Buches in die vorbereitete
        // Liste ('List<Book> foundBooks') hinzugefügt werden.

        // Hierfür muss das Konstrukt einer Schleife verwendet werden!

        // Tipp: ein 'string' ist ein Array von Zeichen ('char[]') - auf ein Zeichen greift man mit text[index] zu.
        // Achtung: ein einzelnes Zeichen ('char') steht in einfachen Anführungszeichen: 'e' - und nicht "e".

        // Übergabeparameter:   Book[] books            -> 1D Array von Objekten vom Typ 'Book'
        // Rückgabewert:        List<Book> foundBooks   -> Liste der Bücher, deren Titel mindestens 3 Mal 'e' bzw. 'E' enthält

        public static List<Book> GetBooksWithManyE(Book[] books) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Book> foundBooks = new List<Book>();

            // Code hier schreiben...


            return foundBooks; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
