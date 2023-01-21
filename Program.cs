using System;

namespace Task_Readint
{
    class Program
    {
        static void Main(string[] args)
        {
            Outputnumber();
        }

        static void Outputnumber()
        {
            bool isWork = true;
            int enterNumber; 
            Console.Write("Введите число для преобразования:");
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out enterNumber);

            while (isWork)
            {
                bool result =int.TryParse(userInput, out enterNumber);

                if (result==false)
                {
                    Console.WriteLine("Число не удалось преобразовать. Введите корректное число!");
                    userInput = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Ваше число преобразовано {enterNumber}.");
                    isWork = false;
                }
            }
        }
    }
}