using System;

namespace TicTacToe_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board =
            {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
            };
            int playerCount = 1;

            do
            {
                Console.Clear();
                printBoard(board);
                playerTurn(ref playerCount, ref board);
            } while (!Checker(board));
            Console.Clear();
            printBoard(board);
            if (playerCount == 1)
                Console.WriteLine("Player 2 won!!!");
            else
                Console.WriteLine("Player 1 won!!!");

            //printBoard(board);
            Console.ReadKey();
        }
        public static void playerTurn(ref int playerCount, ref char[,] board)
        {
            char input;
            bool isValidMove = false;
            Console.Write($"Player {playerCount}: Choose your field: ");
            isValidMove = char.TryParse(Console.ReadLine(), out input);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board[i, j].Equals(input))
                    {
                        isValidMove = true;
                        if (playerCount == 1)
                        {
                            board[i, j] = 'X';
                            playerCount = 2;
                        }
                        else
                        {
                            board[i, j] = 'O';
                            playerCount = 1;
                        }
                        break;
                    }
            if (!isValidMove)
            {
                //Console.WriteLine("This is not valid! Try again!");
                playerTurn(ref playerCount, ref board);
            }
        }

        public static void printBoard(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("     |     |     ");
                Console.WriteLine($"  {board[i, 0]}  |  {board[i, 1]}  |  {board[i, 2]}  ");
                if (i != 2)
                    Console.WriteLine("_____|_____|_____");
                else
                    Console.WriteLine("     |     |     ");
            }
        }


        public static bool Checker(char[,] board)
        {
            bool winner = false;

            //check horizontal win
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    winner = true;
                    break;
                }
            }

            //check vertical win
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    winner = true;
                    break;
                }
            }

            //check secundary diagonal
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                winner = true;
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                winner = true;

            return winner;
        }
    }
}
