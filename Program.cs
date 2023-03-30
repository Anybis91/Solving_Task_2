using System;

namespace Task_Player_database
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CommandShowListPlayers = "1";
            const string CommandAddPlayer = "2";
            const string CommandDeletePlayer = "3";
            const string CommandBannedPlayer = "4";
            const string CommandUnBannedPlayer = "5";
            const string CommandExit = "7";

            bool isWork = true;
            PlayerDateBase datebase = new PlayerDateBase();
            Console.WriteLine("Главное меню");

            while (isWork)
            {
                string userAnswer;
                Console.WriteLine($"Выберите пункт меню:\n{CommandShowListPlayers} - просмотреть список игроков.\n{CommandAddPlayer} - добавить игрока." +
                $"\n{CommandDeletePlayer} - удалить игрока.\n{CommandBannedPlayer} - забанить игрока.\n{CommandUnBannedPlayer} - разбанить игрока." +
                $"\n{CommandExit} - выход из программмы.");
                userAnswer = Console.ReadLine();
                Console.Clear();

                switch (userAnswer)
                {
                    case CommandShowListPlayers:
                        datebase.ShowPlayerList();
                        break;
                    case CommandAddPlayer:
                        datebase.AddPlayer();
                        break;
                    case CommandDeletePlayer:
                        datebase.DeletePlayer();
                        break;
                    case CommandBannedPlayer:
                        datebase.BannedPlayer();
                        break;
                    case CommandUnBannedPlayer:
                        datebase.UnBannedPlayer();
                        break;
                    case CommandExit:
                        Console.WriteLine("Пока!");
                        isWork = false;
                        break;

                }

                Console.ReadKey();
                Console.Clear();
            }

        }
    }
    //6:32
    class PlayerDateBase
    {
        private List<Player> _players = new List<Player>();

        public void ShowPlayerList()
        {
            if(_players.Count > 0)
            {
                for(int i = 0; i < _players.Count; i++)
                {
                    _players[i].ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("База игроков пуста!");
            }
        }

        public void AddPlayer()
        {
            string numberPlayer;
            string namePlayer;
            string levelPlayer;
            bool isBannedPlayer=false;

            Console.WriteLine("Введите номер игрока:");
            numberPlayer = GetNumber().ToString();
            Console.WriteLine("Введите имя игрока:");
            namePlayer = Console.ReadLine();
            Console.WriteLine("Введите уровень игрока:");
            levelPlayer = GetNumber().ToString();

            _players.Add(new Player(numberPlayer,namePlayer,levelPlayer,isBannedPlayer));
        }

        public void DeletePlayer()
        {
            ShowPlayerList();
            Console.WriteLine("Введите номер игрока для удаления:");
            int indexIdPlayer = FindIdPlayer();
            _players.RemoveAt(indexIdPlayer);
            Console.WriteLine("Игрок удален!");
        }

        public void BannedPlayer()
        {
            ShowPlayerList();

            Console.WriteLine("Введите номер игрока для бана:");
            int indexIdPlayer = FindIdPlayer();

            if (_players[indexIdPlayer].IsBanned == false)
            {
                _players[indexIdPlayer].Lock();
            }

            Console.WriteLine("Игрок заблокирован.");
        }

        public void UnBannedPlayer()
        {
            ShowPlayerList();

            Console.WriteLine("Введите номер игрока для разблокировки:");
            int indexIdPlayer = FindIdPlayer();

            if (_players[indexIdPlayer].IsBanned == true)
            {
                _players[indexIdPlayer].UnLock();
            }

            Console.WriteLine("Игрок разблокирован.");
        }

        private int FindIdPlayer()
        {
            bool isWork = true;
            int maxIndexGamer = 2147483647;
            int indexGamer = maxIndexGamer;

            while (isWork)
            {
                string userInput = GetNumber().ToString();

                bool isSuccess = _players.Exists(player => player.IdPlayer == userInput);

                if (isSuccess == true && indexGamer <= maxIndexGamer)
                {
                    isWork = false;
                    indexGamer = _players.FindIndex(player => player.IdPlayer== userInput);
                }
                else
                {
                    Console.WriteLine("Такого игрока в базе нет. Введите корректное значение.");
                }
            }

            return indexGamer;
        }

        private int GetNumber()
        {
            int resault = 0;
            bool isWork = true;

            while (isWork)
            {
                string userInputNumber = Console.ReadLine();
                bool isSuccess = int.TryParse(userInputNumber, out int resaultParse);

                if (resaultParse >= 0 && isSuccess == true)
                {
                    resault = resaultParse;
                    isWork = false;
                }
                else
                {
                    Console.WriteLine("Введите корректное значение!");
                }
            }

            return resault;
        }
    }

    class Player
    {
        public string IdPlayer { get; private set; }
        public string NamePlayer { get; private set; }
        public string LevelPlayer { get; private set; }
        public bool IsBanned { get; private set; }

        public Player(string idPlayer, string namePlayer, string levelPlayer, bool isBanned)
        {
            IdPlayer = idPlayer;
            NamePlayer = namePlayer;
            LevelPlayer = levelPlayer;
            IsBanned = isBanned;
        }

        public void Lock()
        {
            IsBanned=true;
        }

        public void UnLock()
        {
            IsBanned=false;
        }

        public void ShowInfo()
        {
            string statusPlayer = "";

            if (IsBanned == true)
            {
                statusPlayer = "Забанен";
            }
            else
            {
                statusPlayer = "Активен";
            }

            Console.WriteLine($"Номер игрока - {IdPlayer}.\nИмя игрока - {NamePlayer}.\nУровень игрока - {LevelPlayer}.\nСостояние акаунта {statusPlayer}.\n");
        }
    }
}