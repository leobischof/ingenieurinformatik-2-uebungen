// Teilüberprüfung 1 – Training 7 – Lösung Task 1: Armstrong-Zahlen mit Hilfsmethoden

namespace Teilueberpruefung_Training7
{
    public class TwoDimensionalArray
    {
        public static List<int> GetArmstrongNumbers(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> armstrongNumbers = new List<int>();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if (IsArmstrong(numbers[i, j]))
                    {
                        armstrongNumbers.Add(numbers[i, j]);
                    }
                }
            }

            return armstrongNumbers; // ACHTUNG! Return Statement muss unverändert bleiben!
        }

        /// <summary>Liefert true, wenn die Zahl eine Armstrong-Zahl ist.</summary>
        static bool IsArmstrong(int number)
        {
            // 0 und negative Zahlen zählen laut Angabe nicht
            if (number <= 0)
            {
                return false;
            }

            int stellen = CountDigits(number);
            int summe = 0;
            int rest = number;

            // Ziffer für Ziffer von hinten abarbeiten
            while (rest > 0)
            {
                int ziffer = rest % 10;
                summe = summe + Power(ziffer, stellen);
                rest = rest / 10;
            }

            return summe == number;
        }

        /// <summary>Zählt die Stellen einer positiven Zahl.</summary>
        static int CountDigits(int number)
        {
            int anzahl = 0;

            // bei jedem Durchlauf eine Ziffer abschneiden, bis nichts mehr übrig ist
            while (number > 0)
            {
                anzahl++;
                number = number / 10;
            }

            return anzahl;
        }

        /// <summary>Berechnet baseNumber hoch exponent.</summary>
        static int Power(int baseNumber, int exponent)
        {
            int ergebnis = 1;

            // exponent-mal mit der Basis multiplizieren
            for (int i = 0; i < exponent; i++)
            {
                ergebnis = ergebnis * baseNumber;
            }

            return ergebnis;
        }
    }
}
