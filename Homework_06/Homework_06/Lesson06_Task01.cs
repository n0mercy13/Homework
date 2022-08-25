using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_06
{
    public class Lesson06_Task01
    {
        private static Table _table = new Table();
        private static int _a = 5;
        private static int _initX = 0;

        public static void RunTask01()
        {
            Console.WriteLine("Table with results for calculating function a * x * x\n");
            _table.Function = FunctionSquare;
            _table.PrintOutCalculation(_a, _initX);
            Console.WriteLine("Table with results for calculating function a * sin(x)\n");
            _table.Function = FunctionSin;
            _table.PrintOutCalculation(_a, _initX);
        }

        private static double FunctionSquare(double a, double x) => a * Math.Pow(x, 2);

        private static double FunctionSin(double a, double x) => a * Math.Sin(x);       
    }

    public delegate double Function(double a, double x);

    #region class Table

    public class Table
    {
        private const double STEP = 0.3;        
        private const string TOP = "|---- X ----- Y ----|";
        private const string SEPARATION = "|-------------------|";
        private StringBuilder _table = new StringBuilder();

        public Function Function { private get; set; }
        public int TableLenght { get; set; } = 5;


        public void PrintOutCalculation(double a, double x)
        {
            if(Function == null)
            {
                Console.WriteLine("Please add function to calculate");
                return;
            }

            _table.Clear();
            _table.AppendLine(SEPARATION);
            _table.AppendLine(TOP);            

            while(x <= TableLenght)
            {
                AddLine(x, Function(a, x));
                x += STEP;
            }

            Console.WriteLine(_table.ToString());
        }

        private void AddLine(double x, double y)
        {
            _table.AppendLine(SEPARATION);
            _table.AppendLine($"| {x:000.000} | {y:000.000} |");
            _table.AppendLine(SEPARATION);
        }
    }

    #endregion
}
