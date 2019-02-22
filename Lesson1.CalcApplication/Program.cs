using Lesson1.CalcLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.CalcApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! This is Calculator! Please write your operation (for example: 1,1 + 2,1) and press ENTER");
            Console.WriteLine("Remember: you need to use WHITESPACE symbol and write ',' for real numbers (not '.')");

            // for example we get "1.1 + 2.1" 
            string inputString = Console.ReadLine();

            // after this operation we have array => ["1,1", "+", "2,1"]
            string[] query = inputString.Split(' ');

            // we know 
            // query[0] -> "1.1"
            // query[1] -> "+"
            // query[2] -> "2.1"
            // so we need to convert '0' and '2' elements to float
            // and '1' -> to Enum

            float operand1 = Convert.ToSingle(query[0]);
            float operand2 = Convert.ToSingle(query[2]);

            OperationEnum operation;

            switch (query[1])
            {
                case "+":
                    operation = OperationEnum.Sum;
                    break;
                case "-":
                    operation = OperationEnum.Minus;
                    break;
                case "/":
                    operation = OperationEnum.Div;
                    break;
                case "*":
                    operation = OperationEnum.Mult;
                    break;
                default:
                    throw new ArgumentException("Incorrect operation");

            }

            // so lets try to use our calc

            Calculator calculator = new Calculator();
            float result = calculator.Calc(operand1, operand2, operation);

            Console.WriteLine("Your answer is: {0}", result);
        }
    }
}
