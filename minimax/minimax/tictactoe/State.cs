using System;
using System.Collections.Generic;
using System.Text;

namespace minimax.tictactoe
{
    class State
    {
        public static readonly int EMPTY = -1;
        public static readonly int Circle = (int)Player.Circle;
        public static readonly int Cross = (int)Player.Cross;

        //public int[,] field;
        //public Player CurrentPlayer;

        public State()
        {
            field = new int[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    field[row, col] = EMPTY;
                }
            }
            CurrentPlayer = Player.Cross;
        }

        public int[,] field { get; set; }
        public Player CurrentPlayer { get; set; }
        public int getState(int row, int col)
        {
            int state;
            if (field[row, col] == EMPTY)
            {
                state = EMPTY;
            }
            else if (field[row, col] == Circle)
            {
                state = Circle;
            }
            else
            {
                state = Cross;
            }
            return state;

        }

    }



}
