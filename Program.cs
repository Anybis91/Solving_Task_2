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
            const string CommandSearchPlayer = "6";
            const string CommandExit = "7";

            bool isWork = true;
            PlayerDateBase datebase = new PlayerDateBase();
            Console.WriteLine("Главное меню");

            while (isWork)
            {
                string userAnswer;
                Console.WriteLine($"Выберите пункт меню:\n{CommandShowListPlayers} - просмотреть список игроков.\n{CommandAddPlayer} - добавить игрока." +
                $"\n{CommandDeletePlayer} - удалить игрока.\n{CommandBannedPlayer} - забанить игрока.\n{CommandUnBannedPlayer} - разбанить игрока." +
                $"\n{CommandSearchPlayer} - найти игрока по номеру.\n{CommandExit} - выход из программмы.");
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
                    case CommandSearchPlayer:
                        datebase.SearchPlayer();
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
            int numberPlayer;
            string namePlayer;
            int levelPlayer;
            bool isBannedPlayer=false;

            Console.WriteLine("Введите номер игрока:");
            numberPlayer = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите имя игрока:");
            namePlayer = Console.ReadLine();
            Console.WriteLine("Введите уровень игрока:");
            levelPlayer = int.Parse(Console.ReadLine());

            _players.Add(new Player(numberPlayer,namePlayer,levelPlayer,isBannedPlayer));
        }

        public void DeletePlayer()
        {
            
        }

        public void BannedPlayer()
        {
            ShowPlayerList();

            Console.WriteLine("Введите номер игрока для бана:");
            int indexIdPlayer = int.Parse(Console.ReadLine());
            

            Console.WriteLine("Игрок заблокирован!");
        }

        public void UnBannedPlayer()
        {

        }

        public void SearchPlayer()
        {

        }
    }

    class Player
    {
        public int IdPlayer;
        public string NamePlayer;
        public int LevelPlayer;
        public bool IsBanned;

        public Player(int idPlayer, string namePlayer, int levelPlayer, bool isBanned)
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