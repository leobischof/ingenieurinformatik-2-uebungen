// ============================================================================
// Masseneinheit.cs – die drei unterstützten Einheiten als Aufzählungstyp (enum)
// ----------------------------------------------------------------------------
// Warum ein enum statt der Zahlen 1/2/3 oder der Texte "kg"/"lbs"/"st"?
//   Ein enum ist ein eigener Datentyp mit einer FESTEN Menge benannter Werte.
//   Der Compiler verhindert dadurch Tippfehler ("Klogramm") und unsinnige Werte,
//   und switch-Ausdrücke können prüfen, ob alle Fälle behandelt wurden.
//   Die zugewiesenen Zahlen (= 1, = 2, = 3) entsprechen gleichzeitig den
//   Menünummern, die der Benutzer eintippt – so gibt es diese Zuordnung nur hier.
//   Der Name eines Werts (z. B. "Kilogramm") wird außerdem direkt als
//   Anzeigetext im Menü verwendet.
//
// File-scoped namespace (C# 10+): "namespace X;" gilt für die ganze Datei und
// spart eine Einrückungsebene gegenüber "namespace X { ... }".
// ============================================================================

namespace UE03.A2.Massenkonverter.Modern;

public enum Masseneinheit
{
    Kilogramm = 1,
    Pfund = 2,
    Stone = 3,
}
