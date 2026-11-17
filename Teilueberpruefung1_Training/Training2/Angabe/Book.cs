namespace Teilueberpruefung_Training2
{
    public class Book
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        private string _title;
        private string _author;
        private string _isbn;
        private int _pages;

        public Book(string title, string author, string isbn, int pages)
        {
            _title = title;
            _author = author;
            _isbn = isbn;
            _pages = pages;
        }

        public override string ToString()
        {
            return $"\"{_title}\" von {_author}";
        }

        public string GetTitle() { return _title; }

        public string GetAuthor() { return _author; }

        public string GetIsbn() { return _isbn; }

        public int GetPages() { return _pages; }
    }
}
