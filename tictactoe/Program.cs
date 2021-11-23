using System;

namespace tictactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.DisplayBoard();
            Player p = new Player();            
            p.Name = Console.ReadLine();
            p.Mark = 'X';
            p.DisplayPlayer();
            Player c = new Player("Computer", 'O');
            c.DisplayPlayer();
            g.CompChoose();
            g.AskHuman(p);            
                        
           
        }
    }
}
