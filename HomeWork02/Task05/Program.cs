using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    /* Губин Андрей Игоревич
     * 5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс
        массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
        б) Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса. */
    internal class Program
    {
        static double minNormalBMI = 18.5;
        static double maxNormalBMI = 24.9;
        static double mass;
        static double minNormalMass;
        static double maxNormalMass;
        static double height;
        static double bmi;

        static void Main(string[] args)
        {            
            Console.WriteLine("To calculate your BMI and provide some advice" +
                "\nPlease input following information");
            Console.Write("Your mass in kgs: ");
            string massInput = Console.ReadLine();
            Console.Write("Your height in mtrs: ");
            string heightInput = Console.ReadLine();

            mass = double.Parse(massInput);
            height = double.Parse(heightInput);
            bmi = mass / (height * height);
            minNormalMass = minNormalBMI * height * height;
            maxNormalMass = maxNormalBMI * height * height;

            BMIAdvice();
            Console.ReadLine();
        }

        static void BMIAdvice()
        {
            if(bmi >= 40)            
                PrintRecomendation("Obese (Class III)");
            else if(bmi >= 35)
                PrintRecomendation("Obese (Class II)");
            else if(bmi >= 30)
                PrintRecomendation("Obese (Class I)");
            else if (bmi >= 25)
                PrintRecomendation("Overweight (Pre-obese)");
            else if (bmi >= 18.5)
                PrintRecomendation("Normal");
            else if (bmi >= 17)
                PrintRecomendation("Underweight (Mild thinness)");
            else if (bmi >= 16)
                PrintRecomendation("Underweight (Moderate thinness)");
            else
                PrintRecomendation("Underweight (Severe thinness)");
        }

        static void PrintRecomendation(string category)
        {
            Console.WriteLine($"Your BMI is {bmi:F2}");
            Console.WriteLine($"You fall under {category} category");
            
            if (bmi > maxNormalBMI)
                Console.WriteLine($"You need to lose at least {mass - maxNormalMass:F1} kgs");
            else if (bmi < minNormalBMI)
                Console.WriteLine($"You need to gain at least {minNormalMass - mass:F1} kgs");
            else
                Console.WriteLine("You weight is perfectly fine!");
        }
    }
}
