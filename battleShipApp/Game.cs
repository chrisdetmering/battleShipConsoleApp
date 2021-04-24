using System;
namespace battleShipApp
{
    public class Game
    {
        private static int guesses = 10;  
        private static int hits = 0;

      
        public void PlayBattleShip()
        {
            Console.WriteLine("Ready to play battleship? Doesn't matter, you're going to play!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

                Board board = new Board();

                while (true)
                {
                    Console.Clear();
                    board.DrawBoard();
                    Console.WriteLine($"Guesses: {guesses}");
                    Console.WriteLine($"Hits: {hits}");

                    board.PlaceBattleShip();

                    int x = GetUserCoordinateGuess('x');
                    int y = GetUserCoordinateGuess('y');
                    SubtractOneGuessFromGuesses();

                    string guess = $"{x}{y}";

                    if (IsOutOfGuesses())
                    {
                        GameOver();
                        break;
                    }


                    if (board.HitBattleShip(guess))
                    {
                        Console.WriteLine("You hit the battleship!");
                        board.UpdateBattleShipHits(guess);
                        AddOneToHits();
                    }
                    else
                    {
                        Console.WriteLine("You missed the battleship");
                        board.UpdateMisses(guess);
                    }


                    if (IsSunk())
                    {
                        Won();
                        break;
                    }


                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
            
        }


        private static int GetUserCoordinateGuess(char coordinate)
        {
            int UserGuess;

            while (true)
            {
                UserGuess = PromptUserForCoordinate(coordinate);

                if (UserGuess < 10 && UserGuess >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Your {coordinate} coordinate is out of bounds");
                }

            }

            return UserGuess;
        }



        private static int PromptUserForCoordinate(char coordinate)
        {
            Console.WriteLine($"Select {coordinate} coordinate between 0 - 9:");
            string Coordinate = Console.ReadLine();
            return Int32.Parse(Coordinate);
        }


        private static void Won()
        {
            Console.Clear();
            Console.WriteLine("You WON. You sunk the battleship!");
        }

        private static void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over!");
        }

        private static bool IsOutOfGuesses()
        {
            return guesses == 0; 
        }


        private static void SubtractOneGuessFromGuesses()
        {
            guesses -= 1; 
        }


        private static void AddOneToHits()
        {
            hits += 1;
        }

        private static bool IsSunk()
        {
            return hits == 5; 
        }
    }
}
