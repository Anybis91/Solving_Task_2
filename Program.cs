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
            const string CommandUnbannedPlayer = "5";
            const string CommandExit = "7";

            bool isWork = true;
            PlayerDatebase datebase = new PlayerDatebase();
            Console.WriteLine("Главное меню");

            while (isWork)
            {
                string userAnswer;
                Console.WriteLine($"Выберите пункт меню:\n{CommandShowListPlayers} - просмотреть список игроков.\n{CommandAddPlayer} - добавить игрока." +
                $"\n{CommandDeletePlayer} - удалить игрока.\n{CommandBannedPlayer} - забанить игрока.\n{CommandUnbannedPlayer} - разбанить игрока." +
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

                    case CommandUnbannedPlayer:
                        datebase.UnbannedPlayer();
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

    class PlayerDatebase
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
            string namePlayer;
            string levelPlayer;
            bool isBannedPlayer=false;;
            int numberPlayer = Player.AddCountIds(); 
            Console.WriteLine("Введите имя игрока:");
            namePlayer = Console.ReadLine();
            Console.WriteLine("Введите уровень игрока:");
            levelPlayer = Console.ReadLine();

            _players.Add(new Player(numberPlayer,namePlayer,levelPlayer,isBannedPlayer));
        }

        public void DeletePlayer()
        {
            ShowPlayerList();

            if(_players.Count == 0)
            {
                Console.WriteLine("Нет игроков!");
            }
            else
            {
                if (TryGetPlayer(out Player player))
                {
                    _players.Remove(player);
                    Console.WriteLine("Игрок удален!");
                }
            }
        }

        public void BannedPlayer()
        {
            ShowPlayerList();

            if (_players.Count == 0)
            {
                Console.WriteLine("Нет игроков!");
            }
            else
            {
                if (TryGetPlayer(out Player player))
                {
                    player.Lock();
                    Console.WriteLine("Игрок заблокирован!");
                }
            }
        }

        public void UnbannedPlayer()
        {
            ShowPlayerList();

            if (_players.Count == 0)
            {
                Console.WriteLine("Нет игроков!");
            }
            else
            {
                if (TryGetPlayer(out Player player))
                {
                    player.Unlock();
                    Console.WriteLine("Игрок разблокирован!");
                }
            }   
        }

        private bool TryGetPlayer(out Player gamer)
        {
            Console.WriteLine($"Введите номер игрока");
            gamer = null;
            int number;
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out number))
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    if (number == _players[i].Id)
                    {
                        gamer = _players[i];
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Игрок не найден!");
                    }
                }
            }

            return false;
        }
    }

    class Player
    {
        private static int _idsCounter = 0;

        public Player(int id, string name, string level, bool isBanned)
        {
            Id = id;
            Name = name;
            LevelPlayer = level;
            IsBanned = isBanned;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LevelPlayer { get; private set; }
        public bool IsBanned { get; private set; }

        public void Lock()
        {
            IsBanned=true;
        }

        public void Unlock()
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

            Console.WriteLine($"Номер игрока - {Id}.\nИмя игрока - {Name}.\nУровень игрока - {LevelPlayer}.\nСостояние акаунта {statusPlayer}.\n");
        }

        public static int AddCountIds()
        {
            return ++_idsCounter;
        }
    }
}