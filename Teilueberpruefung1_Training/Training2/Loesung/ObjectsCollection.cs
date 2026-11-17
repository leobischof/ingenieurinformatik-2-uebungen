// Teilüberprüfung 1 – Training 2 – Lösung Task 2: Buchstaben zählen

namespace Teilueberpruefung_Training2
{
    public class ObjectsCollection
    {
        public static List<Book> GetBooksWithManyE(Book[] books) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Book> foundBooks = new List<Book>();

            for (int i = 0; i < books.Length; i++)
            {
                string titel = books[i].GetTitle();

                // jedes Zeichen im Titel anschauen und 'e' bzw. 'E' mitzählen
                int anzahlE = 0;
                for (int j = 0; j < titel.Length; j++)
                {
                    if (titel[j] == 'e' || titel[j] == 'E')
                    {
                        anzahlE++;
                    }
                }

                if (anzahlE >= 3)
                {
                    foundBooks.Add(books[i]);
                }
            }

            return foundBooks; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
