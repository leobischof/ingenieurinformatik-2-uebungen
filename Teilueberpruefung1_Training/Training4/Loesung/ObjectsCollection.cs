// Teilüberprüfung 1 – Training 4 – Lösung Task 2: Artikelnummer und Lagerstand prüfen

namespace Teilueberpruefung_Training4
{
    public class ObjectsCollection
    {
        public static List<Product> GetAvailableProducts(Product[] products) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Product> availableProducts = new List<Product>();

            for (int i = 0; i < products.Length; i++)
            {
                string nummer = products[i].GetArticleNumber();

                // nicht lagernd oder falsche Länge -> gleich zum nächsten Produkt
                // (die Länge zuerst, sonst stürzt nummer[6] bei kurzen Nummern ab)
                if (products[i].GetStock() <= 0 || nummer.Length != 7)
                {
                    continue;
                }

                bool gueltig = true;
                for (int j = 0; j < nummer.Length; j++)
                {
                    char zeichen = nummer[j];

                    // Stelle 0 und 1 müssen Großbuchstaben sein, der Rest Ziffern
                    if (j < 2)
                    {
                        if (zeichen < 'A' || zeichen > 'Z')
                        {
                            gueltig = false;
                        }
                    }
                    else
                    {
                        if (zeichen < '0' || zeichen > '9')
                        {
                            gueltig = false;
                        }
                    }
                }

                if (gueltig)
                {
                    availableProducts.Add(products[i]);
                }
            }

            return availableProducts; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
