using System;
using System.Collections;

namespace battleShipApp
{
    public class Board
    {
        private Hashtable Misses;
        private Hashtable BattleShipHits;
        public string BattleShipLocation;

        public Board()
        {
            Misses = new Hashtable();
            BattleShipHits = new Hashtable();
            BattleShipLocation = PlaceBattleShip();
        }



        public bool HitBattleShip(string guess)
        {
            return string.Equals(guess, BattleShipLocation);
        }


        public void UpdateMisses(string coordinate)
        {
            Misses.Add(coordinate, 'O');
        }

        public void UpdateBattleShipHits(string coordinate)
        {
            BattleShipHits.Add(coordinate, " X ");
        }

        public string PlaceBattleShip()
        {
            string location; 

            while (true)
            {
                location = GetRandomLocation();
                if (!Misses.Contains(location))
                {
                    break;
                }
            }


            return location; 
        }





        public void DrawBoard()
        {

            int[,] board = new int[10, 10];


            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    

                    if (Misses.Contains($"{i}{j}"))
                    {
                        Console.Write(" 0 ");
                    } else if (BattleShipHits.Contains($"{i}{j}"))
                    {
                        Console.Write(" X ");
                    } else
                    {
                        Console.Write(" _ ");
                    }

                }
                Console.WriteLine();
            } 
        }


        private string GetRandomLocation()
        {
            Random random = new Random();

            int x = random.Next(0, 9);
            int y = random.Next(0, 9);
            return $"{x}{y}";
        }



    }
}
