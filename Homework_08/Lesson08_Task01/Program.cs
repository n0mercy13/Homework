using System;
using System.Reflection;

namespace Lesson08_Task01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Properties of 'DateTime' object: ");
            PropertyInfo[] properties = GetPropertyInfo(new DateTime());
            PrintOutPropeties(properties);
        }

        private static PropertyInfo[] GetPropertyInfo(object item)
        {
            return item.GetType().GetProperties();
        }

        private static void PrintOutPropeties(PropertyInfo[] properties)
        {
            foreach (var item in properties)
            {
                Console.WriteLine(item);
            }
        }
    }
}
