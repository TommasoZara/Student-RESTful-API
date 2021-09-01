using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static API.Enums;

namespace API
{
    public class Game
    {
        public Game(User user = null)
        {
            Board = new string[3, 3];

            //--- Inizializzo la board con dei ? 
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                    Board[i, j] = Symbols[2];
            }

            Id = new Guid();
            CreatedDate = DateTime.Now;
            GameStatus = Status.Ready;

            //--- se mi passano l'utente lo vado aggiungere alla partita
            if (user != null)
                Players = new User[] { user };
        }

        public Status GameStatus { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string[,] Board { get; set; }
        public User Winner { get; set; }
        public ICollection<User> Players { get; set; }

        private static readonly string[] Symbols = { "X", "O", "?"};


        public string[,] Play(int x, int y, User player)
        {
            if (x < 0 || x > 2 || y < 0 || y > 2)
                return null;

            Board[x, y] = Symbols[Array.IndexOf(Players.ToArray(), player)] ?? Symbols[2];

            var usrWin = CheckForWin();
            if (usrWin != null)
                Winner = usrWin;

            return Board;
        }
        public User CheckForWin()
        {
            var _playerArr = Players?.ToArray();


            var d1 = 0;
            var d2 = 0;
            var dd1 = 0;
            var dd2 = 0;

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                var r1 = 0;
                var r2 = 0;
                var c1 = 0;
                var c2 = 0;


                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] == Symbols[0])
                        r1++;
                    if (Board[i, j] == Symbols[1])
                        r2++;

                    if (Board[j, i] == Symbols[0])
                        c1++;
                    if (Board[j, i] == Symbols[1])
                        c2++;

                    //--- prima diagonale 
                    if (i == j)
                    {
                        if (Board[i, j] == Symbols[0])
                            d1++;
                        if (Board[i, j] == Symbols[1])
                            d2++;
                    }

                    //--- seconda diagonale
                    if ((i + j) == (Board.GetLength(1) - 1))
                    {
                        if (Board[i, j] == Symbols[0])
                            dd1++;
                        if (Board[i, j] == Symbols[1])
                            dd2++;
                    }

                }

                if (r1 == 3 || c1 == 3)
                    return _playerArr[0];
                if (r2 == 3 || c2 == 3 )
                    return _playerArr[1];
            }

            if (d1 == 3 || dd1 == 3)
                return _playerArr[0];
            if (d2 == 3 || dd1 == 3)
                return _playerArr[1];

            return null;
        }
        
        //--- vado ad aggiornare lo stato della partita 
        public void ChangeStatus([Optional] Status status) => GameStatus = Enum.IsDefined(typeof(Status), status) ? status : GameStatus++;
        
        //--- boolen che tiene conto dei giocatori 
        public bool CanAddPlayer() => Players?.Count() <= 2;
        public override string ToString()
        {
            var str = "";
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                    str += string.Format("{0} ", Board[i, j]);
                str += Environment.NewLine;
            }
            return str;
        }

    }
}
