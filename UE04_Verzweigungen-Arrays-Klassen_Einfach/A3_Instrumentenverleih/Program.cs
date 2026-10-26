// UE04 – Aufgabe 3: Instrumentenverleih – Leo Bischof (12320283)

namespace UE04.A3.Instrumentenverleih
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // damit Umlaute richtig angezeigt werden
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // jedes "new Instrument(...)" erzeugt ein Objekt, die Klasse ist nur der Bauplan
            Instrument[] instrumente = new Instrument[4];
            instrumente[0] = new Instrument(494773, "Yamaha YCL Klarinette");
            instrumente[1] = new Instrument(324385, "Olds Recording Trompete");
            instrumente[2] = new Instrument(654435, "Stradivari Geige");
            instrumente[3] = new Instrument(847473, "Pearl Roadshow Schlagzeug");

            Console.WriteLine("Willkommen beim Instrumentenverleih!");
            Console.WriteLine();
            ZeigeInventar(instrumente);

            // Endlosschleife, die wir mit break verlassen: wenn alles verliehen ist oder "e" eingegeben wird
            while (true)
            {
                if (SindAlleVerliehen(instrumente))
                {
                    Console.WriteLine("Alle Instrumente sind verliehen. Das Programm wird automatisch beendet.");
                    break;
                }

                string eingabe = Console.ReadLine();

                if (eingabe == "e")
                {
                    Console.WriteLine("Sie haben das Programm beendet.");
                    break;
                }

                // TryParse: klappt nur, wenn die Eingabe eine ganze Zahl ist
                int seriennummer;
                if (!int.TryParse(eingabe, out seriennummer))
                {
                    Console.WriteLine("Ungültige Eingabe: Bitte geben Sie eine Seriennummer (nur Ziffern) oder e ein.");
                    continue; // continue: den Rest überspringen und gleich die nächste Eingabe lesen
                }

                Instrument gefunden = SucheInstrument(instrumente, seriennummer);

                if (gefunden == null)
                {
                    Console.WriteLine($"Es gibt kein Instrument mit der Seriennummer {seriennummer}.");
                }
                else if (gefunden.GetStatus() == Verleihstatus.RentedOut)
                {
                    Console.WriteLine($"Das Instrument {gefunden.GetName()} ({seriennummer}) ist bereits verliehen. Bitte wählen Sie ein anderes Instrument.");
                }
                else
                {
                    gefunden.Ausleihen();
                    Console.WriteLine($"Sie haben {gefunden.GetName()} ausgeliehen. Vielen Dank.");
                    Console.WriteLine();
                    ZeigeInventar(instrumente);
                }
            }
        }

        /// <summary>Gibt die Tabelle mit Bezeichnung, Seriennummer und Status aus.</summary>
        static void ZeigeInventar(Instrument[] instrumente)
        {
            Console.WriteLine("Hier sind unsere verfügbaren Instrumente. Bitte geben Sie die Seriennummer des Instruments an, das Sie entlehnen möchten.");
            Console.WriteLine("Wenn Sie das Programm beenden möchten, drücken Sie e.");
            Console.WriteLine();

            // PadRight füllt den Text rechts mit Leerzeichen auf, so stehen die Spalten genau untereinander
            Console.WriteLine("Bezeichnung".PadRight(30) + "Seriennummer".PadRight(14) + "Status");
            Console.WriteLine();

            foreach (Instrument instrument in instrumente)
            {
                Console.WriteLine(instrument.GetName().PadRight(30) + "| " + instrument.GetSeriennummer().ToString().PadRight(12) + "| " + instrument.GetStatus());
            }

            Console.WriteLine();
        }

        /// <summary>Sucht das Instrument mit dieser Seriennummer, liefert null wenn es keines gibt.</summary>
        static Instrument SucheInstrument(Instrument[] instrumente, int seriennummer)
        {
            Instrument gefunden = null;

            foreach (Instrument instrument in instrumente)
            {
                if (instrument.GetSeriennummer() == seriennummer)
                {
                    gefunden = instrument;
                    break; // gefunden, weitersuchen ist nicht nötig
                }
            }

            return gefunden;
        }

        /// <summary>Prüft, ob kein Instrument mehr ausleihbar ist.</summary>
        static bool SindAlleVerliehen(Instrument[] instrumente)
        {
            foreach (Instrument instrument in instrumente)
            {
                if (instrument.GetStatus() == Verleihstatus.ReadyToRent)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
