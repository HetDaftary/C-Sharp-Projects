/**
 * Trying to make a Tic-Tac-Toe console app in C#.
 */

using System;

namespace TicTacToeConsoleApp
{
    class GamePlay
    {
        private static readonly char[] toTrim = { ' ', '\t', '\n' };

        private static void printGame(char[, ] game)
        {
            Console.WriteLine("Current Game");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(String.Format("| {0} ", game[i, j]));
                }
                Console.WriteLine("|");
            }
        } 

        private static bool checkWin(char[, ] game, char currentTurn)
        {
            if (game[1, 1] == currentTurn)
            {
                if (game[0, 0] == currentTurn && game[2, 2] == currentTurn)
                {
                    return true;
                }
                else if (game[0, 2] == currentTurn && game[2, 0] == currentTurn)
                {
                    return true;
                }
                else if (game[0, 1] == currentTurn && game[2, 1] == currentTurn)
                {
                    return true;
                }
                else if (game[1, 0] == currentTurn && game[1, 2] == currentTurn)
                {
                    return true;
                }
            }
            else
            {
                if (game[0, 0] == currentTurn && game[0, 1] == currentTurn && game[0, 2] == currentTurn)
                {
                    return true;
                }
                else if (game[2, 0] == currentTurn && game[2, 1] == currentTurn && game[2, 2] == currentTurn)
                {
                    return true;
                }
                else if (game[0, 0] == currentTurn && game[1, 0] == currentTurn && game[2, 0] == currentTurn)
                {
                    return true;
                }
                else if (game[2, 0] == currentTurn && game[2, 1] == currentTurn && game[2, 2] == currentTurn)
                {
                    return true;
                }
            }
            return false;
        }

        public static void startTwoPlayerGame()
        {
            char currentTurn = 'x';
            char[,] game = new char[3, 3];
            int numberOfTurns = 0, x, y;
            int[] arr;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    game[i, j] = ' ';
                }
            }

            while (numberOfTurns < 9)
            {
                printGame(game);
                Console.Write(String.Format("{0}'s turn. Enter the move: ", currentTurn));
                arr = Array.ConvertAll(Console.ReadLine().Trim(toTrim).Split(), int.Parse);
                x = arr[0];
                y = arr[1];

                if (game[x, y] == ' ')
                {
                    // Can make the move as this place is valid.
                    game[x, y] = currentTurn;
                    if (checkWin(game, currentTurn))
                    {
                        Console.WriteLine(String.Format("{0} wins!", currentTurn));
                        printGame(game);
                        return;
                    }
                    currentTurn = (currentTurn == 'x') ? 'o' : 'x';
                    numberOfTurns++;
                }
                else
                {
                    Console.WriteLine("Invalid move");
                }
            }

            if (numberOfTurns == 9)
            {
                Console.WriteLine("Draw");
            }
        }

        private static readonly Random random = new Random();

        private static int[] makeRandomMove(char[, ] game)
        {
            int[] arr = new int[2];

            do
            {
                arr[0] = random.Next(3);
                arr[1] = random.Next(3);
            } while (game[arr[0], arr[1]] != ' ');

            return arr;
        }

        public static void startOnePlayerGame()
        {
            char currentTurn = 'x';
            char[, ] game = new char[3, 3];
            int numberOfTurns = 0, x, y;
            int[] arr;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    game[i, j] = ' ';
                }
            }

            while (numberOfTurns < 8)
            {
                printGame(game);
                Console.Write("Enter move: ");

                arr = Array.ConvertAll(Console.ReadLine().Trim(toTrim).Split(), int.Parse);
                x = arr[0];
                y = arr[1];

                if (game[x, y] == ' ')
                {
                    // Can make the move as this place is valid.
                    game[x, y] = currentTurn;
                    if (checkWin(game, currentTurn))
                    {
                        Console.WriteLine("x wins");
                        break;
                    }

                    currentTurn = 'o';
                    arr = makeRandomMove(game);
                    x = arr[0];
                    y = arr[1];

                    game[x, y] = currentTurn;
                    if (checkWin(game, currentTurn))
                    {
                        Console.WriteLine("o wins");
                        break;
                    }
                    currentTurn = 'x';

                    numberOfTurns += 2;
                }
                else
                {
                    Console.WriteLine("Invalid move");
                }
            }

            while (numberOfTurns == 8)
            {
                printGame(game);
                Console.Write("Enter move: ");
                arr = Array.ConvertAll(Console.ReadLine().Trim(toTrim).Split(), int.Parse);
                x = arr[0];
                y = arr[1];

                if (game[x, y] == ' ')
                {
                    // Can make the move as this place is valid.
                    game[x, y] = currentTurn;
                    if (checkWin(game, currentTurn))
                    {
                        Console.WriteLine("x wins!");
                    }
                    else
                    {
                        Console.WriteLine("Draw");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid move");
                }
            }
        }
    }

    class Program
    {
        static char makeLower(char a)
        {
            // Converting capital letters to small letters using ASCII value logic. 
            int temp = a;

            if (64 < temp && temp < 91)
            {
                return (char)(temp + 32);
            } return a;
        }

        static void Main(string[] args)
        {
            char option;

            do
            {
                Console.WriteLine("Enter 1 for 1 player game");
                Console.WriteLine("Enter 2 for 2 player game");
                Console.WriteLine("Enter q to quit");
                // Providing user with description.

                // You can also use str.ToLower here but I do not want to use that.
                option = makeLower(Console.ReadLine()[0]);
                // Reading a character from the console and converting it to lower case.
                
                if (option == '2')
                {
                    // To start a new two player game.
                    GamePlay.startTwoPlayerGame();
                } else if (option == '1')
                {
                    // To start a new one player game.  
                    GamePlay.startOnePlayerGame();
                } else if (option != 'q')
                {
                    // If action isn't valid. We will ask for the option again.
                    // Q is a valid option so if user enters q, we just have to exit and not print this message.
                    Console.WriteLine("Option not recognized.");
                }
            } while (option != 'q');
        }
    }
}
