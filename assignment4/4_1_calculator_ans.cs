using System;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an expression (ex. 2 + 3): ");
            string input = Console.ReadLine();

            try
            {
                Parser parser = new Parser();
                (double num1, string op, double num2) = parser.Parse(input);

                Calculator calculator = new Calculator();
                double result = calculator.Calculate(num1, op, num2);

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Parser class to parse the input
    public class Parser
    {
        public (double, string, double) Parse(string input)
        {
            string[] parts = input.Split(' ');

            if (parts.Length != 3)
            {
                throw new FormatException("Input must be in the format: number operator number");
            }

            double num1 = Convert.ToDouble(parts[0]);
            string op = parts[1];
            double num2 = Convert.ToDouble(parts[2]);

            return (num1, op, num2);
        }
    }

    // Calculator class to perform operations
    public class Calculator
    {
        public double Calculate(double n1, string opr, double n2)
        {
            if(opr == "+")
                return n1 + n2;
            else if(opr == "-")
                return n1 - n2;
            else if(opr == "*")
                return n1 * n2;
            else if(opr == "/")
                return n1 / n2;
            else if(opr == "**")
                return Math.Pow(n1, n2);
            else if(opr == "G")
                return GCD(n1, n2);
            else if(opr == "L")
                return LCM(n1, n2);
            else if(opr == "%")
                return n1 % n2;
            else
                throw new FormatException("Wrong operator!");
        }
        public static double GCD(double n1, double n2)
        {
            while(n2 != 0)
            {
                double temp = n2;
                n2 = n1 % n2;
                n1 = temp;
            }
            return n1;
        }
        public static double LCM(double n1, double n2)
        {
            return n1 * n2 / GCD(n1, n2);
        }
    }
}

/* example output

Enter an expression (ex. 2 + 3):
>> 4 * 3
Result: 12

*/


/* example output (CHALLANGE)

Enter an expression (ex. 2 + 3):
>> 4 ** 3
Result: 64

Enter an expression (ex. 2 + 3):
>> 5 ** -2
Result: 0.04

Enter an expression (ex. 2 + 3):
>> 12 G 15
Result: 3

Enter an expression (ex. 2 + 3):
>> 12 L 15
Result: 60

Enter an expression (ex. 2 + 3):
>> 12 % 5
Result: 2

*/