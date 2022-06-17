using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_3___XUnit_och_Acceptanstestning
{
    public class CalculatorHistory
    {
        public double CHNum1 { get; set; }
        public string CHSymbol { get; set; }
        public double CHNum2 { get; set; }
        public double CHSum { get; set; }
        public DateTime CHDate { get; set; }

        public void PrintCalculatorHistory()
        {
            Console.Write($"{CHDate}   {CHNum1} {CHSymbol} {CHNum2} = {CHSum}");
            Console.WriteLine();
        }
    }
}
