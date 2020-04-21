using System;
namespace movingAnt
{
    class Program
    {
        struct grid
        {
            public bool active;
            public int visited;
        }
        
        static void Main(string[] args)
        {
            int xSize; // The x axis
            int ySize; // The y axis
            int xPos; // The position at the x axis
            int yPos; // The position at the y axis
            int totalNewBlocksHit = 0; // The number of new tiles hit
            int stepCounter = 0; // Step counter
            
            Console.WriteLine("Number of Rows?");
            while (!int.TryParse(Console.ReadLine(), out xSize) || xSize < 0) { Console.WriteLine("(!) Error: enter a real number"); }
            
            Console.WriteLine("Number of Columns?");
            while (!int.TryParse(Console.ReadLine(), out ySize) || ySize < 0) { Console.WriteLine("(!) Error: enter a real number"); }
            
            grid[,] capArray = new grid[xSize, ySize]; // Creates a 

            int totalSize = capArray.GetLength(0) * capArray.GetLength(1);

            Random randomNumber = new Random();
            xPos = randomNumber.Next(0, xSize);
            yPos = randomNumber.Next(0, ySize);

            do
            {
                capArray[xPos, yPos].active = false; // This shows where the ant is located at that exact moment, this information can be useful in the future.  

                int posGen = randomNumber.Next(0, 4); // Randomizing a number between 1 and 4 
                switch (posGen)
                {
                    case 0:
                        xPos++; // Goes one step to the right
                        break;
                    case 1:
                        yPos++; // Goes one step to up
                        break;
                    case 2:
                        xPos--; // Goes one step to the left
                        break;
                    case 3:
                        yPos--; // Goes one step down
                        break;
                }
   
                if (xPos < 0) // If the ant goes too far to the left 
                    xPos = capArray.GetLength(0) - 1; // The ant gets moved all the way to the right
                else if (xPos > (capArray.GetLength(0) - 1)) // If the ant goes too far to the right 
                    xPos = 0; // The ant gets moved all the way to the left

                if (yPos < 0) // If the ant goes too far up
                    yPos = capArray.GetLength(1) - 1; // The ant gets moved all the way down
                else if (yPos > (capArray.GetLength(1) - 1)) // If the ant goes all the way down
                    yPos = 0; // The and gets moved all the way to the top
                
                if (capArray[xPos, yPos].visited == 0) 
                    totalNewBlocksHit++; // Counts every blocks first step

                capArray[xPos, yPos].active = true; 
                capArray[xPos, yPos].visited++; 
                stepCounter++; // Adds a step 

            } while (totalNewBlocksHit != totalSize); // All this takes place while all the tiles are unvisited
            
            Console.WriteLine("It took {0} steps for the ant to visit all tiles. ", stepCounter);
        }
    }
}