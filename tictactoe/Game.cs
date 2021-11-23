using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace tictactoe
{
    class Game
    {
        private List <int> comp_picks = new List<int>();
        private List<int> human_picks = new List<int>();
        public void DisplayBoard()
        {
            Console.WriteLine("The cells are numbered from 1 to 9 as seen below:\n_1_|_2_|_3_\n_4_|_5_|_6_\n_7_|_8_|_9_\nPlease tipe your name.");
        }

        public void AskHuman(Player p)
        {           
            bool resp = false;
            while (resp == false)
            {
                Console.WriteLine("{0} is your turn to choose a cell.", p.Name);
                int pick = int.Parse(Console.ReadLine());
                resp = VerifyPick(pick);
            }
           
        }

        public bool VerifyPick(int pi)
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

        public void CompChoose()
        {
            int cp;
            Random r = new Random();
            cp = r.Next(1, 10);           
            comp_picks.Add(cp);
            Console.WriteLine("Computer choice is {0}.", cp);
            comp_picks.ForEach(Console.WriteLine);
        }
    }
}
