namespace Teilueberpruefung_Training4
{
    public class ObjectsCollection
    {
        // Vervollständigen Sie den Code derart, dass alle Produkte ('Product') im übergebenen 1D Array ('Product[] products')
        // gesucht werden, die eine gültige Artikelnummer haben UND lagernd sind.

        // Eine Artikelnummer ('string GetArticleNumber()') ist gültig, wenn
        //   1) sie aus GENAU 7 Zeichen besteht,
        //   2) die ersten 2 Zeichen GROSSBUCHSTABEN ('A' bis 'Z') sind und
        //   3) die restlichen 5 Zeichen Ziffern ('0' bis '9') sind.     Beispiel für eine gültige Nummer: "AB12345"
        // Ein Produkt ist lagernd, wenn der Lagerstand ('int GetStock()') größer als 0 ist.
        // Trifft beides zu, soll die Instanz des Produktes in die vorbereitete Liste ('List<Product> availableProducts') hinzugefügt werden.

        // Hierfür muss das Konstrukt einer Schleife verwendet werden!

        // Tipp 1: ein 'string' ist ein Array von Zeichen ('char[]') - auf ein Zeichen greift man mit text[index] zu.
        // Tipp 2: Zeichen kann man wie Zahlen vergleichen, z.B. (zeichen >= 'A' && zeichen <= 'Z').
        // Tipp 3: Die Länge muss ZUERST geprüft werden - sonst kann der Zugriff auf text[6] abstürzen!

        // Übergabeparameter:   Product[] products              -> 1D Array von Objekten vom Typ 'Product'
        // Rückgabewert:        List<Product> availableProducts -> Liste der lagernden Produkte mit gültiger Artikelnummer

        public static List<Product> GetAvailableProducts(Product[] products) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Product> availableProducts = new List<Product>();

            // Code hier schreiben...


            return availableProducts; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
