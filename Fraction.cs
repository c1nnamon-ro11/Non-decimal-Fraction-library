using System;

namespace Fractions
{
    // Class for fraction representation
    public class Fraction
    {
        // Fraction properties
        public long Numerator { get; set; }      // Fraction numerator (signed)
        public long Denominator { get; set; }    // Fraction denominator (signed)

        // Fraction constructors
        /// <summary>
        /// Fraction constructor by default
        /// Equals 1 (1/1)
        /// </summary>
        public Fraction()
        {
            Numerator = 1;
            Denominator = 1;
        }

        /// <summary>
        /// Fraction constructor with numerator and denominator as parameter
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <exception cref="DivideByZeroException"></exception>
        public Fraction(long numerator, long denominator)
        {
            InitializeFraction(numerator, denominator);
        }

        /// <summary>
        /// Fraction constructor with string as parameter
        /// </summary>
        /// <param name="number"></param>
        /// <exception cref="DivideByZeroException">Throws if denominator equals zero</exception>
        public Fraction(string fractionString)
        {
            // Get numerator and denominator from string 
            var fractionParts = fractionString.Split('/');
            // In case if numerator or denominator not integer numbers will be thrown exception
            int numerator = int.Parse(fractionParts[0]);
            int denominator = int.Parse(fractionParts[1]);
            InitializeFraction(numerator, denominator);
        }

        /// <summary>
        /// Helping constructor method
        /// </summary>
        /// <param name="numerator">Fraction numerator</param>
        /// <param name="denominator">Fraction denominator</param>
        /// <exception cref="DivideByZeroException"></exception>
        private void InitializeFraction(long numerator, long denominator)
        {
            // Throw DivideByZeroExeption() if denominator of entered fraction equals zero (x/0)
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }
            // Change sigh for simplifing calculations
            if (denominator < 0)
            {
                denominator = -denominator;
                numerator = -numerator;
            }
            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Find the largest common divisor for fraction simplification
        /// </summary>
        /// <param name="numerator">Fraction numerator</param>
        /// <param name="denominator">Fraction denominator</param>
        /// <returns>Largest common divisor of 2 numbers</returns>
        private long LargestCommonDivisor(long numerator, long denominator)
        {
            while (numerator != denominator)
            {
                if (numerator == 0)
                    break;
                if (numerator > denominator)
                    numerator = numerator - denominator;
                else denominator = denominator - numerator;
            }
            return numerator;
        }

        /// <summary>
        /// Simplifying fraction in case if it have negative numerator and denominator or numerator greaten that denominator
        /// </summary>
        /// <param name="convertToMixedNumber">Flag for converting improper fraction to mixed number</param>
        public void FractionSimplification(bool convertToMixedNumber)
        {
            if (convertToMixedNumber)
            {
                long divisor = LargestCommonDivisor(Math.Abs(Numerator), Math.Abs(Denominator));
                Numerator = Numerator / divisor;
                Denominator = Denominator / divisor;
            }
            // Remove "-" if numerator and denominator negative      
            if (Numerator < 0 && Denominator < 0)
            {
                Numerator = -Numerator; Denominator = -Denominator;
            }
            // Case if fraction equal zero
            if (Numerator == 0)
            {
                Denominator = 1;
            }
        }

        /// <summary>
        /// Converting fraction to string representation as mixed number
        /// </summary>
        public string PrintMixedNumber()
        {
            // Save values for printing
            long numerator = Numerator;
            long denominator = Denominator;
            long integer = 0;
            string sign;

            // Calculate mixed number from improper fraction 
            if (numerator < 0)
            {
                sign = "-";
            }
            else
            {
                sign = "+";
            }
            numerator = Math.Abs(numerator);
            while (numerator >= denominator)
            {
                integer++;
                numerator = numerator - denominator;
            }
            // Create string as mixed number
            if (integer == 0 && numerator == 0)
            {
                return "0";
            }
            if (integer == 0)
            {
                return $"{sign}{numerator}/{denominator}";
            }
            if (numerator == 0)
            {
                return sign + integer;
            }
            return $"{sign}{integer} {numerator}/{denominator}";
        }

        /// <summary>
        /// Converting fraction to string representation
        /// </summary>
        /// <returns>Fraction as string</returns>
        public string ConvertFractionToString()
        {
            if (Numerator == 0)
            {
                return "0";
            }
            return $"{Numerator}/{Denominator}";
        }
    }
}
