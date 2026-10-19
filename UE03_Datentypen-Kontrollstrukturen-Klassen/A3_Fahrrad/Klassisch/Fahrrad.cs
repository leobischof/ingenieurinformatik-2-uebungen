// ============================================================================
// Fahrrad.cs – eine "vereinfachte" Klasse (KLASSISCHE Version)
// ----------------------------------------------------------------------------
// KLASSE vs. OBJEKT:
//   Eine Klasse ist ein BAUPLAN. Sie beschreibt, welche Daten (Attribute) ein
//   Fahrrad hat – aber sie IST noch kein Fahrrad. Erst mit "new Fahrrad()" wird
//   nach diesem Bauplan ein konkretes OBJEKT (eine "Instanz") im Speicher
//   angelegt. Von einer Klasse kann man beliebig viele Objekte erzeugen; jedes
//   Objekt hat seine EIGENEN Werte (Fahrrad 1: Cube, Fahrrad 2: Trek).
//
// Was heißt "vereinfacht"?
//   Die Klasse enthält NUR öffentliche (public) Attribute (= Felder) –
//   keinen selbst geschriebenen Konstruktor, keine Getter/Setter, keine Methoden.
//   Weil die Felder public sind, kann man sie von außen direkt lesen und
//   schreiben: meinRad.numberGears = 24;
//
// Komponenten dieser Klasse:
//   - Zugriffsmodifizierer: "internal" (Klasse nur in diesem Projekt sichtbar),
//     "public" (Feld überall sichtbar, wo die Klasse sichtbar ist)
//   - Klassenname: Fahrrad
//   - Attribute (Felder) mit Datentyp und Name: brand (string), numberGears (int)
//
// Namen: Die Angabe schreibt "brand" und "numberGears" exakt so vor (klein
// beginnend). In professionellem C# beginnen öffentliche Member üblicherweise mit
// einem Großbuchstaben (Brand, NumberGears) – hier halten wir uns an die Angabe.
// ============================================================================

namespace UE03.A3.Fahrrad.Klassisch
{
    internal class Fahrrad
    {
        // Marke des Fahrrads, z. B. "Cube".
        // Warum "= """ (leerer Text)? In diesem Projekt sind Nullable-Prüfungen
        // aktiv. Ein string-Feld ohne Startwert wäre automatisch null, obwohl der
        // Typ "string" (ohne ?) verspricht, nie null zu sein -> Compiler-Warnung.
        // Mit dem leeren Text als Startwert ist das Versprechen eingehalten.
        public string brand = "";

        // Anzahl der Gänge. int-Felder haben automatisch den Standardwert 0.
        public int numberGears;
    }
}
