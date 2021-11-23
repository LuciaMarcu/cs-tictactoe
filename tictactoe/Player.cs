using System;
using System.Collections.Generic;
using System.Text;

namespace tictactoe
{
    class Player
    {
        protected string name;
        protected char mark;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public char Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        public Player() { }
        public Player(string n, char m)
        {
            name = n;
            mark = m;
        }

        public void DisplayPlayer()
        {
            Console.WriteLine("It was created the player {0} with the mark {1}.", name, mark);
        }
    }
}
