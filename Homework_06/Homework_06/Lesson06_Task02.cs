using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Homework.Utility;
using System.IO;
using System.Xml.Linq;

namespace Homework_06
{
    
    public class Lesson06_Task02
    {
        private static CalculateMinimum _calculator;
        private static GetFunction _getFunction = new GetFunction();
        private static List<Function> _functions = new List<Function>()
        {
            _getFunction.Sin, 
            _getFunction.Cos,
            _getFunction.Tan,
            _getFunction.Square,
            _getFunction.Log,
        };
        private static List<string> _functionsDescription = new List<string>()
        {
            "y = a * sin(x)" ,
            "y = a * cos(x)", 
            "y = tg(x)", 
            "y = x^2", 
            "y = ln(x)",
        };

        public static void RunTask02()
        {
            _calculator = new CalculateMinimum(_functions, _functionsDescription);
            ShowMenu();            
        }

        #region Task02 methods

        private static void ShowMenu()
        {
            while (true)
            {
                ShowCommands();
                HomeworkAssist.ParseInput("Please chose command: ", out int userCommand);
                if(userCommand == 0)
                {
                    return;
                }
                else if(userCommand == 3)
                {
                    LoadCalculations();
                    continue;
                }
                else if(userCommand < 0 || userCommand > 2)
                {
                    Console.WriteLine("Wrong user comand, Try again");
                    continue;
                }

                HomeworkAssist.ParseInput("Please input x minimum value: ", out double minX);
                HomeworkAssist.ParseInput("Please input x maximum value: ", out double maxX);
                if (minX >= maxX)
                {
                    Console.WriteLine("Wrong input, x minimum is greater or equal to x maximum");
                    continue;
                }

                ShowFunctions();
                HomeworkAssist.ParseInput("Please choose function: ", out int index);                
                if (index < 0 || index >= _functions.Count)
                {
                    Console.WriteLine("Unknown function, please try again");
                    continue;
                }

                switch (userCommand)
                {                   
                    case 1:
                        _calculator.PrintOutMinimum(minX, maxX, index);
                        break;
                    case 2:
                        SaveCalculations(minX, maxX, index);
                        break;                    
                    default:
                        break;
                }
            }
        }

        private static void LoadCalculations()
        {
            HomeworkAssist.ParseInput("Please type calculated results to load: ", out string name);
            _calculator.LoadCalculations(name);
        }

        private static void SaveCalculations(double minX, double maxX, int index)
        {
            HomeworkAssist.ParseInput("Please save calculated results as: ", out string name);
            _calculator.PrintOutMinimum(minX, maxX, index);
            _calculator.SaveCalculations(name);
            Console.WriteLine("...Results saved...");
        }

        private static void ShowCommands()
        {
            Console.WriteLine("Type '0' to exit");
            Console.WriteLine("Type '1' to calculate function minimum in given range");
            Console.WriteLine("Type '2' to calculate function minimum and save results");
            Console.WriteLine("Type '3' to load previously saved calculation");
        }

        private static void ShowFunctions()
        {
            for (int i = 0; i < _functionsDescription.Count; i++)
                Console.WriteLine($"Type '{i}' to calculate {_functionsDescription[i]}");
        }       
    }

    public class GetFunction
    {
        public double Sin(double a, double x) => a * Math.Sin(x);
        public double Cos(double a, double x) => a * Math.Cos(x);
        public double Tan(double a, double x) => a * Math.Tan(x);
        public double Square(double a, double x) => a * Math.Pow(x, 2);
        public double Log(double a, double x) => a * Math.Log(x);
    }

    #endregion

    #region class CalculateMinimum

    public class CalculateMinimum
    {
        private const double STEP = 0.01;
        private const double A = 1;
        private Dictionary<double, double> _values;
        private List<Function> _functions;
        private List<string> _functionDiscriptions;
        private StringBuilder _results;
        private double _minX, _maxX;  
        private double _currentMinX, _currentMinY;
        private int _currentIndex;
        

        public CalculateMinimum(List<Function> functionsList, List<string> functionsDiscriptions)
        {
            _functions = new List<Function>(functionsList);
            _functionDiscriptions = new List<string>(functionsDiscriptions);
            _values = new Dictionary<double, double>();
            _results = new StringBuilder();
        }

        public void PrintOutMinimum(double minX, double maxX, int functionIndex)
        {
            _values.Clear();
            _results.Clear();

            _minX = minX;
            _maxX = maxX;
            _currentIndex = functionIndex;

            CalculateFunction();            
            GetFunctionMinimum();
            PrintOutResult();
        }

        private void GetFunctionMinimum()
        {
            _currentMinY = _values.Values.Min();
            _currentMinX = _values.FirstOrDefault(pair => pair.Value == _currentMinY).Key;
        }

        private void PrintOutResult()
        {
            _results.AppendLine($"Function {_functionDiscriptions[_currentIndex]} was used for calculations");
            _results.AppendLine($"For x from {_minX:F2} to {_maxX:F2} minimum of function will be {_currentMinY:F2} with x = {_currentMinX:F2}");
            Console.WriteLine(_results.ToString());
        }

        public void SaveCalculations(string name)
        {
            string fileName = $"{name}.txt";
            File.WriteAllText(fileName, _results.ToString());
        }

        public void LoadCalculations(string name)
        {
            string fileName = $"{name}.txt";
            if (File.Exists(fileName))
            {
                string results = File.ReadAllText(fileName);
                Console.WriteLine($"...Results saved as '{name}' loaded...");
                Console.WriteLine(results);
            }
            else
            {
                Console.WriteLine($"No calculation results saved as {name}");
            }
        }

        private void CalculateFunction()
        {
            if (_currentIndex >= _functions.Count)
            {
                Console.WriteLine("Function not found");
                return;
            }

            double x = _minX;
            while(x < _maxX)
            {
                _values.Add(x, _functions[_currentIndex](A, x));
                x += STEP;
            }
        }
    }    

    #endregion
}
