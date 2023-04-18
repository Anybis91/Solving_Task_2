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
            string namePlayer;
            string levelPlayer;
            bool isBannedPlayer=false;
            int maxIndexGamer = 100000;
            Random random = new Random();
            int numberPlayer=random.Next(0, maxIndexGamer); 
            Console.WriteLine("Введите имя игрока:");
            namePlayer = Console.ReadLine();
            Console.WriteLine("Введите уровень игрока:");
            levelPlayer = Console.ReadLine();

            _players.Add(new Player(numberPlayer,namePlayer,levelPlayer,isBannedPlayer));
        }

        public void DeletePlayer()
        {
            ShowPlayerList();

            if(TryGetPlayer(out Player player))
            {
                _players.Remove(player);
                Console.WriteLine("Игрок удален!");
            }
            else
            {
                Console.WriteLine("Игрок не найден!");
            }
        }

        public void BannedPlayer()
        {
            ShowPlayerList();

            if (TryGetPlayer(out Player player))
            {
                player.Lock();
                Console.WriteLine("Игрок заблокирован!");
            }
            else
            {
                Console.WriteLine("Игрок не найден!");
            }
        }

        public void UnBannedPlayer()
        {
            ShowPlayerList();

            if (TryGetPlayer(out Player player))
            {
                player.UnLock();
                Console.WriteLine("Игрок разблокирован!");
            }
            else
            {
                Console.WriteLine("Игрок не найден!");
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
                    if (number == _players[i].IdPlayer)
                    {
                        gamer = _players[i];
                        return true;
                    }
                }
            }

            return false;
        }
    }

    class Player
    {
        public Player(int id, string name, string level, bool isBanned)
        {
            IdPlayer = id;
            NamePlayer = name;
            LevelPlayer = level;
            IsBanned = isBanned;
        }

        public int IdPlayer { get; private set; }
        public string NamePlayer { get; private set; }
        public string LevelPlayer { get; private set; }
        public bool IsBanned { get; private set; }

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