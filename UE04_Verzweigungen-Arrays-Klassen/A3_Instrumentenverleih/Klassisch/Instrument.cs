// =====================================================================================
// UE04 – Aufgabe 3: Instrumentenverleih – Klasse Instrument (klassische Version)
// -------------------------------------------------------------------------------------
// Ziel:
//   Ein Instrument hat eine Seriennummer, einen Namen und einen Verleihstatus.
//   Name und Seriennummer kommen über den Konstruktor, der Status startet immer
//   mit ReadyToRent.
//
// Verwendete Konzepte:
//   - Klasse, private Felder, Konstruktor, Zugriffsmodifikatoren
//   - enum als Datentyp eines Feldes
//   - Methoden mit Rückgabewert (bool, string, Verleihstatus)
// =====================================================================================

namespace UE04.A3.Instrumentenverleih.Klassisch
{
    internal class Instrument
    {
        // ---------------------------------------------------------------------------
        // Felder – alle private (Kapselung). Begründung je Feld:
        // ---------------------------------------------------------------------------

        // SERIENNUMMER als string (nicht int) – bewusste Entscheidung:
        //   - Mit einer Seriennummer RECHNET man nicht (niemand addiert zwei
        //     Seriennummern). Sie ist ein Bezeichner, also Text, der zufällig aus
        //     Ziffern besteht – wie eine Telefonnummer oder Postleitzahl.
        //   - Führende Nullen ("007312") würden bei int verloren gehen (-> 7312).
        //   - Viele Hersteller verwenden Buchstaben ("YCL-4947") oder sehr lange
        //     Nummern, die nicht in einen int (max. 2.147.483.647) passen.
        // Lesen von außen: ja (für Ausgabe und Suche). Setzen: nein -> readonly,
        // eine Seriennummer ändert sich nie.
        private readonly string seriennummer;

        // NAME: Lesen von außen ja, Setzen nein (readonly) – ein Instrument wird
        // nicht umbenannt.
        private readonly string name;

        // STATUS: Lesen von außen ja. Setzen NICHT direkt, sondern nur über die
        // Methode Verleihen(). So kann die Klasse selbst sicherstellen, dass ein
        // bereits verliehenes Instrument nicht ein zweites Mal verliehen wird.
        // (Ein öffentlicher Setter würde jedem erlauben, die Regel zu umgehen.)
        // Nicht readonly, weil sich der Status im Laufe des Programms ändert.
        private Verleihstatus status;

        // ---------------------------------------------------------------------------
        // Konstruktor: setzt laut Angabe Name und Seriennummer aus den Parametern und
        // den Status auf ReadyToRent. Damit ist jedes neue Objekt sofort gültig.
        // (Ein Destruktor ~Instrument() ist nicht nötig – der Garbage Collector räumt
        // nicht mehr benötigte Objekte automatisch weg.)
        // ---------------------------------------------------------------------------
        public Instrument(string name, string seriennummer)
        {
            this.name = name;
            this.seriennummer = seriennummer;
            this.status = Verleihstatus.ReadyToRent;
        }

        // ---------------------------------------------------------------------------
        // Getter-Methoden: geben die privaten Werte nur zum LESEN heraus.
        // string und enum sind unveränderlich bzw. Werttypen – der Aufrufer bekommt
        // also keine Möglichkeit, das Objekt über den Rückgabewert zu verändern
        // (anders als bei einem Array, siehe Aufgabe 2).
        // ---------------------------------------------------------------------------
        public string GetSeriennummer()
        {
            return seriennummer;
        }

        public string GetName()
        {
            return name;
        }

        public Verleihstatus GetStatus()
        {
            return status;
        }

        /// <summary>Ist das Instrument gerade ausleihbar?</summary>
        public bool IstVerfuegbar()
        {
            return status == Verleihstatus.ReadyToRent;
        }

        /// <summary>
        /// Verleiht das Instrument, falls es verfügbar ist.
        /// </summary>
        /// <returns>
        /// true, wenn der Verleih geklappt hat; false, wenn es bereits verliehen war.
        /// </returns>
        public bool Verleihen()
        {
            // Guard-Clause: Bereits verliehen -> nichts ändern, Misserfolg melden.
            if (!IstVerfuegbar())
            {
                return false;
            }

            status = Verleihstatus.RentedOut;
            return true;
        }
    }
}
