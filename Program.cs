using System;

namespace Task_Readint
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput();
        }

        static void ReadInput()
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