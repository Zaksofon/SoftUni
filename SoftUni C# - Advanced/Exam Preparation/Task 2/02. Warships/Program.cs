using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            char[,] matrix = new char[dimensions, dimensions];

            int playerOneShipsStarting = 0;
            int playerTwoShipsStarting = 0;
            int playerOneShipsFinishing = 0;
            int playerTwoShipsFinishing = 0;

            for (int row = 0; row < dimensions; row++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < dimensions; col++)
                {
                    matrix[row, col] = input[col];
                    switch (matrix[row, col])
                    {
                        case '<':
                            playerOneShipsStarting++;
                            break;
                        case '>':
                            playerTwoShipsStarting++;
                            break;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                int[] currentAttack = commands[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentRowAttack = Convert.ToInt32(currentAttack[0]);
                int currentColAttack = Convert.ToInt32(currentAttack[1]);
                playerOneShipsFinishing = 0;
                playerTwoShipsFinishing = 0;

                if (currentRowAttack < 0 || currentRowAttack > dimensions ||
                    currentColAttack < 0 || currentColAttack > dimensions)
                {
                    continue;
                }

                switch (matrix[currentRowAttack, currentColAttack])
                {
                    case '<':
                        matrix[currentRowAttack, currentColAttack] = '*';
                        break;

                    case '>':
                        matrix[currentRowAttack, currentColAttack] = '*';
                        break;

                    case '#':
                        if (currentRowAttack - 1 >= 0)
                        {
                            matrix[currentRowAttack - 1, currentColAttack] = 'X';
                        }

                        if (currentRowAttack - 1 >= 0 && currentColAttack + 1 < dimensions)
                        {
                            matrix[currentRowAttack - 1, currentColAttack + 1] = 'X';
                        }

                        if (currentColAttack + 1 < dimensions)
                        {
                            matrix[currentRowAttack, currentColAttack + 1] = 'X';
                        }

                        if (currentRowAttack + 1 < dimensions && currentColAttack + 1 < dimensions)
                        {
                            matrix[currentRowAttack + 1, currentColAttack + 1] = 'X';
                        }

                        if (currentRowAttack + 1 < dimensions)
                        {
                            matrix[currentRowAttack + 1, currentColAttack] = 'X';
                        }

                        if (currentRowAttack + 1 < dimensions && currentColAttack - 1 >= 0)
                        {
                            matrix[currentRowAttack + 1, currentColAttack - 1] = 'X';
                        }

                        if (currentColAttack - 1 >= 0)
                        {
                            matrix[currentRowAttack, currentColAttack - 1] = 'X';
                        }

                        if (currentRowAttack - 1 >= 0 && currentColAttack - 1 >= 0)
                        {
                            matrix[currentRowAttack - 1, currentColAttack - 1] = 'X';
                        }
                        break;
                }

                for (int row = 0; row < dimensions; row++)
                {
                    for (int col = 0; col < dimensions; col++)
                    {
                        switch (matrix[row, col])
                        {
                            case '<':
                                playerOneShipsFinishing++;
                                break;
                            case '>':
                                playerTwoShipsFinishing++;
                                break;
                        }
                    }
                }

                if (playerOneShipsFinishing == 0 || playerTwoShipsFinishing == 0)
                {
                    break;
                }
            }
            int shipsBeenDestroyedFirstPlayer = playerOneShipsStarting - playerOneShipsFinishing;
            int shipsBeenDestroyedSecondPlayer = playerTwoShipsStarting - playerTwoShipsFinishing;
            int totalSunkShips = shipsBeenDestroyedFirstPlayer + shipsBeenDestroyedSecondPlayer;

            if (shipsBeenDestroyedFirstPlayer == playerOneShipsStarting || shipsBeenDestroyedSecondPlayer == playerTwoShipsStarting)
            {
                if (shipsBeenDestroyedFirstPlayer < shipsBeenDestroyedSecondPlayer)
                {
                    Console.WriteLine($"Player One has won the game! {totalSunkShips} ships have been sunk in the battle.");
                    return;
                }

                if (shipsBeenDestroyedFirstPlayer > shipsBeenDestroyedSecondPlayer)
                {
                    Console.WriteLine($"Player Two has won the game! {totalSunkShips} ships have been sunk in the battle.");
                    return;
                }
            }

            if (playerOneShipsFinishing > 0 && playerTwoShipsFinishing > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShipsFinishing} ships left." +
                                  $" Player Two has {playerTwoShipsFinishing} ships left.");
                return;
            }
        }
    }
}
