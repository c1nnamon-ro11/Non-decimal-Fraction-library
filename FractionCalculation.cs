namespace Fractions
{
    // Class for calculation 
    // Supports four main operations
    public static class FractionCalculation
    {
        /// <summary>
        /// Calculates new common denominator of two fractals 
        /// </summary>
        /// <param name="denominatorOfFirstFraction">First fraction denominator</param>
        /// <param name="denominatorOfSecondFraction">Second fraction denominator</param>
        /// <returns>Common denominator of two fractals</returns>
        static long GetCommonDedominator(long denominatorOfFirstFraction, long denominatorOfSecondFraction)
        {
            long commonDedominator;
            long newDenominator;
            long multiplier = 2; // counter for newDenominator in case if denominators are not multiplies

            // Case if denominators of fractions are multiples
            if (denominatorOfFirstFraction > denominatorOfSecondFraction)
            {
                commonDedominator = denominatorOfFirstFraction;
                if (commonDedominator % denominatorOfSecondFraction == 0)
                {
                    return commonDedominator;
                }
            }
            else
            {
                commonDedominator = denominatorOfSecondFraction;
                if (commonDedominator % denominatorOfFirstFraction == 0)
                {
                    return commonDedominator;
                }
            }

            // Case if denominators of fractions are not multiples
            while (true)
            {
                newDenominator = commonDedominator * multiplier;
                if (newDenominator % denominatorOfFirstFraction == 0 && newDenominator % denominatorOfSecondFraction == 0)
                {
                    return newDenominator;
                }
                multiplier++;
            }
        }

        /// <summary>
        /// Adding of two fractions
        /// </summary>
        /// <param name="firstFraction">First fraction</param>
        /// <param name="secondFraction">Second fraction</param>
        /// <param name="simplifyResult">Flag for simplifiong result of improper fraction</param>
        /// <returns>Fraction as result of adding</returns>
        public static Fraction AddFractions(Fraction firstFraction, Fraction secondFraction, bool simplifyResult = false)
        {
            Fraction resultOfCalculation = new Fraction();
            resultOfCalculation.Denominator = GetCommonDedominator(firstFraction.Denominator, secondFraction.Denominator);
            resultOfCalculation.Numerator =
                firstFraction.Numerator * (resultOfCalculation.Denominator / firstFraction.Denominator) + secondFraction.Numerator * (resultOfCalculation.Denominator / secondFraction.Denominator);
            resultOfCalculation.FractionSimplification(simplifyResult);
            return resultOfCalculation;
        }

        /// <summary>
        /// Substraction of two fractions
        /// </summary>
        /// <param name="firstFraction">First fraction</param>
        /// <param name="secondFraction">Second fraction</param>
        /// <param name="simplifyResult">Flag for simplifiong result of improper fraction</param>
        /// <returns>Fraction as result of substraction</returns>
        public static Fraction SubstactFractions(Fraction firstFraction, Fraction secondFraction, bool simplifyResult = false)
        {
            Fraction resultOfCalculation = new Fraction();
            resultOfCalculation.Denominator = GetCommonDedominator(firstFraction.Denominator, secondFraction.Denominator);
            resultOfCalculation.Numerator =
                firstFraction.Numerator * (resultOfCalculation.Denominator / firstFraction.Denominator) - secondFraction.Numerator * (resultOfCalculation.Denominator / secondFraction.Denominator);
            resultOfCalculation.FractionSimplification(simplifyResult);
            return resultOfCalculation;
        }

        /// <summary>
        /// Multiplication of two fractions
        /// </summary>
        /// <param name="firstFraction">First fraction</param>
        /// <param name="secondFraction">Second fraction</param>
        /// <param name="simplifyResult">Flag for simplifiong result of improper fraction</param>
        /// <returns>Fraction as result of multiplication</returns>
        public static Fraction MultiplyFractions(Fraction firstFraction, Fraction secondFraction, bool simplifyResult = false)
        {
            Fraction resultOfCalculation = new Fraction();
            resultOfCalculation.Denominator = firstFraction.Denominator * secondFraction.Denominator;
            resultOfCalculation.Numerator = firstFraction.Numerator * secondFraction.Numerator;
            resultOfCalculation.FractionSimplification(simplifyResult);
            return resultOfCalculation;
        }

        /// <summary>
        /// Division of two fractions
        /// </summary>
        /// <param name="firstFraction">First fraction</param>
        /// <param name="secondFraction">Second fraction</param>
        /// <param name="simplifyResult">Flag for simplifiong result of improper fraction</param>
        /// <returns>Fraction as result of dividing</returns>
        public static Fraction DivideFractions(Fraction firstFraction, Fraction secondFraction, bool simplifyResult = false)
        {
            Fraction resultOfCalculation = new Fraction();
            resultOfCalculation.Denominator = firstFraction.Denominator * secondFraction.Numerator;
            resultOfCalculation.Numerator = firstFraction.Numerator * secondFraction.Denominator;
            resultOfCalculation.FractionSimplification(simplifyResult);
            return resultOfCalculation;
        }
    }
}
