using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace The_Good_Life
{
    static class Program
    {
        const int Rows = 25;
        const int Columns = 50;

        static bool SimRun = true;

        public static void Main()
        {
            var coords = new Stats[Rows, Columns];

            // randomly initialize our coords
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    coords[row, column] = (Stats)RandomNumberGenerator.GetInt32(0, 2);
                }
            }

            Console.CancelKeyPress += (sender, args) =>
            {
                SimRun = false;
                Console.WriteLine(Environment.NewLine + "Run complete...");
            };

            // let's give our console
            // a good scrubbing
            Console.Clear();

            // Displaying the coords 
            while (SimRun)
            {
                W2C(coords);
                coords = NextGen(coords);
            }
        }

        private static Stats[,] NextGen(Stats[,] currentcoords)
        {
            var NextGen = new Stats[Rows, Columns];

            // Loop through every cell 
            for (var row = 1; row < Rows - 1; row++)
                for (var column = 1; column < Columns - 1; column++)
                {
                    // find your Good neighbors
                    var GoodNeighbors = 0;
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            GoodNeighbors += currentcoords[row + i, column + j] == Stats.Good ? 1 : 0;
                        }
                    }

                    var currentCell = currentcoords[row, column];

                    // The cell needs to be subtracted 
                    // from its neighbors as it was  
                    // counted before 
                    GoodNeighbors -= currentCell == Stats.Good ? 1 : 0;

                    // Implementing the Rules of Life 

                    // Cell is lonely and dies 
                    if (currentCell == Stats.Good && GoodNeighbors < 2)
                    {
                        NextGen[row, column] = Stats.NotGood;
                    }

                    // Cell dies due to over population 
                    else if (currentCell == Stats.Good && GoodNeighbors > 3)
                    {
                        NextGen[row, column] = Stats.NotGood;
                    }

                    // A new cell is born 
                    else if (currentCell == Stats.NotGood && GoodNeighbors == 3)
                    {
                        NextGen[row, column] = Stats.Good;
                    }
                    // stays the same
                    else
                    {
                        NextGen[row, column] = currentCell;
                    }
                }
            return NextGen;
        }

        private static void W2C(Stats[,] future, int timeout = 500)
        {
            var stringBuilder = new StringBuilder();
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    var cell = future[row, column];
                    stringBuilder.Append(cell == Stats.Good ? "G" : "N");
                }
                stringBuilder.Append(Environment.NewLine);
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Write(stringBuilder.ToString());
            Thread.Sleep(timeout);
        }
    }

    public enum Stats
    {
        NotGood,
        Good,
    }
}