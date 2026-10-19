// ============================================================================
// Massenumrechnung.cs – Konstanten und Umrechnungslogik (eine Verantwortung)
// ----------------------------------------------------------------------------
// Die Rechenlogik ist von der Konsolen-Ein-/Ausgabe (Program.cs) getrennt. Vorteil:
// Die Formeln lassen sich unabhängig testen und wiederverwenden (z. B. in einer
// GUI-App), ohne dass Console-Aufrufe "mitgeschleppt" werden.
//
// "static class": Von dieser Klasse werden keine Objekte erzeugt – sie ist nur ein
// Behälter für Konstanten und Funktionen, die keinen eigenen Zustand brauchen.
// ============================================================================

namespace UE03.A2.Massenkonverter.Modern;

public static class Massenumrechnung
{
    // ------------------------------------------------------------------------
    // Konstanten (const): zur Compile-Zeit festgelegt, zur Laufzeit unveränderlich.
    // Moderne C#-Konvention: PascalCase statt GROSSBUCHSTABEN.
    // ------------------------------------------------------------------------

    // Abkürzungen der Einheiten (string, weil "lbs" mehrere Zeichen hat).
    public const string AbkuerzungKilogramm = "kg";
    public const string AbkuerzungPfund = "lbs";
    public const string AbkuerzungStone = "st";

    // Umrechnungsfaktoren (double, weil Kommazahlen).
    public const double PfundProKilogramm = 2.20462; // 1 kg = 2,20462 lbs
    public const double KilogrammProStone = 6.35029; // 1 st = 6,35029 kg (= 14 lbs)

    // ------------------------------------------------------------------------
    // Extension-Methode: Durch "this Masseneinheit" kann man sie aufrufen, als wäre
    // sie eine Methode des enums selbst: Masseneinheit.Pfund.Abkuerzung() -> "lbs".
    //
    // Switch-Ausdruck (C# 8+): liefert direkt einen Wert, kein "case ...: break;".
    // Der Verwerfen-Fall "_" fängt Werte ab, die gar keine gültige Einheit sind
    // (ein enum kann technisch jede int-Zahl enthalten, z. B. (Masseneinheit)42).
    // ------------------------------------------------------------------------
    public static string Abkuerzung(this Masseneinheit einheit) => einheit switch
    {
        Masseneinheit.Kilogramm => AbkuerzungKilogramm,
        Masseneinheit.Pfund => AbkuerzungPfund,
        Masseneinheit.Stone => AbkuerzungStone,
        _ => throw new ArgumentOutOfRangeException(nameof(einheit), einheit, "Unbekannte Masseneinheit."),
    };

    /// <summary>
    /// Rechnet eine Masse von einer Einheit in eine andere um.
    /// Weg: immer über Kilogramm als Basiseinheit – so genügen zwei Faktoren statt
    /// sechs einzelner Formeln (kg↔lbs, kg↔st, lbs↔st).
    /// </summary>
    public static double Umrechnen(double masse, Masseneinheit von, Masseneinheit nach) =>
        AusKilogramm(InKilogramm(masse, von), nach);

    private static double InKilogramm(double masse, Masseneinheit von) => von switch
    {
        Masseneinheit.Kilogramm => masse,
        Masseneinheit.Pfund => masse / PfundProKilogramm,
        Masseneinheit.Stone => masse * KilogrammProStone,
        _ => throw new ArgumentOutOfRangeException(nameof(von), von, "Unbekannte Masseneinheit."),
    };

    private static double AusKilogramm(double kilogramm, Masseneinheit nach) => nach switch
    {
        Masseneinheit.Kilogramm => kilogramm,
        Masseneinheit.Pfund => kilogramm * PfundProKilogramm,
        Masseneinheit.Stone => kilogramm / KilogrammProStone,
        _ => throw new ArgumentOutOfRangeException(nameof(nach), nach, "Unbekannte Masseneinheit."),
    };
}
