using System;

namespace Task_Readint
{
    class Program
    {
        static void Main(string[] args)
        {
            int enterNumber=ReadInt();
        }

        static int ReadInt()
        {
            bool isWork = true;
            Console.Write("Введите число для преобразования:");
            int enterNumber=0;

            while (isWork)
            {
                string userInput = Console.ReadLine();
                int.TryParse(userInput, out enterNumber);
                bool result = int.TryParse(userInput, out enterNumber);

                if (result == false)
                {
                    Console.WriteLine("Число не удалось преобразовать. Введите корректное число!");
                    userInput = Console.ReadLine();
                }
                else
                {
                    isWork = false;
                }
            }
           
            return enterNumber;
        }
    }
}