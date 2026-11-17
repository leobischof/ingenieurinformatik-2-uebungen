namespace Teilueberpruefung_Training4
{
    public class Product
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        private string _name;
        private string _articleNumber;
        private double _price;
        private int _stock;

        public Product(string name, string articleNumber, double price, int stock)
        {
            _name = name;
            _articleNumber = articleNumber;
            _price = price;
            _stock = stock;
        }

        public override string ToString()
        {
            return $"{_name} [{_articleNumber}]";
        }

        public string GetName() { return _name; }

        public string GetArticleNumber() { return _articleNumber; }

        public double GetPrice() { return _price; }

        public int GetStock() { return _stock; }
    }
}
