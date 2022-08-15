namespace Homework_04
{
    using Homework.Utility;
    using System;

    public class Lesson04_Task01
    {
        private static ArrayHandler _arrayHandler;
        private static int[] _array;

        public static void RunTask01()
        {
            RunTask01a();
            RunTask01b();
        }

        #region Task01a methods

        private static void RunTask01a()
        {
            HomeworkAssist.PrintTaskInfo("1a");
            _arrayHandler = CreateNewArray();
            DemonstrateArrayHandlerMethods();
        }

        private static void DemonstrateArrayHandlerMethods()
        {
            DemonstrateSum();
            DemonstrateInverse();
            DemonstrateMultiply();
            DemonstrateMaxCount();
        }

        private static void DemonstrateMaxCount()
        {
            Console.WriteLine($"Count of elements with maximum value of " +
                $"{_arrayHandler.Maximum} is {_arrayHandler.MaxCount}{Environment.NewLine}");
        }

        private static void DemonstrateMultiply()
        {
            HomeworkAssist.ParseInput("Please input array multiplier: ", out int multiplier);
            var newArrayHandler = new ArrayHandler(_arrayHandler.Multiply(multiplier));
            newArrayHandler.PrintOut();
        }

        private static void DemonstrateInverse()
        {
            Console.WriteLine("Array with inversed signs: ");
            var newArrayHandler = new ArrayHandler(_arrayHandler.InverseSigns());
            newArrayHandler.PrintOut();
        }

        private static void DemonstrateSum()
        {
            Console.WriteLine($"Sum of all array elements is {_arrayHandler.Sum}{Environment.NewLine}");
        }

        private static ArrayHandler CreateNewArray()
        {
            Console.WriteLine("Please create new array");
            HomeworkAssist.ParseInput("Input initial number of array: ", out int initialNumber);
            HomeworkAssist.ParseInput("Input loop step of array: ", out int loopStep);
            HomeworkAssist.ParseInput("Input number of array elements: ", out int numberOfElements);
            var newArrayHandler = new ArrayHandler(initialNumber, loopStep, numberOfElements);
            Console.WriteLine("Array was created: ");
            newArrayHandler.PrintOut();

            return newArrayHandler;
        }
        #endregion

        #region Task01b methods

        private static void RunTask01b()
        {
            HomeworkAssist.PrintTaskInfo("1b");
            _array = CreateArray();
            DemonstrateArrayAssistMethods();
        }

        private static void DemonstrateArrayAssistMethods()
        {
            DemonstrateArraySum();
            DemonstrateArrayInverse();
            DemonstrateArrayMultiply();
            DemonstrateArrayMaxCount();
            DemonstrateQuicksortArray();
        }

        private static void DemonstrateQuicksortArray()
        {
            Console.WriteLine("Array was quicksorted: ");
            ArrayAssist.Sort_Quicksort(_array, 0, _array.Length - 1);
            ArrayAssist.PrintOut(_array);
        }

        private static void DemonstrateArrayMaxCount()
        {
            Console.WriteLine($"Count of elements with maximum value of " +
                $"{ArrayAssist.GetMaximum(_array)} is {ArrayAssist.GetCountOfMaximumElements(_array)}" +
                $"{Environment.NewLine}");
        }

        private static void DemonstrateArrayMultiply()
        {
            HomeworkAssist.ParseInput("Please input array multiplier: ", out int multiplier);
            ArrayAssist.Multiply(_array, multiplier);
            ArrayAssist.PrintOut(_array);
        }

        private static void DemonstrateArrayInverse()
        {
            Console.WriteLine("Array with inversed signs: ");
            ArrayAssist.InverseSigns(_array);
            ArrayAssist.PrintOut(_array);
        }

        private static void DemonstrateArraySum()
        {
            Console.WriteLine($"Sum of all array elements is {ArrayAssist.GetSum(_array)}");
        }

        private static int[] CreateArray()
        {
            Console.WriteLine("Please create new random array");
            HomeworkAssist.ParseInput("Input range for array numbers: ", out int range);
            HomeworkAssist.ParseInput("Input number of array elements: ", out int numberOfElements);
            int[] array = ArrayAssist.GenerateArray(range, numberOfElements, false);  
            Console.WriteLine("Array was created: ");
            ArrayAssist.PrintOut(array);

            return array;
        }
        #endregion
    }

    #region class ArrayHandler
    public class ArrayHandler
    {
        private readonly int[] _array;

        public int Sum => GetSum();
        public int MaxCount => GetCountOfMaximumElements();
        public int Maximum => GetMaximum();

        public ArrayHandler(int initialNumber, int loopStep, int numberOfElements)
        {
            _array = new int[numberOfElements];
            GetNumbers(initialNumber, loopStep, numberOfElements);
        }

        public ArrayHandler(int[] array)
        {
            _array = array;
        }

        public int[] InverseSigns()
        {
            int[] inversedArray = new int[_array.Length];

            for (int i = 0; i < _array.Length; i++)
            {
                inversedArray[i] = -_array[i];
            }

            return inversedArray;
        }

        public int[] Multiply(int multipicator)
        {
            int[] multipliedArray = new int[_array.Length];

            for (int i = 0; i < _array.Length; i++)
            {
                multipliedArray[i] = _array[i] * multipicator;
            }

            return multipliedArray;
        }

        public void PrintOut()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.WriteLine($"#{i} -> {_array[i]}");
            }
            Console.WriteLine();
        }

        private int GetCountOfMaximumElements()
        {
            int count = 0;
            int maxNumber = GetMaximum();

            for (int i = 0; i < _array.Length; i++)
            {
                if (maxNumber == _array[i])
                    count++;
            }

            return count;
        }

        private int GetMaximum()
        {
            int maxNumber = _array[0];

            for (int i = 1; i < _array.Length; i++)
            {
                if (maxNumber < _array[i])
                    maxNumber = _array[i];
            }

            return maxNumber;
        }

        private void GetNumbers(int initialNumber, int loopStep, int numberOfElements)
        {
            for (int number = initialNumber, i = 0; i < numberOfElements; number += loopStep, i++)
            {
                _array[i] = number;
            }
        }

        private int GetSum()
        {
            int sum = 0;

            foreach (var number in _array)
            {
                sum += number;
            }

            return sum;
        }
    }
    #endregion

}
