# Non-decimal-Fraction-library
Library for work with non-decimal fractions.
Link to NuGet package: https://www.nuget.org/packages/Non-decimalFractionHelper/
For using current library you should add reference to your project and add '**using Fractions;**' string (in case if you working with C#).

Examples of using:
```
            Fraction fr = new Fraction(5,7);
            Fraction fr2 = new Fraction(15, 27);
            Fraction frAnswer = FractionCalculation.AddFractions(fr, fr2);
            
            Fraction fr3 = new Fraction("-13/76");
            Fraction fr4 = new Fraction("17/24");
            Fraction frAnswer2 = FractionCalculation.DivideFractions(fr3, fr4, false);
            Console.WriteLine(frAnswer.ConvertFractionToString());
            Console.WriteLine(frAnswer2.ConvertFractionToMixedNumber());
```
![image](https://user-images.githubusercontent.com/71972963/175810660-2116988f-caac-4e9d-b698-1c7568409336.png)

***Notice:***
1) Class Fraction contains 3 constructors. For creating new fraction: put numerator and denominator as integer numbers, or put string with '/', as at example. If you put no any data, fraction '1/1' will bew created.
2) If fraction denominator equals zero - **DivideByZeroException** will be thrown.
3) If fraction numerator equals zero - fraction denominator will be converted to '1' - fraction still exists.
4) Converting fraction to mixed number doesn't change fraction - it converting copied data.
5) If you dont want to simplify fraction result after operation, put *false* as third parameter at calculations.
