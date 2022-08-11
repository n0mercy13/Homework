using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Utility
{
    public static class ArrayAssist
    {
        private static Random random = new Random();

        /// <summary>
        /// Inverse signs of all array elements
        /// </summary>
        /// <param name="array">Array to inverse signs</param>
        public static void InverseSigns(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = -array[i];
            }           
        }

        /// <summary>
        /// Multiply all array elements
        /// </summary>
        /// <param name="array">Array to multiply</param>
        /// <param name="multiplier">Multiplier</param>
        public static void Multiply(int[] array, int multiplier)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] * multiplier;
            }            
        }

        /// <summary>
        /// Print out all array elements in console
        /// </summary>
        /// <param name="array">Array to print out</param>
        public static void PrintOut(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"#{i} -> {array[i]}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Get count of all maximum elements in array
        /// </summary>
        /// <param name="array">Array</param>
        /// <returns>Count of maximum elements in array</returns>
        public static int GetCountOfMaximumElements(int[] array)
        {
            int count = 0;
            int maxNumber = GetMaximum(array);

            for (int i = 0; i < array.Length; i++)
            {
                if (maxNumber == array[i])
                    count++;
            }

            return count;
        }

        /// <summary>
        /// Get value of maximum element in array
        /// </summary>
        /// <param name="array">Array</param>
        /// <returns>Maximum value of array</returns>
        public static int GetMaximum(int[] array)
        {
            int maxNumber = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (maxNumber < array[i])
                    maxNumber = array[i];
            }

            return maxNumber;
        }

        /// <summary>
        /// Generate new array
        /// </summary>
        /// <param name="initialNumber">First number of array</param>
        /// <param name="loopStep">Incriment for each next array element</param>
        /// <param name="numberOfElements">Number of elements in new array</param>
        /// <returns>New array</returns>
        public static int[] GenerateArray(int initialNumber, int loopStep, int numberOfElements)
        {
            int[] newArray = new int[numberOfElements];

            for (int number = initialNumber, i = 0; i < newArray.Length; number += loopStep, i++)
            {
                newArray[i] = number;
            }

            return newArray;
        }

        /// <summary>
        /// Generate new array with random numbers
        /// </summary>
        /// <param name="rangeOfNumbers">Range for random numbers</param>
        /// <param name="numberOfElements">Number of elements in new array</param>
        /// <returns>New array</returns>
        public static int[] GenerateArray(int rangeOfNumbers, int numberOfElements)
        {
            int[] newArray = new int[numberOfElements];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = random.Next(-rangeOfNumbers, rangeOfNumbers);
            }

            return newArray;
        }

        /// <summary>
        /// Get sum of all array elements
        /// </summary>
        /// <param name="array">Array</param>
        /// <returns>Sum of all array elements</returns>
        public static int GetSum(int[] array)
        {
            int sum = 0;

            foreach (var number in array)
            {
                sum += number;
            }

            return sum;
        }

        #region Quicksort

        /// <summary>
        /// Sort array in ascending order
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="firstIndex">Index of first array element</param>
        /// <param name="lastIndex">Index of last array element</param>
        public static void Sort_Quicksort(int[] array, int firstIndex, int lastIndex)
        {
            if (firstIndex >= lastIndex)
                return;

            int pivot = Partition(array, firstIndex, lastIndex);
            Sort_Quicksort(array, firstIndex, pivot - 1);
            Sort_Quicksort(array, pivot + 1, lastIndex);
        }

        private static int Partition(int[] array, int firstIndex, int lastIndex)
        {
            int pivotIndex = lastIndex;
            int borderIndex = firstIndex;

            for (int i = firstIndex; i < lastIndex; i++)
            {
                if (array[i] <= array[pivotIndex])
                {
                    Swap(array, borderIndex, i);
                    borderIndex++;
                }
            }

            Swap(array, borderIndex, pivotIndex);

            return borderIndex;
        }

        private static void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        #endregion
    }
}
