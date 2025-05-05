using System;
using System.Globalization;

namespace Parsing

{
    class Program
    {

        static void Main(string[] args)
        {

            BasicIntParsing();
            CultureAwareParsing();


        }

        static void BasicIntParsing()
        {
            string numStr1 = "1";
            string numStr2 = "2.00";
            string numStr3 = "3,000";
            string numStr4 = "4,000.00";

            int targetNum;

            try
            {
                targetNum = int.Parse(numStr1);
                Console.WriteLine(targetNum);
                // to allow floating point num we need to use NumberStyles class using System.Globalization namespace

                targetNum = int.Parse(numStr2, NumberStyles.Float);
                Console.WriteLine(targetNum);

                targetNum = int.Parse(numStr3, NumberStyles.AllowThousands);
                Console.WriteLine(targetNum);

                targetNum = int.Parse(numStr4, NumberStyles.Float | NumberStyles.AllowThousands);
                Console.WriteLine(targetNum);


            }
            catch
            {
                Console.Write("Conversion failed");

            }

            // The TryParse function is similar but handles the exceptions for us
            bool succeeded = false;
            // out is a function parameter to return a value from the function call
            succeeded = Int32.TryParse(numStr1, out targetNum);
            if (succeeded)
            {
                Console.WriteLine(targetNum);
            }
        }

        static void CultureAwareParsing()
        {
            string[] values = { "1,304.16", "$1,456.78", "123,45 €", "1 304,16", "Ae9f" };

            // write a foreach loop that iterates through each string in the array
            // foreach (type variableName in arrayName) 
            CultureInfo? culture = null;

            foreach (string value in values)
            {
                culture = CultureInfo.CreateSpecificCulture("en-AU");

                try
                {
                    double number = Double.Parse(value, culture);
                    Console.WriteLine($"{culture.Name}: {value} --> {number}");
                }
                catch
                {
                    Console.WriteLine($"{culture.Name}: Unable to Parse {value}");
                    culture = CultureInfo.CreateSpecificCulture("fr-FR");

                    try
                    {
                        double number = Double.Parse(value, culture);

                        Console.WriteLine($"{culture.Name}: {value} --> {number}");


                    }
                    catch
                    {
                        Console.WriteLine($"{culture.Name}: Unable to Parse {value}");

                    }

                }

            }




        }









    }
}



// ref: https://www.linkedin.com/learning/learning-c-sharp-8581491/string-parsing?resume=false#
// ref : https://learn.microsoft.com/en-us/dotnet/standard/base-types/parsing-numeric


