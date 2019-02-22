using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.CalcLib
{
    /// <summary>
    /// 
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Calculation method
        /// </summary>
        /// <param name="operand1">The first operand</param>
        /// <param name="operand2">The second operand</param>
        /// <param name="operation">Operation enum</param>
        /// <returns>This is a result</returns>
        public float Calc(float operand1, float operand2, OperationEnum operation)
        {
            float result;

            switch (operation)
            {
                case OperationEnum.Sum:
                    result = operand1 + operand2;
                    break;
                case OperationEnum.Minus:
                    result = operand1 - operand2;
                    break;
                case OperationEnum.Mult:
                    result = operand1 * operand2;
                    break;
                case OperationEnum.Div:
                    result = operand1 / operand2;
                    break;
                default:
                    throw new ArgumentException("Argument is not correct");
            }

            return result;
        }
    }
}
