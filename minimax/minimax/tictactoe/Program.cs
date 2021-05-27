using System;
using System.Collections.Generic;
using System.Text;
using minimax.core.adversarial;

namespace minimax.tictactoe
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("-------------");
                Console.WriteLine("|   |   |   |");
                Console.WriteLine("-------------");
                Console.WriteLine("|   |   |   |");
                Console.WriteLine("-------------");
                Console.WriteLine("|   |   |   |");
                Console.WriteLine("-------------");
                Console.WriteLine("");

                Game game = new Game();
                List<Action> actions = new List<Action>();
                State state = game.GetInitialState();

                AdversarialSearch<State, Action> adversarial;
                adversarial = new MinimaxSearch<State, Action, Player>(game);

                while (!game.IsTerminal(state))
                {
                    Console.WriteLine("Scegli la riga");
                    int row = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Scegli la colonna");
                    int col = Convert.ToInt32(Console.ReadLine());

                    Action action = new Action(row, col);
                    actions = game.GetActions(state);
                    state = game.GetResult(state, action);
                    Partita(state);

                    if (!game.IsTerminal(state))
                    {
                        Action avversario = adversarial.makeDecision(state);
                        state = game.GetResult(state, avversario);
                        Partita(state);
                    }
                }
            }

        }

        public static void Partita(State state)
        {
            char[] tris = new char[3] {' ', 'X', 'O'};
            string[,] pos = new string[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state.field[i, j] == -1)
                        pos[i, j] = " ";
                    else if (state.field[i, j] == 0)
                        pos[i, j] = "X";
                    else
                        pos[i, j] = "O";
                }
            }
            Console.WriteLine("-------------");
            Console.WriteLine($"| {pos[0, 0]} | {pos[0, 1]} | {pos[0, 2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {pos[1, 0]} | {pos[1, 1]} | {pos[1, 2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {pos[2, 0]} | {pos[2, 1]} | {pos[2, 2]} |");
            Console.WriteLine("-------------");
        }
    }
}
