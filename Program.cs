using System;

namespace Task_HR_accounting_advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            const string AddDossierCommand = "1";
            const string OutputDossiersCommand = "2";
            const string DeleteDossierCommand = "3";
            const string ExitCommand = "exit";

            bool isWork = true;
            string userSelection;
            Dictionary<string, string> fullNames=new Dictionary<string, string>();

            while (isWork)
            {
                Console.WriteLine($"Выберите пункт меню:\n{AddDossierCommand}. Добавить досье.\n{OutputDossiersCommand}. Вывести все досье.\n{DeleteDossierCommand}." +
                $" Удалить досье.\n{ExitCommand}. - Выход.");
                Console.WriteLine("\nВведите команду:");
                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case AddDossierCommand:
                        AddDossiers(fullNames);
                        break;

                    case OutputDossiersCommand:
                        OutDossiers(fullNames);
                        break;

                    case DeleteDossierCommand:
                        DeleteDossiers(fullNames);
                        break;

                    case ExitCommand:
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

            if (fullNames.ContainsKey(userInputPersonalDate))
            {
                Console.WriteLine("Данные уже существуют!");
            }
            else
            {
                fullNames.Add($"{userInputPersonalDate}", $"{userInputPosition}");
            }
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

            Console.WriteLine("Досье удалено.");
        }
    }
}
