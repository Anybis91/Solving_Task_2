using System;

namespace Task_Readint
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            ConvertNumber(isWork);
        }

        static void ConvertNumber (bool isWork)
        {
            int enterNumber; 
            Console.Write("Введите число для преобразования:");
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out enterNumber);

            while (isWork)
            {
                int.TryParse(userInput, out enterNumber);

                if (enterNumber == 0)
                {
                    Console.WriteLine("Число не удалось преобразовать. Введите корректное число!");
                    Console.Write("Введите число для преобразования:");
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