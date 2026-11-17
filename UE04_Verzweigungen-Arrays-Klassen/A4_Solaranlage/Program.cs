// UE04 – Aufgabe 4: Solaranlage – Leo Bischof (12320283)

namespace UE04.A4.Solaranlage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // damit Umlaute richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;



            // aus der Klasse wird ein Objekt: Standort und Nennleistung (400 W) kommen laut Angabe
            Solaranlage anlage = new Solaranlage("Dach Halle A", 400);

            // do-while: das Menü wird mindestens einmal gezeigt, geprüft wird erst danach
            int auswahl;
            do
            {
                Console.WriteLine("========== PV-Monitoring ==========");
                Console.WriteLine("1 ... Anlage anzeigen");
                Console.WriteLine("2 ... Gesamtleistung und Auslastung");
                Console.WriteLine("3 ... Leistung pro Reihe");
                Console.WriteLine("0 ... Programm beenden");
                Console.Write("Auswahl: ");

                // keine Zahl eingegeben -> -1, das landet im default-Fall
                if (!int.TryParse(Console.ReadLine(), out auswahl))
                {
                    auswahl = -1;
                }





                switch (auswahl)
                {
                    case 1:
                        Console.WriteLine();
                        anlage.MesswerteAnzeigen();
                        break;




                    case 2:
                        // Watt durch 1000.0 (Kommazahl) = kW; mit 1000 wäre es eine Ganzzahldivision
                        double gesamtleistungKw = anlage.BerechneGesamtleistung() / 1000.0;
                        Console.WriteLine("Gesamtleistung: " + gesamtleistungKw.ToString("0.00") + " kW");
                        Console.WriteLine("Auslastung:     " + anlage.BerechneGesamtauslastung().ToString("0.0") + " %");
                        break;




                    case 3:
                        int[] reihenleistung = anlage.BerechneReihenleistung();
                        for (int i = 0; i < reihenleistung.Length; i++)
                        {
                            Console.WriteLine($"Reihe {i + 1}: {reihenleistung[i].ToString().PadLeft(6)} W");
                        }

                        // schwächste Reihe suchen: wir nehmen die erste als kleinste an
                        // und tauschen, sobald eine noch kleinere kommt
                        int schwaechsteReihe = 0;
                        for (int i = 1; i < reihenleistung.Length; i++)
                        {
                            if (reihenleistung[i] < reihenleistung[schwaechsteReihe])
                            {
                                schwaechsteReihe = i;
                            }
                        }
                        Console.WriteLine($"Schwächste Reihe: {schwaechsteReihe + 1}");
                        break;




                    case 0:
                        Console.WriteLine("Programm beendet.");
                        break;




                    default:
                        Console.WriteLine("Ungültige Auswahl! Bitte 1, 2, 3 oder 0 eingeben.");
                        break;




                }

                Console.WriteLine();
            } while (auswahl != 0);
        }
    }
}
