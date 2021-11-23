using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace tictactoe
{
    class Game
    {
        private List <int> comp_picks = new List<int>();
        private List <int> human_picks = new List<int>();
        private List <int> possible = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        private string board = "\n_1_|_2_|_3_\n_4_|_5_|_6_\n_7_|_8_|_9_\n";
        private string not_allowed = "123456789";
        

        //Displays an initial board with numbered cells.
        public void InitBoard()
        {
            Console.WriteLine("The cells are numbered from 1 to 9 as seen below: {0}Please tipe your name.", board);           
        }

        //Asks for a cell number. If the number was already chosen by computer, it asks again.
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

        //Picks a random number between 1 and 9 as computer choise and adds it to comp_picks list.
        private void CompChose(Player c)
        {
            int cp;
            Random r = new Random();
            cp = r.Next(possible.Count);
            possible.Remove(cp);
            comp_picks.Add(cp);
            Console.WriteLine("Computer choice is {0}.", cp);
            FillBoard(cp, c.Mark);
        }

        private void FillBoard(int pick, char mark)
        {
            string pk = Convert.ToString(pick);
            string mk = Convert.ToString(mark);
            board = board.Replace(pk, mk);            
        }

        private void DisplayBoard()
        {
            Console.WriteLine("The modified board is {0}", board);
        }

        public void Play(Player p, Player c)
        {
          while (FullBoard() == false)
            {
                CompChose(c);
                AskHuman(p);
                DisplayBoard();
            }

            Console.WriteLine("The board is full");
        }

        private bool FullBoard()
        {
            foreach(char c in not_allowed)
            {
                if (board.Contains(c.ToString()))
                    return false;
            }

            return true;
        }


    }
}
