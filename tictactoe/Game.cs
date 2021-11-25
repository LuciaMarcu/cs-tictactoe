using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace tictactoe
{
    class Game
    {
        private int[,] winner_comb = { { 2, 5, 8 }, { 1, 4, 7 }, { 3, 6, 9 }, { 3, 5, 7 }, { 1, 5, 9 }, { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        private List<int> comp_picks = new List<int>();
        private List<int> human_picks = new List<int>();
        private List<int> possible = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        private string board = "\n_1_|_2_|_3_\n_4_|_5_|_6_\n_7_|_8_|_9_\n";
        private string not_allowed = "123456789";
        private List<int> same = new List<int>();


        //Displays an initial board with numbered cells.
        public void InitBoard()
        {
            Console.WriteLine("The cells are numbered from 1 to 9 as seen below: {0}Please tipe your name.", board);
        }

        //Asks for a cell number. If the number was already chosen by computer, it asks again. If ok removes it from possible list and
        //fills the board with the choise.
        private void AskHuman(Player p)
        {
            int pick = 0;
            bool resp = false;
            while (resp == false)
            {
                Console.WriteLine("{0} is your turn to choose a cell.", p.Name);
                pick = int.Parse(Console.ReadLine());
                resp = VerifyPick(pick);
            }
            possible.Remove(pick);
            FillBoard(pick, p.Mark);
        }


        //Checks if the number introduced by Player was already chosen by computer. If ok, adds the number to human_picks list.
        private bool VerifyPick(int pi)
        {
            if (comp_picks.Contains(pi))
            {
                Console.WriteLine("Computer choosed this cell before you. Type another cell.");
                return false;
            }
            else
            {
                Console.WriteLine("Your choice is {0}.", pi);
                human_picks.Add(pi);
                return true;
            }
        }

        //Picks a random number between 1 and 9 as computer choise, adds it to comp_picks list and removes it from possible list. After,
        //fills the board with the choise.
        private void CompChose(Player c)
        {

            Random r = new Random();
            int index = r.Next(1, possible.Count) - 1;
            int cp = possible[index];
            possible.RemoveAt(index);
            comp_picks.Add(cp);
            Console.WriteLine("Computer choice is {0}.", cp);
            FillBoard(cp, c.Mark);
        }

        //Receives the choised cell and mark of player and replaces the chosen number in the board with the mark.
        private void FillBoard(int pick, char mark)
        {
            string pk = Convert.ToString(pick);
            string mk = Convert.ToString(mark);
            board = board.Replace(pk, mk);
        }

        //Displays the modified board
        private void DisplayBoard()
        {
            Console.WriteLine("The modified board is {0}", board);
        }

        //Until the board is full or a winner is found, calls the methods CompChose, AskHuman, DisplayBoard, Compare.
        public void Play(Player p, Player c)
        {
            int i = 0;
            while (FullBoard() == false)
            {
                Thread.Sleep(3000);
                CompChose(c);
                DisplayBoard();
                while (i < 4)
                {
                    AskHuman(p);
                    i++;
                    break;
                }

                DisplayBoard();
                bool human_winner = Compare(human_picks);
                bool comp_winner = Compare(comp_picks);
                if (human_winner == true)
                {
                    Console.WriteLine("{0} is the winner. The game is over.", p.Name);
                    return;
                }
                else if (comp_winner == true)
                {
                    Console.WriteLine("{0} is the winner. The game is over.", c.Name);
                    return;
                }
                else continue;
            }

            Console.WriteLine("The board is full. Nobody winns.");
        }

        //It tells if the board is full by comparing the board string with not_allowed string. If one character from not_allowed exists in board,
        //it means the board is not full.
        private bool FullBoard()
        {
            foreach (char c in not_allowed)
            {
                if (board.Contains(c.ToString()))
                    return false;
            }

            return true;
        }

        //Compares the human picks or computer picks with winner combinations. If player picks contains all numbers from one winner combination
        //it return true, else return false.
        private bool Compare(List<int> picks)
        {
            for (int i = 0; i < winner_comb.GetLength(0); i++)
            {
                for (int j = 0; j < winner_comb.GetLength(1); j++)
                {
                    if (picks.Contains(winner_comb[i, j]))
                    {
                        same.Add(winner_comb[i, j]);

                        if (same.Count == 3)
                        {
                            return true;
                        }

                    }
                }

                same.Clear();
            }

            return false;
        }


    }
}
