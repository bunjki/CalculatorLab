using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            if (str == null || str == "") return "E"; // Set to null for Empty

            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            string firstOperand, secondOperand;

            int countNum = 0;
            int countOpera = 0;

            if (str[0] == '+') return "E"; // Opera return E
            
            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    rpnStack.Push(token);
                    countNum++;
                }
                else if (isOperator(token))
                {
                    
                    if (countNum == countOpera+1) return "E";
                    //FIXME, what if there is only one left in stack?
                    countOpera++;

                    secondOperand = rpnStack.Pop();
                    firstOperand = rpnStack.Pop();
                    result = calculate(token, firstOperand, secondOperand, 4);
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);

                } else if (token != "") return "E";
                                
            }

            if (countNum != countOpera + 1) return "E"; //Fix ช่องว่างปลาย Opera
            //FIXME, what if there is more than one, or zero, items in the stack?
            result = rpnStack.Pop();
            return result;
            }
    }
}
