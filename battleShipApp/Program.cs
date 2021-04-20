using System;
using System.Collections;

namespace battleShipApp
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Ready to play battleship?");


           string userInput = Console.ReadLine();


            //I want to update the board when I miss it
            //1) keep track of missed guesses.
            //2) if indexes is inside of misses, show 0
            

            if (userInput == "y")
            {

             
                Board board = new Board();

                while (true)
                {
                    Console.Clear();
                    board.DrawBoard();

                    

                    //Place battleShip
                    Random random = new Random();

                    int BattleShipXCoordinate = random.Next(0, 9);
                    int BattleShipYCoordinate = random.Next(0, 9);




                    //GetCoordinates
                    int x = GetUserCoordinateGuess('x');
                    int y = GetUserCoordinateGuess('y');

     

                    if (x == BattleShipXCoordinate && y == BattleShipYCoordinate)
                    {
                        Console.WriteLine("You hit the battleship!");
                       
                    }
                    else
                    {
                        Console.WriteLine("You missed the battleship");
                        //add index of guess to misses
                        string missedGuess = $"{x}{y}"; 
                        board.UpdateMisses(missedGuess);
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
            }

        }





        //Move to Game Class

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
