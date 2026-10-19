// ============================================================================
// Ingenieurinformatik II – Übungsblock #3, Aufgabe 4: Bestellsystem
// (KLASSISCHE Version)
// ----------------------------------------------------------------------------
// Ziel:
//   Bestellsystem für ein Take-Away-Restaurant mit drei Gerichten. Der Kunde wird
//   begrüßt, sieht die Speisekarte, wählt Gerichte (optional mit Sonderwunsch:
//   Preis +10 %, Zubereitungszeit +5 Minuten) und beendet die Bestellung mit 0.
//   Zum Schluss: Zusammenfassung mit allen bestellten Gerichten, Gesamtpreis und
//   der LÄNGSTEN Zubereitungszeit (nicht der Summe).
//
// Verwendete Konzepte:
//   - drei vereinfachte Klassen: Gericht, Bestellposition, Bestellung
//   - Objekte instanziieren (new), Attribute setzen/lesen (Punkt-Operator)
//   - Referenztypen: Warum das Gericht der Speisekarte nicht verändert werden darf
//   - Konstanten (const), Konversion string -> int mit int.TryParse
//   - Operatoren: arithmetisch (*, +), vergleichend (<, >, ==, !=),
//     logisch (||, !), zuweisend (=, +=)
//   - geschachtelte Verzweigung, switch
//   - while-Schleife (Bestellvorgang), do-while (Eingabeprüfung),
//     for-Schleife (Zusammenfassung über alle Positionen)
//
// "Weitere Gerichte bestellen oder abschließen?" wird – wie im Screenshot der
// Angabe – mit der Menüwahl kombiniert: 1–3 bestellt ein weiteres Gericht,
// 0 schließt die Bestellung ab.
// ============================================================================

namespace UE03.A4.Bestellsystem.Klassisch
{
    internal class Program
    {
        // Sonderwunsch-Regeln als Konstanten (jede Zahl steht genau einmal im Code).
        // 1.10 = 110 % des ursprünglichen Preises, also +10 %.
        const double SONDERWUNSCH_PREISFAKTOR = 1.10;
        const int SONDERWUNSCH_ZUSATZMINUTEN = 5;

        // Menüwahl, mit der die Bestellung abgeschlossen wird.
        const int AUSWAHL_ABSCHLIESSEN = 0;

        // Anzahl der Gerichte auf der Speisekarte = höchste gültige Menünummer.
        const int ANZAHL_GERICHTE = 3;

        const string MELDUNG_EINGABE_ENDE = "Keine weitere Eingabe vorhanden – die Bestellung wird abgebrochen.";

        static void Main(string[] args)
        {
            // UTF-8-Ausgabe: Ohne diese Zeile zeigt die Windows-Konsole (Codepage 850)
            // das €-Zeichen als "?" an – genau das sieht man im Screenshot der Angabe.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ----------------------------------------------------------------
            // Speisekarte: drei Gericht-Objekte anlegen
            // ----------------------------------------------------------------
            // Jedes "new Gericht()" erzeugt ein eigenes Objekt nach dem Bauplan der
            // Klasse Gericht; danach werden die öffentlichen Attribute gesetzt.
            // Im Quellcode ist der Punkt immer das Dezimaltrennzeichen (5.99).
            Gericht burger = new Gericht();
            burger.name = "Burger";
            burger.preis = 5.99;
            burger.zubereitungszeitMinuten = 15;

            Gericht pizza = new Gericht();
            pizza.name = "Pizza";
            pizza.preis = 7.99;
            pizza.zubereitungszeitMinuten = 20;

            Gericht salat = new Gericht();
            salat.name = "Salat";
            salat.preis = 4.49;
            salat.zubereitungszeitMinuten = 10;

            // ----------------------------------------------------------------
            // Begrüßung und Speisekarte
            // ----------------------------------------------------------------
            // {1:C} formatiert eine Zahl als Währung der eingestellten Ländereinstellung
            // (Culture): auf einem deutschen System "5,99 €", auf einem österreichischen
            // "€ 5,99". Wir erzwingen bewusst keine bestimmte Culture.
            Console.WriteLine("Willkommen im Restaurant! Hier ist unsere Speisekarte:");
            Console.WriteLine("1. {0} - {1:C}", burger.name, burger.preis);
            Console.WriteLine("2. {0} - {1:C}", pizza.name, pizza.preis);
            Console.WriteLine("3. {0} - {1:C}", salat.name, salat.preis);

            // Die Bestellung selbst ist ebenfalls ein Objekt (siehe Bestellung.cs).
            Bestellung bestellung = new Bestellung();

            // ----------------------------------------------------------------
            // Bestellvorgang
            // ----------------------------------------------------------------
            // while-Schleife mit "Flagge": Wir wissen vorher nicht, wie viele Gerichte
            // bestellt werden (darum keine for-Schleife). Die Schleife läuft, bis der
            // Kunde 0 wählt und damit "weiterBestellen" auf false setzt.
            bool weiterBestellen = true;
            while (weiterBestellen)
            {
                Console.WriteLine("Bitte wählen Sie ein Gericht (1-{0}) oder {1}, um die Bestellung abzuschließen:",
                    ANZAHL_GERICHTE, AUSWAHL_ABSCHLIESSEN);
                string? auswahlText = Console.ReadLine();

                // EOF-Schutz: ReadLine() liefert null, wenn die Eingabe zu Ende ist
                // (Strg+Z bzw. umgeleitete Datei/Pipe komplett gelesen). Danach kann
                // nie wieder eine Eingabe kommen -> sauber beenden statt Endlosschleife.
                if (auswahlText == null)
                {
                    Console.WriteLine(MELDUNG_EINGABE_ENDE);
                    return;
                }

                // Guard Clause: Ungültige Eingabe sofort behandeln und mit "continue"
                // direkt zur nächsten Schleifenrunde springen (= erneut fragen).
                // || (ODER) ist kurzschließend: Schlägt TryParse fehl, werden die
                // Bereichsprüfungen gar nicht mehr ausgewertet.
                int auswahl;
                if (!int.TryParse(auswahlText, out auswahl) || auswahl < AUSWAHL_ABSCHLIESSEN || auswahl > ANZAHL_GERICHTE)
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl von {0} bis {1} ein.",
                        AUSWAHL_ABSCHLIESSEN, ANZAHL_GERICHTE);
                    continue;
                }

                if (auswahl == AUSWAHL_ABSCHLIESSEN)
                {
                    weiterBestellen = false;
                }
                else
                {
                    // --------------------------------------------------------
                    // Gewähltes Gericht bestimmen (switch über die Menünummer)
                    // --------------------------------------------------------
                    // ACHTUNG Referenztyp: "gewaehltesGericht = burger" kopiert NICHT
                    // den Burger, sondern nur den VERWEIS darauf. Beide Variablen
                    // zeigen auf dasselbe Objekt der Speisekarte. Würden wir unten
                    // "gewaehltesGericht.preis = gewaehltesGericht.preis * 1.10" schreiben,
                    // wäre der Burger auf der Speisekarte dauerhaft teurer – beim
                    // zweiten Burger mit Sonderwunsch sogar +21 %! Darum wird
                    // gewaehltesGericht hier nur GELESEN.
                    Gericht gewaehltesGericht;
                    switch (auswahl)
                    {
                        case 1:
                            gewaehltesGericht = burger;
                            break;
                        case 2:
                            gewaehltesGericht = pizza;
                            break;
                        default: // nur noch 3 möglich, Bereich wurde oben geprüft
                            gewaehltesGericht = salat;
                            break;
                    }

                    // --------------------------------------------------------
                    // Sonderwunsch? (ja/nein) – so lange fragen, bis gültig
                    // --------------------------------------------------------
                    // do-while, weil mindestens einmal gefragt werden muss.
                    bool hatSonderwunsch = false;
                    bool antwortGueltig = false;
                    do
                    {
                        Console.WriteLine("Haben Sie einen Sonderwunsch? (ja/nein):");
                        string? antwort = Console.ReadLine();

                        if (antwort == null) // EOF-Schutz (siehe oben)
                        {
                            Console.WriteLine(MELDUNG_EINGABE_ENDE);
                            return;
                        }

                        // Trim + ToLower: " Ja " und "ja" werden gleich behandelt.
                        antwort = antwort.Trim().ToLower();

                        if (antwort == "ja" || antwort == "j")
                        {
                            hatSonderwunsch = true;
                            antwortGueltig = true;
                        }
                        else if (antwort == "nein" || antwort == "n")
                        {
                            hatSonderwunsch = false;
                            antwortGueltig = true;
                        }
                        else
                        {
                            Console.WriteLine("Bitte antworten Sie mit \"ja\" oder \"nein\".");
                        }
                    } while (!antwortGueltig);

                    // --------------------------------------------------------
                    // Neue Bestellposition anlegen – mit KOPIERTEN Werten
                    // --------------------------------------------------------
                    // name, preis und zubereitungszeitMinuten sind string/double/int.
                    // double und int sind WERTTYPEN: Die Zuweisung kopiert den Wert
                    // selbst. Ändern wir danach position.preis, bleibt
                    // gewaehltesGericht.preis (= Speisekarte) unverändert.
                    // (string ist zwar ein Referenztyp, aber unveränderlich – ein
                    // Text kann nachträglich nie "verändert" werden, daher ebenso sicher.)
                    Bestellposition position = new Bestellposition();
                    position.name = gewaehltesGericht.name;
                    position.preis = gewaehltesGericht.preis;
                    position.zubereitungszeitMinuten = gewaehltesGericht.zubereitungszeitMinuten;

                    // BEWUSST GESCHACHTELTE VERZWEIGUNG (Lernziel): Der Sonderwunsch-
                    // Text wird nur abgefragt, wenn der Kunde überhaupt einen
                    // Sonderwunsch hat – diese if-Anweisung liegt im else-Zweig von
                    // "auswahl == AUSWAHL_ABSCHLIESSEN" (äußere Verzweigung).
                    if (hatSonderwunsch)
                    {
                        string? sonderwunschText;
                        // do-while: so lange fragen, bis der Text nicht leer ist.
                        do
                        {
                            Console.WriteLine("Geben Sie Ihren Sonderwunsch ein:");
                            sonderwunschText = Console.ReadLine();

                            if (sonderwunschText == null) // EOF-Schutz (siehe oben)
                            {
                                Console.WriteLine(MELDUNG_EINGABE_ENDE);
                                return;
                            }

                            sonderwunschText = sonderwunschText.Trim();
                            if (sonderwunschText == "")
                            {
                                Console.WriteLine("Der Sonderwunsch darf nicht leer sein.");
                            }
                        } while (sonderwunschText == "");

                        position.sonderwunsch = sonderwunschText;
                        // Preis +10 % und Zeit +5 Minuten – NUR in der Bestellposition.
                        position.preis = position.preis * SONDERWUNSCH_PREISFAKTOR;
                        position.zubereitungszeitMinuten += SONDERWUNSCH_ZUSATZMINUTEN;
                    }

                    // Add hängt die Position hinten an die Liste der Bestellung an.
                    bestellung.positionen.Add(position);
                }
            }

            // ----------------------------------------------------------------
            // Bestellzusammenfassung
            // ----------------------------------------------------------------
            // Guard Clause: Wurde nichts bestellt, gibt es nichts zusammenzufassen.
            if (bestellung.positionen.Count == 0)
            {
                Console.WriteLine("Sie haben nichts bestellt. Auf Wiedersehen!");
                return;
            }

            Console.WriteLine("Ihre Bestellung:");

            // for-Schleife: Hier ist die Anzahl der Durchläufe BEKANNT
            // (positionen.Count) -> klassischer Fall für for mit Zählvariable i.
            // Dieselbe Schleife als while geschrieben (Lernziel "for -> while"):
            //     int i = 0;
            //     while (i < bestellung.positionen.Count) { ...; i++; }
            // for fasst Startwert, Bedingung und Schrittweite nur in einer Zeile zusammen.
            bestellung.gesamtpreis = 0;
            bestellung.maximaleZubereitungszeit = 0;
            for (int i = 0; i < bestellung.positionen.Count; i++)
            {
                Bestellposition aktuellePosition = bestellung.positionen[i];

                string zeile = aktuellePosition.name;
                if (aktuellePosition.sonderwunsch != "")
                {
                    zeile = zeile + " (" + aktuellePosition.sonderwunsch + ")";
                }
                // Komma zwischen den Gerichten wie im Screenshot – aber nicht nach
                // dem letzten Gericht (Index Count - 1).
                if (i < bestellung.positionen.Count - 1)
                {
                    zeile = zeile + ",";
                }
                Console.WriteLine(zeile);

                // Gesamtpreis: alle Preise aufsummieren (+= ist "gesamt = gesamt + preis").
                bestellung.gesamtpreis += aktuellePosition.preis;

                // Maximum suchen: Ist die aktuelle Zeit größer als das bisherige
                // Maximum, wird sie das neue Maximum. Die Zeiten werden NICHT addiert,
                // weil die Küche die Gerichte gleichzeitig zubereitet.
                if (aktuellePosition.zubereitungszeitMinuten > bestellung.maximaleZubereitungszeit)
                {
                    bestellung.maximaleZubereitungszeit = aktuellePosition.zubereitungszeitMinuten;
                }
            }

            Console.WriteLine();
            // {0:C} rundet für die Anzeige auf 2 Nachkommastellen (z. B. 11,079 -> 11,08 €).
            Console.WriteLine("Gesamtpreis: {0:C}", bestellung.gesamtpreis);
            Console.WriteLine("Maximale Zubereitungszeit: {0} Minuten", bestellung.maximaleZubereitungszeit);
        }
    }
}
