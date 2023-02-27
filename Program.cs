using System;

namespace Task_HR_accounting_advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            const string AddDossier = "1";
            const string OutputDossiers = "2";
            const string DeleteDossier = "3";
            const string CommandExit = "exit";
            bool isWork = true;
            string userSelection;
            Dictionary<string, string> fullNames=new Dictionary<string, string>();

            while (isWork)
            {
                Console.WriteLine($"Выберите пункт меню:\n{AddDossier}. Добавить досье.\n{OutputDossiers}. Вывести все досье.\n{DeleteDossier}." +
                $" Удалить досье.\n{CommandExit}. - Выход.");
                Console.WriteLine("\nВведите команду:");
                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case AddDossier:
                        AddDossiers(fullNames);
                        break;
                    case OutputDossiers:
                        OutDossiers(fullNames);
                        break;
                    case DeleteDossier:
                        DeleteDossiers(fullNames);
                        break;
                    case CommandExit:
                        Console.WriteLine("Всего доброго!");
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Некоректный ввод.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddDossiers(Dictionary<string, string> fullNames)
        {
            Console.WriteLine("Введите ФИО сотрудника:");
            string userInputPersonalDate = Console.ReadLine();
            Console.WriteLine("Введите должность сотрудника:");
            string userInputPosition = Console.ReadLine();
            fullNames.Add($"{userInputPersonalDate}", $"{userInputPosition}");
        }

        static void OutDossiers(Dictionary<string, string> fullNames)
        {
            foreach (var item in fullNames)
            {
                Console.WriteLine($"{item.Key} - {item.Value}.");
            }
        }

        static void DeleteDossiers(Dictionary<string, string> fullNames)
        {
            Console.WriteLine("Введите ФИО сотрудника для удаления:");
            string userInputDeleteDossier = Console.ReadLine();
            fullNames.Remove(userInputDeleteDossier);
        }
    }
}
