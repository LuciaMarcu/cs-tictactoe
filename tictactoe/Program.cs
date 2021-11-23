using System;

namespace tictactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.InitBoard();
            Player p = new Player();            
            p.Name = Console.ReadLine();
            p.Mark = 'X';
            p.DisplayPlayer();
            Player c = new Player("Computer", 'O');
            c.DisplayPlayer();
            g.Play(p, c);           
           
        }
    }
}
