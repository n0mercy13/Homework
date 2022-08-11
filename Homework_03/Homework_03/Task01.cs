using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Utility;

namespace Homework_03
{
    public class Task01 
    {
        private static Complex num1;
        private static Complex num2;
        private static ComplexNumber numClass1;
        private static ComplexNumber numClass2;

        public static void RunTask01()
        {
            RunTask01a();
            RunTask01bc();
        }       

        #region Task01a methods
        private static void RunTask01a()
        {
            Console.WriteLine($"Task #1a is running{Environment.NewLine}");
            num1 = DifineComplexNumber();
            num2 = DifineComplexNumber();
            Complex numSub = num2 - num1;
            Console.WriteLine($"({num2}) - ({num1}) = {numSub}{Environment.NewLine}");            
        }

        private static Complex DifineComplexNumber()
        {
            int re = HomeworkAssist.ParseInputInt("Please input 'Real number' of new complex number: ");
            int im = HomeworkAssist.ParseInputInt("Please input 'Imaginary number' of new complex number: ");
            var num = new Complex(re, im);
            Console.WriteLine($"You've created new complex number: {num}");
            return num;
        }
        #endregion

        #region Task01b & Task01c methods
        private static void RunTask01bc()
        {
            Console.WriteLine($"Task #1b and #1c is running{Environment.NewLine}");            
            numClass1 = DifineComplexNumberClass();
            numClass2 = DifineComplexNumberClass();
            ComplexNumCalculator(numClass1, numClass2);
        }

        private static void ComplexNumCalculator(ComplexNumber numClass1, ComplexNumber numClass2)
        {
            ComplexNumber result = new ComplexNumber();
            string input = string.Empty;
            while (true)
            {
                Console.Write("Type '+','-','*','/' to perform operation with complex numbers\n" +
                    "'N' for new complex numbers or '0' to quit:  ");
                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "+":
                        result = numClass2 + numClass1;
                        Console.WriteLine($"({numClass2}) + ({numClass1}) = {result}{Environment.NewLine}");
                        break;
                    case "-":
                        result = numClass2 - numClass1;
                        Console.WriteLine($"({numClass2}) - ({numClass1}) = {result}{Environment.NewLine}");
                        break;
                    case "*":
                        result = numClass2 * numClass1;
                        Console.WriteLine($"({numClass2}) * ({numClass1}) = {result}{Environment.NewLine}");
                        break;
                    case "/":
                        result = numClass2 / numClass1;
                        Console.WriteLine($"({numClass2}) / ({numClass1}) = {result}{Environment.NewLine}");
                        break;
                    case "n":
                        RunTask01bc();
                        break;
                    case "0":
                        return;
                    default:                        
                        Console.WriteLine($"Unknown operator: '{input}'. Please try again.{Environment.NewLine}");
                        break;
                }
            }
            
        }

        private static ComplexNumber DifineComplexNumberClass()
        {
            decimal re = (decimal)HomeworkAssist.ParseInputDouble("Please input 'Real number' of new complex number: ");
            decimal im = (decimal)HomeworkAssist.ParseInputDouble("Please input 'Imaginary number' of new complex number: ");
            var num = new ComplexNumber(re, im);
            Console.WriteLine($"You've created new complex number: {num}{Environment.NewLine}");
            return num;
        }
        #endregion
    }

    #region struct Complex
    public struct Complex
    {
        public int Re { get; private set; }
        public int Im { get; private set; }

        /// <summary>
        /// Creates new complex number
        /// </summary>
        /// <param name="re">Real number</param>
        /// <param name="im">Imagenary number</param>
        public Complex(int re, int im)
        {
            Re = re;
            Im = im;
        }

        public static Complex operator +(Complex num1, Complex num2)
        {
            int reSum = num1.Re + num2.Re;
            int imSum = num1.Im + num2.Im;
            return new Complex(reSum, imSum);
        }

        public static Complex operator -(Complex num1, Complex num2)
        {
            int reSub = num1.Re - num2.Re;
            int imSub = num1.Im - num2.Im;
            return new Complex(reSub, imSub);
        }

        public static Complex operator *(Complex num1, Complex num2)
        {
            int reMult = num1.Re * num2.Re - num1.Im * num2.Im;
            int imMult = num1.Im * num2.Re + num1.Re * num2.Im;
            return new Complex(reMult, imMult);
        }        

        /// <summary>
        /// Compare two complex numbers
        /// </summary>
        /// <param name="num">Complex number to compate with</param>
        /// <returns>True if numbers equal, otherwise False</returns>
        public bool Equals(Complex num)
        {
            return this.Re == num.Re && this.Im == num.Im;
        }

        public override string ToString()
        {
            if(Re >= 0 && Im >= 0)
                return $"{Re} + {Im}i";
            else if (Re < 0 && Im >= 0)
                return $"- {Re * -1} + {Im}i";
            else if (Re >= 0 && Im < 0)
                return $"{Re} - {Im * -1}i";
            else
                return $"- {Re * -1} - {Im * -1}i";
        }
    }
    #endregion

    #region class ComplexNumber
    public class ComplexNumber
    {
        private decimal _re;
        private decimal _im;

        /// <summary>
        /// Returns Real part of complex number
        /// </summary>
        public decimal Re 
        { 
            get => _re;
            private set => _re = value;
        }

        /// <summary>
        /// Returns Imagenary part of complex number
        /// </summary>
        public decimal Im 
        {
            get => _im;
            private set => _im = value;
        }

        /// <summary>
        /// Creates new complex number
        /// </summary>
        /// <param name="re">Real number</param>
        /// <param name="im">Imagenary number</param>
        public ComplexNumber(decimal re, decimal im)
        {
            this._re = re;
            this._im = im;
        }

        /// <summary>
        /// Creates new complex number there real and imagenary
        /// parts equals to 0
        /// </summary>
        public ComplexNumber()
        {
            this._re = 0;
            this._im = 0;
        }

        public static ComplexNumber operator + (ComplexNumber num1, ComplexNumber num2)
        {
            var reSum = num1.Re + num2.Re;
            var imSum = num1.Im + num2.Im;
            return new ComplexNumber(reSum, imSum);
        }

        public static ComplexNumber operator - (ComplexNumber num1, ComplexNumber num2)
        {
            var reSub = num1.Re - num2.Re;
            var imSub = num1.Im - num2.Im;
            return new ComplexNumber(reSub, imSub);
        }

        public static ComplexNumber operator * (ComplexNumber num1, ComplexNumber num2)
        {
            var reMult = num1.Re * num2.Re - num1.Im * num2.Im;
            var imMult = num1.Im * num2.Re + num1.Re * num2.Im;
            return new ComplexNumber(reMult, imMult);
        }

        public static ComplexNumber operator / (ComplexNumber num1, ComplexNumber num2)
        {
            var reDiv = (num1.Re * num2.Re + num1.Im * num2.Im) / (num2.Re * num2.Re + num2.Im * num2.Im);
            var imDiv = (num1.Im * num2.Re - num1.Re * num2.Im) / (num2.Re * num2.Re + num2.Im * num2.Im);
            return new ComplexNumber(reDiv, imDiv);
        }

        /// <summary>
        /// Compare two complex numbers
        /// </summary>
        /// <param name="num">Complex number to compate with</param>
        /// <returns>True if numbers equal, otherwise False</returns>
        public bool Equals(ComplexNumber num) => this.Re == num.Re 
                                              && this.Im == num.Im;        

        public override string ToString() => $"{(Re >= 0 ? string.Empty : "- ")}{Math.Abs(Re):F2} " +
                                             $"{(Im >= 0 ? "+" : "-")} {Math.Abs(Im):F2}i"; 
    }
    #endregion
}
