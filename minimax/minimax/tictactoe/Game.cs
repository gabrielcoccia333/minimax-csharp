using System;
using System.Collections.Generic;
using System.Text;
using minimax.core.adversarial;

namespace minimax.tictactoe
{
    class Game : IGame<State, Action, Player>
    {
        public List<Action> GetActions(State state)
        {
            List<Action> action = new List<Action>();
            Action tmp;
            int[,] field = state.field;
            Player CurrentPlayer = state.CurrentPlayer;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (field[row, col] == -1)
                    {
                        tmp = new Action(row, col);
                        action.Add(tmp);
                    }
                }
            }
            return action;
        }//si

        public State GetInitialState()
        {


            int[,] field = new int[3, 3];
            State statoIniziale = new State();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    field[i, j] = -1;

                }
            }
            Player CurrentPlayer = Player.Cross;
            return statoIniziale;
        }//si

        public Player GetPlayer(State state)
        {
            Player player = state.CurrentPlayer;
            return player;
        }//si
        public Player[] GetPlayers()
        {
            Player[] players = new Player[2] { Player.Cross, Player.Circle };
            return players;
        }//si

        public State GetResult(State state, Action action)
        {
            State CopyState = new State();
            CopyState.field = (int[,])state.field.Clone();
            CopyState.CurrentPlayer = state.CurrentPlayer;

            CopyState.field[action.Row, action.Col] = (int)CopyState.CurrentPlayer;
            if (CopyState.CurrentPlayer == Player.Circle)
            {
                CopyState.CurrentPlayer = Player.Cross;
            }
            else
            {
                CopyState.CurrentPlayer = Player.Circle;
            }
            return CopyState;
        }//si

        public double GetUtility(State state, Player player)
        {
            int winner = ControllCombination(state);
            if (IsTerminal(state) == true)
            {
                if (winner == (int)player)
                    return double.PositiveInfinity - 1;
                else if (winner == -1)
                    return 0;
                else
                {
                    return double.NegativeInfinity + 1;
                }
            }

            return 0;
        }//si

        public bool IsTerminal(State state)
        {
            if ((ControllCombination(state) == (int)Player.Cross) || (ControllCombination(state) == (int)Player.Circle))
            {
                return true;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state.field[i, j] == -1)
                    {
                        return false;
                    }
                }
            }
            return true;


        }//si
        public static int ControllCombination(State state)
        {
            for (int i = 0; i < 3; i++)
            {
                if (state.field[i, 0] != -1)
                {
                    if ((state.field[i, 0] == state.field[i, 1]) && (state.field[i, 0] == state.field[i, 2]))
                    {
                        return state.field[i, 0];
                    }

                }
                if (state.field[0, i] != -1)
                {
                    if ((state.field[0, i] == state.field[1, i]) && (state.field[0, i] == state.field[2, i]))
                    {
                        return state.field[0, i];
                    }
                }
            }
            if (state.field[1, 1] != -1)
            {
                if ((state.field[0, 0] == state.field[1, 1]) && (state.field[0, 0] == state.field[2, 2]))
                {
                    return state.field[1, 1];
                }
                else if ((state.field[0, 2] == state.field[1, 1]) && (state.field[0, 2] == state.field[2, 0]))
                {
                    return state.field[1, 1];
                }
            }
            return -1;
        }//si
    }


}
