// =====================================================================================
// UE04 – Aufgabe 3: Instrumentenverleih – Enum Verleihstatus (klassische Version)
// -------------------------------------------------------------------------------------
// WAS IST EIN ENUM?
//   Ein enum (Aufzählungstyp) ist ein eigener Datentyp mit einer FESTEN Liste
//   benannter Werte. Intern ist jeder Wert eine ganze Zahl (ReadyToRent = 0,
//   RentedOut = 1), im Code schreibt man aber die sprechenden Namen.
//
// WARUM ENUM statt string oder bool?
//   - string ("verliehen", "Verliehen", "verlihen" ...): Tippfehler fallen erst zur
//     Laufzeit auf – oder nie. Beim enum meldet der Compiler sofort einen Fehler.
//   - bool (istVerliehen): reicht nur für genau ZWEI Zustände. Kommt später z. B.
//     "InReparatur" dazu, muss man alles umbauen. Ein enum erweitert man um eine Zeile.
//   - Der Typ dokumentiert sich selbst: Ein Parameter "Verleihstatus status" kann
//     nur einen dieser Werte annehmen, ein string könnte alles enthalten.
//   - ToString() liefert den Namen ("ReadyToRent") – praktisch für die Ausgabe.
//
// Eigene Datei, weil laut Angabe jede zusätzliche Klasse (und damit auch jeder
// eigene Typ) in einer eigenen Datei stehen soll.
// =====================================================================================

namespace UE04.A3.Instrumentenverleih.Klassisch
{
    internal enum Verleihstatus
    {
        // Das Instrument ist im Geschäft und kann ausgeliehen werden.
        ReadyToRent,

        // Das Instrument ist gerade an einen Kunden verliehen.
        RentedOut
    }
}
