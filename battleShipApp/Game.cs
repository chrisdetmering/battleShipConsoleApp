using System;
namespace battleShipApp
{
    public class Game
    {
        public Game()
        {
            //hits
            //guesses
        }

        public static int GetUserCoordinateGuess(char coordinate)
        {
            int UserGuess;

            while (true)
            {
                UserGuess = PromptUserForCoordinate(coordinate);

                if (UserGuess < 10 && UserGuess > 0)
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




        public static int PromptUserForCoordinate(char coordinate)
        {
            Console.WriteLine($"Select {coordinate} coordinate between 1 - 10:");
            string Coordinate = Console.ReadLine();
            return Int32.Parse(Coordinate);
        }



    }
}
