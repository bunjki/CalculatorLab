using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine
    {
        
        public string Process(string str)
        {
            string result = string.Empty;
            Stack<string> RPNstack = new Stack<string>();
            string[]  parts = str.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                if (isOperator(parts[i]))
                {
                    string second = RPNstack.Pop().ToString();
                    string first = RPNstack.Pop().ToString();
                    result = calculate(parts[i], first, second);

                    RPNstack.Push(result);
                   
                }
                if (isNumber(parts[i]))
                {
                    RPNstack.Push(parts[i]);
                }
            }

            return RPNstack.Pop();
        }
    }
}
